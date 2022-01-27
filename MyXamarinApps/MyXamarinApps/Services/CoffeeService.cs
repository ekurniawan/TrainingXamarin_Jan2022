using MyXamarinApps.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyXamarinApps.Services
{
    public class CoffeeService : ICoffee
    {
        public Task Add(Coffee coffee)
        {
            throw new NotImplementedException();
        }

        public Task Edit(int id, Coffee coffee)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Coffee>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Coffee> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
