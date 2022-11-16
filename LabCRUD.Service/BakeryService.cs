using System;
using System.Threading.Tasks;
using LabCRUD.DAL.Repositories;
using LabCRUD.Domain.Entity;
using LabCRUD.Domain.Interfaces.Repositories;
using LabCRUD.Domain.Interfaces.Service;
using LabCRUD.Domain.Response;

namespace LabCRUD.Service
{
    public class BakeryService : IBakeryService
    {
        private readonly IBakeryRepositories _salesManagerRepository;

        public BakeryService(BakeryRepositories salesManagerRepository)
        {
            _salesManagerRepository = salesManagerRepository;
        }

        public async Task<BaseResponse> CreateBackery(int id, string name, string number, string street, string house)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var backery = await _salesManagerRepository.Get(name);
                if (backery == null)
                {
                    backery = new Bakery()
                    {
                        Id = id,
                        Name = name,
                        Number = number,
                        Street = street,
                        House = house
                    };
                    await _salesManagerRepository.Insert(backery);

                    baseResponse.Data = backery;
                    baseResponse.Message = $"Добавлена новая пекарня: {backery.Name} ";
                    return baseResponse;
                }
                baseResponse.Message = $"Вы уже построили пекарню с именем {backery.Name}";
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse()
                {
                    Message = ex.InnerException.Message
                };  
            }
        }

        public async Task<BaseResponse> GetBackery(string actions)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var bakery = await _salesManagerRepository.Get(actions);
                if (bakery != null)
                {
                    baseResponse.Data = bakery;
                    return baseResponse;
                }

                baseResponse.Message = "Пекарня не найдена";
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse()
                {
                    Message = ex.Message
                };
            }
        }

        public async Task<BaseResponse> DeleteBackery(string name)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var bakery = await _salesManagerRepository.Get(name);
                if (bakery != null)
                {
                    await _salesManagerRepository.Delete(bakery);

                    baseResponse.Message = "Пекарня удалена :(";
                    baseResponse.Data = bakery;
                    return baseResponse;
                }

                baseResponse.Message = "Пекарня не найдена";
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse()
                {
                    Message = ex.Message
                };
            }
        }

        public async Task<BaseResponse> UpdateBackery(string name, string newName)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var bakery = await _salesManagerRepository.Get(name);
                if (bakery != null)
                {
                    bakery.Name = newName;
                    await _salesManagerRepository.Update(bakery);

                    baseResponse.Data = bakery;
                    baseResponse.Message = $"Название пекарни обновилось с {name} на {newName}";
                }

                baseResponse.Message = "Пекарня не найдена";
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse()
                {
                    Message = ex.Message
                };
            }
        }
    }
}