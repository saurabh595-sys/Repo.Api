using Microsoft.EntityFrameworkCore;
using Repo.DTO;
using Repo.Model;
using Repo.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Repository.Repositories
{
   public interface IAccountRepository : IRepository<LoginDTO>
    {
        Task<RolesDTO> login(string username, string password);
    }
    public class AccountRepository : Repository<LoginDTO>, IAccountRepository
    {
        public AccountRepository( Contex contex):base(contex)
        {

        }
        public async Task<RolesDTO> login(string username, string password)
        {

            //User user = await _contex.Users.Where(x => x.UserName == username && x.Password == password).FirstOrDefaultAsync();
            //if (user != null)
            //{
            var loginDTO = await (from u in _contex.Users
                                      join r in _contex.Roles on
                                      u.RoleID equals r.RoleId
                                      where u.UserName==username & u.Password== password
                                      select new RolesDTO
                                      {
                                          UserName = u.UserName,
                                          password = u.Password,
                                          RoleId = u.RoleID,
                                          Role = r.Role

                                      }).FirstOrDefaultAsync();

                return loginDTO;
            ////}
            //return null;
           
        }

        //public async Task <string> Roles(int id)
        //{
        //    var role = await _contex.Roles.Where(x => x.RoleId == id).Select(x => x.Role).FirstOrDefaultAsync();


        //    return role;
        //}
    }
}
