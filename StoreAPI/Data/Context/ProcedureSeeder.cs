using AutoMapper;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StoreAPI.Dtos.CustomerDtos;
using StoreAPI.Models.User;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StoreAPI.Data.Context
{
    public class ProcedureSeeder
    {
        private readonly ApplicationDbContext _db;

        private readonly string _createProcedurePath = @".\Files\SQL Files\CreateGetCustomersSP.sql";

        public ProcedureSeeder(ApplicationDbContext db)
        {
            _db = db;
        }

        public void SeedProcedures()
        {
            var checkExistenceQuery = "select * from sysobjects where type='P' and name='GetCustomer'";

            var connString = this._db.Database.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlCommand checkExistenceCommand = new SqlCommand(checkExistenceQuery, conn);

                var answer = checkExistenceCommand.ExecuteScalar();

                if (answer == null)
                {
                    using (StreamReader r = new StreamReader(Path.GetFullPath(_createProcedurePath)))
                    {
                        string sql = r.ReadToEnd();
                        SqlCommand command = new SqlCommand(sql, conn);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
