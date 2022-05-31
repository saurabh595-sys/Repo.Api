using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repo.DTO;
using Repo.Model;
using Repo.Service;
using System.Threading.Tasks;

namespace Repo.Api.Controllers
{

    public class LoginController : BaseApiController
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _config;

        public LoginController(IAccountService accountService, ITokenService tokenService, IConfiguration config)
        {
            _accountService = accountService;
            _tokenService = tokenService;
            _config = config;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO LoginDTO)
        {
            RolesDTO _login = await _accountService.login(LoginDTO.UserName, LoginDTO.Password);

            if (_login == null)
            {
                return Unauthorized("Invalid Credentials");
            }
            var token = _tokenService.CreateToken(_login);
            return Ok(token);
        }

      
    }
}
