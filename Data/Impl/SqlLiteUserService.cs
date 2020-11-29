using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_4___Server.Models;
using Assignment3.Persistance;

using Microsoft.EntityFrameworkCore;
using Models;

namespace Managing_Adults.Data.Impl
{
    public class SqlLiteUserService : IUserService
    {
        private AdultContext ctx;

        public SqlLiteUserService(AdultContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<User> ValidateUser(string userName, string password)
        {
            User first = ctx.Users.FirstOrDefault(user => user.UserName.Equals(userName) && user.Password.Equals(password));
            
            if (first == null){
                throw new Exception("User not found");
            }
            
            if (!first.Password.Equals(password)) {
                throw new Exception("Incorrect password");
            }

            Console.Out.WriteLine("Returning: " + first.UserName);
            return first;
        }
    }
}