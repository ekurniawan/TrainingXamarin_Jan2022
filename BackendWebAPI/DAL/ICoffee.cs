using MyXamarinApps.Shared;
using System.Collections.Generic;

namespace BackendWebAPI.DAL
{
    public interface ICoffee
    {
        IEnumerable<Coffee> GetAll();
        Coffee GetById(int id);
        void Insert(Coffee coffee);
        void Update(int id, Coffee coffee);
        void Delete(int id);
        IEnumerable<ViewCoffeeWithOrigin> GetCoffeeWithOrigin();
    }
}
