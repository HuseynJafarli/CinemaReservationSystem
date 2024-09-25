using CinemaReservationSystem.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CinemaReservationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;

        public AuthController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        //[HttpGet]
        //public async Task<IActionResult> CreateRole()
        //{
        //    IdentityRole role1 = new IdentityRole("SuperAdmin");
        //    IdentityRole role2 = new IdentityRole("Admin");
        //    IdentityRole role3 = new IdentityRole("Member");
        //    IdentityRole role4 = new IdentityRole("Editor");

        //    await roleManager.CreateAsync(role1);
        //    await roleManager.CreateAsync(role4);
        //    await roleManager.CreateAsync(role2);
        //    await roleManager.CreateAsync(role3);

        //    return Ok();
        //}

        //[HttpGet]
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser appUser = new AppUser()
        //    {
        //        UserName = "HuseynJ",
        //        Email = "hjafarli@gmail.com",
        //    };

        //    await userManager.CreateAsync(appUser, "Salam_123");
        //    return Ok();

        //}

        [HttpGet]
        public async Task<IActionResult> AddRole()
        {
            AppUser User = await userManager.FindByEmailAsync("hjafarli@gmail.com");

            await userManager.AddToRoleAsync(User, "SuperAdmin");
            return Ok();

        }
    }
}
