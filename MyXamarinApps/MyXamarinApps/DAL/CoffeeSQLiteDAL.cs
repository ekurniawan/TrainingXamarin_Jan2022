using MyXamarinApps.Shared;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MyXamarinApps.DAL
{
    public static class CoffeeSQLiteDAL
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null) return;
            var dbPath = Path.Combine(FileSystem.AppDataDirectory,"MyData.db");
            db = new SQLiteAsyncConnection(dbPath);
            await db.CreateTableAsync<Coffee>();
        }

        public static async Task<IEnumerable<Coffee>> GetAllCoffee()
        {
            await Init();
            /*string strSql = @"select * from Coffee 
                              order by Name asc";*/
            //var results = await db.QueryAsync<Coffee>(strSql);
            var results = await db.Table<Coffee>().OrderBy(c=>c.Name).ToListAsync();
            return results;
        }

        public static async Task<Coffee> GetCoffeeById(int id)
        {
            await Init();
            //var strSql = $"select * from Coffee where Id={id}";
            var result = await db.Table<Coffee>().Where(c => c.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public static async Task AddCoffee(Coffee coffee)
        {
            await Init();
            var image = "luwak.png";
            var newCoffee = new Coffee
            {
                Name = coffee.Name,
                Roaster = coffee.Roaster,
                Image = image
            };
            await db.InsertAsync(newCoffee);
        }

        public static async Task EditCoffee(int id,Coffee coffee)
        {
            await Init();
            var result = await GetCoffeeById(id);
            if (result != null)
            {
                result.Name = coffee.Name;
                result.Roaster = coffee.Roaster;
                await db.UpdateAsync(result);
            }
            else
            {
                throw new Exception($"Error: Data coffee {id} tidak ditemukan !");
            }
        }

        public static async Task RemoveCoffee(int id)
        {
            var result = await GetCoffeeById(id);
            if (result != null)
                await db.DeleteAsync(result);
            else
                throw new Exception($"Data coffee {id} tidak ditemukan");
        }

    }
}
