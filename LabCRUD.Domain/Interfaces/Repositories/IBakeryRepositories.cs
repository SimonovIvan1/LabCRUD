using System.Threading.Tasks;
using LabCRUD.Domain.Entity;

namespace LabCRUD.Domain.Interfaces.Repositories
{
    public interface IBakeryRepositories
    {
        Task<Bakery> Insert(Bakery bakery);
        
        Task<Bakery> Get(string name);

        Task Delete(Bakery bakery);

        Task Update(Bakery bakery);
    }
}