using TodoApp.Model;

namespace TodoApp.Services
{
    public interface IMerchantServices
    {
         IEnumerable<Merchant> GetAll();
         Merchant GetById(int id);
         Merchant Add(Merchant merchant);
         bool Update(int id, Merchant merchant);
         bool Delete(int id);
    }
}
