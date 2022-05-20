using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Entities;
using TableTracker.Domain.Interfaces;
using TableTracker.Domain.Interfaces.Repositories;
using TableTracker.Infrastructure.Identity;
using TableTracker.JwtFeatures;

namespace TableTracker.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<TableTrackerIdentityUser> _userManager;
        private readonly IMapper _mapper;
        private readonly JwtHandler _jwtHandler;
        private readonly IUnitOfWork<long> _unitOfWork;

        public AccountsController(
            UserManager<TableTrackerIdentityUser> userManager,
            IMapper mapper,
            JwtHandler jwtHandler,
            IUnitOfWork<long> unitOfWork)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForAuthenticationDTO userForAuthentication)
        {
            var user = await _userManager.FindByNameAsync(userForAuthentication.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
            {
                return Unauthorized(new AuthResponseDTO { ErrorMessage = "Invalid Authentication" });
            }

            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new AuthResponseDTO
            {
                IsAuthSuccessful = true,
                Token = token,
            });
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] UserForSignupDTO user)
        {
            var identityUser = new TableTrackerIdentityUser
            {
                UserName = user.Email,
                Email = user.Email,
            };

            var result = await _userManager.CreateAsync(identityUser, user.Password);

            if (result.Succeeded)
            {
                await _unitOfWork.GetRepository<IUserRepository>().Insert(new User
                {
                    Email = user.Email,
                    FullName = user.FirstName + " " + user.LastName,
                });

                await _unitOfWork.Save();
            }
            else
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
