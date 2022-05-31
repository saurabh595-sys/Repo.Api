using Repo.Model;
using Repo.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Repository.Repositories
{
    public interface IUserRepository : IRepository<User>
    {

    }
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(Contex contex):base(contex)
        {

        }
    }
}
