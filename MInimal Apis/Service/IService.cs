using MInimal_Apis.Data;
using MInimal_Apis.Models;

namespace MInimal_Apis.Service
{
    public interface IService
    {
        bool Add(Item item);
        bool Delete(Item item);
        bool Update(Item item);
        Task<IEnumerable<Item>> GetAll();
        Task<Item> GetById(int id);
    }
}
