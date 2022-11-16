using LabCRUD.Domain.Response;
using System.Threading.Tasks;

namespace LabCRUD.Domain.Interfaces.Service
{
    public interface IWorksService
    {
        Task<BaseResponse> CreateWorks(int id, string actions, string worker, int backeryId);

        Task<BaseResponse> GetWorks(string actions);

        Task<BaseResponse> DeleteWorks(string actions);

        Task<BaseResponse> UpdateWorks(string actions, string newActions);
    }
}
