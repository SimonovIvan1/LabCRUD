using LabCRUD.Domain.Entity;
using System.Threading.Tasks;

namespace LabCRUD.Domain.Interfaces.Repositories
{
    public interface IWorksRepositories
    {
        Task<Works> Insert(Works works);

        Task<Works> Get(string actions);

        Task Delete(Works works);

        Task Update(Works works);
    }
}
