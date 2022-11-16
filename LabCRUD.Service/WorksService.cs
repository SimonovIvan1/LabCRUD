using LabCRUD.DAL.Repositories;
using LabCRUD.Domain.Entity;
using LabCRUD.Domain.Interfaces.Repositories;
using LabCRUD.Domain.Interfaces.Service;
using LabCRUD.Domain.Response;
using System;
using System.Threading.Tasks;

namespace LabCRUD.Service
{
    public class WorksService : IWorksService
    {
       
            private readonly IWorksRepositories worksRepositories;

            public WorksService(WorksRepositories worksRepositories)
            {
                this.worksRepositories = worksRepositories;
            }

            public async Task<BaseResponse> CreateWorks(int id, string actions, string worker, int backeryId)
            {
                var baseResponse = new BaseResponse();
                try
                {
                    var works = await worksRepositories.Get(actions);
                    if (works == null)
                    {
                        works = new Works()
                        {
                            Id = id,
                            Actions = actions,
                            Worker = worker,
                            BakeryId = backeryId
                        };
                        await worksRepositories.Insert(works);

                        baseResponse.Data = works;
                        baseResponse.Message = $"Добавлена новая услуга: {works.Actions} ";
                        return baseResponse;
                    }
                    baseResponse.Message = $"Услуга {works.Actions} уже есть";
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

            public async Task<BaseResponse> GetWorks(string actions)
            {
                var baseResponse = new BaseResponse();
                try
                {
                    var works = await worksRepositories.Get(actions);
                    if (works != null)
                    {
                        baseResponse.Data = works;
                        return baseResponse;
                    }

                    baseResponse.Message = "Услуга не найдена";
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

            public async Task<BaseResponse> DeleteWorks(string actions)
            {
                var baseResponse = new BaseResponse();
                try
                {
                    var works = await worksRepositories.Get(actions);
                    if (works != null)
                    {
                        await worksRepositories.Delete(works);

                        baseResponse.Message = "Услуга удалёна";
                        baseResponse.Data = works;
                        return baseResponse;
                    }

                    baseResponse.Message = "Услуга не найдена";
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

            public async Task<BaseResponse> UpdateWorks(string actions, string newActions)
            {
                var baseResponse = new BaseResponse();
                try
                {
                    var works = await worksRepositories.Get(actions);
                    if (works != null)
                    {
                        works.Actions = newActions;
                        await worksRepositories.Update(works);

                        baseResponse.Data = works;
                        baseResponse.Message = $"Мы больше не оказываем услугу {actions}, вместо неё вы можете попробовать {newActions}";
                    }

                    baseResponse.Message = "Услуга не найдена";
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
