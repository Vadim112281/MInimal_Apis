using Microsoft.EntityFrameworkCore;
using MInimal_Apis.Data;
using MInimal_Apis.Models;

namespace MInimal_Apis.Service
{
    public class Service: IService
    {
        private readonly AppDbContext _context;

        public Service(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();

            return true;
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetById(int id)
        {
            return await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool Delete(Item item)
        {
            _context.Items.Remove(item);
            _context.SaveChanges();

            return true;
        }

        public bool Update(Item item)
        {
            _context.Items.Update(item);
            _context.SaveChanges();

            return true;
        }
        
    }
}
