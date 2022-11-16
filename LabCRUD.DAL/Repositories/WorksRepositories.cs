using LabCRUD.Domain.Entity;
using LabCRUD.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LabCRUD.DAL.Repositories
{
    public class WorksRepositories : IWorksRepositories
    {
        public async Task<Works> Insert(Works works)
        {
            using (var db = new ApplicationDbContext())
            {
                await db.Works.AddAsync(works);
                await db.SaveChangesAsync();
            }
            return works;
        }

        public async Task<Works> Get(string actions)
        {
            using var db = new ApplicationDbContext();
            return await db.Works.FirstOrDefaultAsync(x => x.Actions == actions);
        }

        public async Task Update(Works works)
        {
            using var db = new ApplicationDbContext();
            db.Works.Update(works);
            await db.SaveChangesAsync();
        }

        public async Task Delete(Works works)
        {
            using var db = new ApplicationDbContext();
            db.Works.Remove(works);
            await db.SaveChangesAsync();
        }
    }
}
