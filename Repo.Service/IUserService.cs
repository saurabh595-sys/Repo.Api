using Repo.Model;
using Repo.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Service
{
    public interface IUserService
    {
       
            Task<IEnumerable<User>> GetAllUser();
            Task<User> GetUserById(int id);
            Task<bool> AddUser(User Users);
            Task<bool> UpdateUser(User Users);
            Task<bool> DeleteUser(int id);
        
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository= userRepository;
        }
       
        public async Task<bool> DeleteUser(int id)
        {
           
                User user = await GetUserById(id);
                if (user != null)
                {
                    await _userRepository.Delete(user);
                    return true;
                }
            return false;

        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            
            return await _userRepository.Get();
        }

        public async Task<User> GetUserById(int id)
        {  
            return await _userRepository.GetById(id);
           
        }

       

        public async Task<bool> AddUser(User Users)
        {
            Users.CreatedDate = DateTime.Now;
            try
            {
              await  _userRepository.Add(Users);
               
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateUser(User Users)
        {
            try {
                User _user = await GetUserById(Users.UserId);
                if (_user != null)
                {
                    _user.UserName = Users.UserName;
                    _user.Password = Users.Password;
                    await _userRepository.Update(_user);
                }

                return true;
            }
            catch
            {
                return false;
            }

        }

       
    }
}
