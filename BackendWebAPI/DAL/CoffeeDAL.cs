using Microsoft.Extensions.Configuration;
using MyXamarinApps.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace BackendWebAPI.DAL
{
    public class CoffeeDAL : ICoffee
    {
        private IConfiguration _config;
        public CoffeeDAL(IConfiguration config)
        {
            _config = config;
        }

        private string GetConnStr()
        {
            return _config.GetConnectionString("AzureConn");
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"delete from Coffee where Id=@Id";
                var param = new { Id = id };
                try
                {
                    var result = conn.Execute(strSql, param);
                    if (result != 1)
                        throw new Exception("Gagal delete coffee");
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
            }
        }

        public IEnumerable<Coffee> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Coffee 
                                order by Name asc";
                var results = conn.Query<Coffee>(strSql);
                return results;
            }
        }

        public Coffee GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Coffee where Id=@Id";
                var param = new { Id = id };
                var result = conn.QueryFirst<Coffee>(strSql,param);
                return result;
            }
        }

        /*public IEnumerable<Coffee> GetAll()
        {
            List<Coffee> lstCoffee = new List<Coffee>();
            using(SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Coffee 
                                order by Name asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lstCoffee.Add(new Coffee
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Name = dr["Name"].ToString(),
                            Roaster = dr["Roaster"].ToString(),
                            Image=dr["Image"].ToString()
                        });
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            return lstCoffee;
        }*/

        /*public Coffee GetById(int id)
        {
            Coffee coffee = new Coffee();
            using(SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Coffee where Id=@Id";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    coffee.Id = Convert.ToInt32(dr["Id"]);
                    coffee.Name = dr["Name"].ToString();
                    coffee.Roaster = dr["Roaster"].ToString();
                    coffee.Image = dr["Image"].ToString();
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            return coffee;
        }*/

        public void Insert(Coffee coffee)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"insert into Coffee(Name,Roaster,Image) 
                values(@Name,@Roaster,@Image)";
                var param = new {Name=coffee.Name,Roaster=coffee.Roaster,Image=coffee.Image};
                try
                {
                    var result = conn.Execute(strSql, param);
                    if (result != 1)
                        throw new Exception("Gagal untuk meanambahkan data");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /*public void Insert(Coffee coffee)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"insert into Coffee(Name,Roaster,Image) 
                values(@Name,@Roaster,@Image)";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@Name",coffee.Name);
                cmd.Parameters.AddWithValue("@Roaster", coffee.Roaster);
                cmd.Parameters.AddWithValue("@Image", coffee.Image);

                try
                {
                    conn.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result != 1)
                        throw new Exception("Gagal insert coffee");
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message) ;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }*/

        public void Update(int id, Coffee coffee)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"update Coffee set Name=@Name,Roaster=@Roaster,Image=@Image 
                                  where Id=@Id";
                try
                {
                    var param = new { Name = coffee.Name, Roaster = coffee.Roaster,
                       Image=coffee.Image, Id = id };
                    var result = conn.Execute(strSql, param);
                    if (result != 1)
                        throw new Exception("Gagal update data Coffee");
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
            }
        }

        public IEnumerable<ViewCoffeeWithOrigin> GetCoffeeWithOrigin()
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                var strSql = @"select * from ViewCoffeeWithOrigin 
                             order by Name asc";
                var results = conn.Query<ViewCoffeeWithOrigin>(strSql);
                return results;
            }
        }
    }
}
