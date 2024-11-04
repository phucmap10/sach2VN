using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebdotNet.DataAccess.Data;
using WebdotNet.Models;
using WebdotNet.Utility;

namespace WebdotNet.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _db;
        public DbInitializer(UserManager<IdentityUser> user, RoleManager<IdentityRole> role, ApplicationDbContext db)
        {
            _roleManager = role;
            _userManager = user;
            _db = db;
        }
        public void Initialize()
        {
            //1 : Migration if not applied
            _db.Database.EnsureCreated();
            try
            {
                if (_db.Database.GetPendingMigrations().Any())
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }
            //2 : Create Roles

            if (!_roleManager.RoleExistsAsync(SD.Role_User_Individual).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Individual)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();

                //3 :Create Admin User
                var adminUser = new ApplicationUser
                {
                    UserName = "admin@pepes0cool.com",
                    Email = "admin@pepes0cool.com",
                    Name = "Pepes0cool",
                    PhoneNumber = "1234567890",
                    Address = "123 Main St"
                };
                var result = _userManager.CreateAsync(adminUser, "Maychila2@").GetAwaiter().GetResult();
                
                ApplicationUser applicationUser = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@pepes0cool.com");
                _userManager.AddToRoleAsync(applicationUser, SD.Role_Admin).GetAwaiter().GetResult();
            }

            return;
            
        }
    }
}
