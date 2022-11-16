using System.Threading.Tasks;
using LabCRUD.Domain.Entity;
using LabCRUD.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LabCRUD.DAL.Repositories
{
    public class BakeryRepositories : IBakeryRepositories
    {
        public async Task<Bakery> Insert(Bakery bakery)
        {
            using (var db = new ApplicationDbContext())
            {
                await db.Bakery.AddAsync(bakery);
                await db.SaveChangesAsync();
            }
            return bakery;
        }

        public async Task<Bakery> Get(string name)
        {
            using var db = new ApplicationDbContext();
            return await db.Bakery.FirstOrDefaultAsync(x => x.Name == name);
        }
        
        public async Task Update(Bakery bakery)
        {
            using var db = new ApplicationDbContext();
            db.Bakery.Update(bakery);
            await db.SaveChangesAsync();
        }

        public async Task Delete(Bakery bakery)
        {
            using var db = new ApplicationDbContext();
            db.Bakery.Remove(bakery);
            await db.SaveChangesAsync();
        }
    }
}