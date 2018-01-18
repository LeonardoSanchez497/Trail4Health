using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trail4Healthtest.Models;

namespace Trail4Healthtest.Data
{
    public class SeedUsers
    {
        public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUser(userManager);
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrador").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Administrador";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Turista").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Turista";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }

            public static void SeedUser(UserManager<ApplicationUser> userManager)
            {
                if (userManager.FindByNameAsync("user1").Result == null)
                {
                    ApplicationUser user = new ApplicationUser();
                    user.UserName = "micaelmx@hotmail.com";
                    user.Email = "micaelmx@hotmail.com";

                    IdentityResult result = userManager.CreateAsync
                    (user, "Capel#0").Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Administrador").Wait();
                    }
                }

                if (userManager.FindByNameAsync("user2").Result == null)
                {
                    ApplicationUser user = new ApplicationUser();
                    user.UserName = "lsilva497@gmail.com";
                    user.Email = "lsilva497@gmail.com";

                    IdentityResult result = userManager.CreateAsync
                    (user, "Leonar#0").Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Administrador").Wait();
                    }
                }

                if (userManager.FindByNameAsync("user3").Result == null)
                {
                    ApplicationUser user = new ApplicationUser();
                    user.UserName = "fabio.anjos.martins@gmail.com";
                    user.Email = "fabio.anjos.martins@gmail.com";

                    IdentityResult result = userManager.CreateAsync
                    (user, "Fabio#0").Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Administrador").Wait();
                    }
                }

            }
        }
    }
