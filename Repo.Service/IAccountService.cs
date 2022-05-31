using Repo.DTO;
using Repo.Model;
using Repo.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Service
{
   public interface IAccountService
    {
        Task<RolesDTO> login(string username, string password);
    }
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<RolesDTO> login(string username, string password)
        {
            return await _accountRepository.login(username, password);
        }
    }
}
