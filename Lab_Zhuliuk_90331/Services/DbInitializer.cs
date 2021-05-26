using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WLibrary.DAL.Data;
using WLibrary.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace Lab_Zhuliuk_90331.Services
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // создать БД, если она еще не создана
            context.Database.EnsureCreated();
            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin
                await roleManager.CreateAsync(roleAdmin);
            }
            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }
            ///////////////////////////////////////////////////////////////////////////////
            //проверка наличия групп объектов
            if (!context.PlantsGroups.Any())
            {
                context.PlantsGroups.AddRange(
                new List<PlantsGroup>
                {
                    new PlantsGroup {GroupName="Цветы"},
                    new PlantsGroup {GroupName="Декоративные растения"},
                    new PlantsGroup {GroupName="Фруктовые растения"}
                });
                await context.SaveChangesAsync();
            }
            // проверка наличия объектов
            if (!context.Plantses.Any())
            {
                context.Plantses.AddRange(
                new List<Plants>
                {
                    new Plants { PlantsName="Пурпурная роза", Description="Благородная", PlantsGroupId=1, Image="пурпурная_роза.jpg" },
                    new Plants { PlantsName="Оранжевая роза", Description="Благородная", PlantsGroupId=1, Image="оранжевая_роза.jpg" },
                    new Plants { PlantsName="Лаванда", Description="Красивая", PlantsGroupId=1, Image="лаванда.jpg" },
                    new Plants { PlantsName="Боярышник", Description="Декоративный", PlantsGroupId=2, Image="боярышник.jpg" },
                    new Plants { PlantsName="Фикус Бенджамина", Description="Символ Бангкока", PlantsGroupId=2, Image="фикус_бенджамина.jpg" },
                    new Plants { PlantsName="Каламондин", Description="Декоративное", PlantsGroupId=2, Image="каламондин.jpg" },
                    new Plants { PlantsName="Белая смородина", Description="Употребляют в пищу", PlantsGroupId=3, Image="белая_смородина.jpg" },
                    new Plants { PlantsName="Крыжовник обыкновенный", Description="Употребляют в пищу", PlantsGroupId=3, Image="крыжовник_обыкновенный.jpg" },
                    new Plants { PlantsName="Малина", Description="Употребляют в пищу", PlantsGroupId=3, Image="малина.jpg" }
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
