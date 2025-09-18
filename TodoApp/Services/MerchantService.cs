using TodoApp.Model;

namespace TodoApp.Services
{

    public class MerchantService : IMerchantServices
    {
        private readonly List<Merchant> _merchant= new List<Merchant>();
        //private readonly List<Merchant> _merchant = new();
        private int _nextincrementId = 1;

        //public MerchantService()
        //{
        //    _merchant = new List<Merchant>();
        //}
        public IEnumerable<Merchant> GetAll()
        {
            return _merchant;
        }

        public Merchant? GetById(int id) 
        {
            return _merchant.FirstOrDefault(a => a.Id == id);
        }

        public Merchant Add(Merchant merchant)
        {
            merchant.Id = _nextincrementId++;
            _merchant.Add(merchant);
            return merchant;
        }

        public bool Update(int id, Merchant merchant)
        {
            var existing = GetById(id);
            if (existing == null)
            {
                return false;
            }

            existing.Name = merchant.Name;
            existing.Mobileno = merchant.Mobileno;
            return true;
        }
        public bool Delete(int id)
        {
            var merchant = GetById(id);
            if (merchant == null)
            {
                return false;
            }

            _merchant.Remove(merchant);
            return true;
        }
    }
}
