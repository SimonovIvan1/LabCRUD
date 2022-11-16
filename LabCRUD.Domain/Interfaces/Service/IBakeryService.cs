using System.Threading.Tasks;
using LabCRUD.Domain.Response;

namespace LabCRUD.Domain.Interfaces.Service
{
    public interface IBakeryService
    {
        Task<BaseResponse> CreateBackery(int id, string name, string number, string street, string house);

        Task<BaseResponse> GetBackery(string name);

        Task<BaseResponse> DeleteBackery(string name);
        
        Task<BaseResponse> UpdateBackery(string name, string newName);
    }
}