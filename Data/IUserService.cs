using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment_4___Server.Models;


namespace Managing_Adults.Data {
public interface IUserService {
    Task<User> ValidateUser(string userName, string password);

}
}