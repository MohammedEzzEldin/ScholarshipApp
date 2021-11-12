using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using ScholarShip.Models;
using ScholarShip.Classes;

[assembly: OwinStartupAttribute(typeof(ScholarShip.Startup))]
namespace ScholarShip
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRoles();
            CreateDefaultAdminUsers();
        }

        public void CreateDefaultRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role;

            //add admins role
            if (!roleManager.RoleExists(ConstantVariables.adminsRole))
            {
                role = new IdentityRole();
                role.Name = ConstantVariables.adminsRole;
                roleManager.Create(role);
            }
            // students role
            if (!roleManager.RoleExists(ConstantVariables.studentsRole))
            {
                role = new IdentityRole();
                role.Name = ConstantVariables.studentsRole;
                roleManager.Create(role);
            }
        }

        public void CreateDefaultAdminUsers()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ApplicationUser user = new ApplicationUser()
            {
                UserName = ConstantVariables.adminUserName,
                Email = ConstantVariables.adminEamil
            };
            var result = userManager.Create(user, ConstantVariables.adminDefaultPassword);
            if (result.Succeeded)
            {
                userManager.AddToRole(user.Id, ConstantVariables.adminsRole);
            }

        }


    }
}
