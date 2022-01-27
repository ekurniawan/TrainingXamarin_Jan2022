using MyXamarinApps.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyXamarinApps.Services
{
    public interface ICoffee
    {
        Task<IEnumerable<Coffee>> GetAll();
        Task<Coffee> GetById(int id);
        Task Add(Coffee coffee);
        Task Edit(int id,Coffee coffee);
        Task Remove(int id);
    }
}
