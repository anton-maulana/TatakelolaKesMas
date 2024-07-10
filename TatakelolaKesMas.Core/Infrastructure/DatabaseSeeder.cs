// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TatakelolaKesMas.Core.Models;
using TatakelolaKesMas.Core.Models.Account;
using TatakelolaKesMas.Core.Models.EnumCode;
using TatakelolaKesMas.Core.Models.Shop;
using TatakelolaKesMas.Core.Services.Account;
using TatakelolaKesMas.Core.Services.Account.Exceptions;
using TatakelolaKesMas.Core.Services.Account.Interfaces;

namespace TatakelolaKesMas.Core.Infrastructure
{
    public class DatabaseSeeder(ApplicationDbContext dbContext, ILogger<DatabaseSeeder> logger,
        IUserAccountService userAccountService, IUserRoleService userRoleService) : IDatabaseSeeder
    {
        public async Task SeedAsync()
        {
            await dbContext.Database.MigrateAsync();
            await SeedDefaultUsersAsync();
        }

        /************ DEFAULT USERS **************/

        private async Task SeedDefaultUsersAsync()
        {
            if (!await dbContext.Users.AnyAsync())
            {
                logger.LogInformation("Generating inbuilt accounts");

                const string adminRoleName = "administrator";
                const string userRoleName = "user";

                await EnsureRoleAsync(adminRoleName, "Default administrator",
                    ApplicationPermissions.GetAllPermissionValues());

                await EnsureRoleAsync(userRoleName, "Default user", []);

                await CreateUserAsync("admin",
                    "TempP@ss123",
                    "Inbuilt Administrator",
                    "admin@ebenmonney.com",
                    "+1 (123) 000-0000",
                    [RoleNameEnum.Administrator.Code], null);

                await CreateUserAsync("ppk",
                    "TempP@ss123#",
                    "Inbuilt Standard User",
                    "user@ebenmonney.com",
                    "+1 (123) 000-0001",
                    [RoleNameEnum.PpkUser.Code], null);

                await CreateUserAsync("center",
                    "TempP@ss123#",
                    "Inbuilt Standard User",
                    "user@ebenmonney.com",
                    "+1 (123) 000-0001",
                    [RoleNameEnum.CenterUser.Code], null);
                await EnsureRoleAsync(RoleNameEnum.RegionUser.Code, "Default user", []);
                await CreateUserAsync("Aceh", "TempP@ss123#", "ACEH", "aceh@tatakelolakesmas.com", "+1 (123) 000-0000",
                    [RoleNameEnum.RegionUser.Code], "11");
                await CreateUserAsync("SumateraUtara", "TempP@ss123#", "SUMATERA UTARA",
                    "sumaterautara@tatakelolakesmas.com", "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "12");
                await CreateUserAsync("SumateraBarat", "TempP@ss123#", "SUMATERA BARAT",
                    "sumaterabarat@tatakelolakesmas.com", "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "13");
                await CreateUserAsync("Riau", "TempP@ss123#", "RIAU", "riau@tatakelolakesmas.com", "+1 (123) 000-0000",
                    [RoleNameEnum.RegionUser.Code], "14");
                await CreateUserAsync("Jambi", "TempP@ss123#", "JAMBI", "jambi@tatakelolakesmas.com", "+1 (123) 000-0000",
                    [RoleNameEnum.RegionUser.Code], "15");
                await CreateUserAsync("SumateraSelatan", "TempP@ss123#", "SUMATERA SELATAN",
                    "sumateraselatan@tatakelolakesmas.com", "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "16");
                await CreateUserAsync("Bengkulu", "TempP@ss123#", "BENGKULU", "bengkulu@tatakelolakesmas.com",
                    "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "17");
                await CreateUserAsync("Lampung", "TempP@ss123#", "LAMPUNG", "lampung@tatakelolakesmas.com",
                    "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "18");
                await CreateUserAsync("KepulauanBangkaBelitung", "TempP@ss123#", "KEPULAUAN BANGKA BELITUNG",
                    "kepulauanbangka belitung@tatakelolakesmas.com", "+1 (123) 000-0000",
                    [RoleNameEnum.RegionUser.Code], "19");
                await CreateUserAsync("KepulauanRiau", "TempP@ss123#", "KEPULAUAN RIAU",
                    "kepulauanriau@tatakelolakesmas.com", "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "21");
                await CreateUserAsync("DkiJakarta", "TempP@ss123#", "DKI JAKARTA", "dkijakarta@tatakelolakesmas.com",
                    "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "31");
                await CreateUserAsync("JawaBarat", "TempP@ss123#", "JAWA BARAT", "jawabarat@tatakelolakesmas.com",
                    "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "32");
                await CreateUserAsync("JawaTengah", "TempP@ss123#", "JAWA TENGAH", "jawatengah@tatakelolakesmas.com",
                    "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "33");
                await CreateUserAsync("DaerahIstimewaYogyakarta", "TempP@ss123#", "DAERAH ISTIMEWA YOGYAKARTA",
                    "daerahistimewa yogyakarta@tatakelolakesmas.com", "+1 (123) 000-0000",
                    [RoleNameEnum.RegionUser.Code], "34");
                await CreateUserAsync("JawaTimur", "TempP@ss123#", "JAWA TIMUR", "jawatimur@tatakelolakesmas.com",
                    "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "35");
                await CreateUserAsync("Banten", "TempP@ss123#", "BANTEN", "banten@tatakelolakesmas.com",
                    "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "36");
                await CreateUserAsync("Bali", "TempP@ss123#", "BALI", "bali@tatakelolakesmas.com", "+1 (123) 000-0000",
                    [RoleNameEnum.RegionUser.Code], "51");
                await CreateUserAsync("NusaTenggaraBarat", "TempP@ss123#", "NUSA TENGGARA BARAT",
                    "nusatenggara barat@tatakelolakesmas.com", "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code],
                    "52");
                await CreateUserAsync("NusaTenggaraTimur", "TempP@ss123#", "NUSA TENGGARA TIMUR",
                    "nusatenggara timur@tatakelolakesmas.com", "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code],
                    "53");
                await CreateUserAsync("KalimantanBarat", "TempP@ss123#", "KALIMANTAN BARAT",
                    "kalimantanbarat@tatakelolakesmas.com", "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "61");
                await CreateUserAsync("KalimantanTengah", "TempP@ss123#", "KALIMANTAN TENGAH",
                    "kalimantantengah@tatakelolakesmas.com", "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "62");
                await CreateUserAsync("KalimantanSelatan", "TempP@ss123#", "KALIMANTAN SELATAN",
                    "kalimantanselatan@tatakelolakesmas.com", "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code],
                    "63");
                await CreateUserAsync("KalimantanTimur", "TempP@ss123#", "KALIMANTAN TIMUR",
                    "kalimantantimur@tatakelolakesmas.com", "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "64");
                await CreateUserAsync("KalimantanUtara", "TempP@ss123#", "KALIMANTAN UTARA",
                    "kalimantanutara@tatakelolakesmas.com", "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "65");
                await CreateUserAsync("SulawesiUtara", "TempP@ss123#", "SULAWESI UTARA",
                    "sulawesiutara@tatakelolakesmas.com", "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "71");
                await CreateUserAsync("SulawesiTengah", "TempP@ss123#", "SULAWESI TENGAH",
                    "sulawesitengah@tatakelolakesmas.com", "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "72");
                await CreateUserAsync("SulawesiSelatan", "TempP@ss123#", "SULAWESI SELATAN",
                    "sulawesiselatan@tatakelolakesmas.com", "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "73");
                await CreateUserAsync("SulawesiTenggara", "TempP@ss123#", "SULAWESI TENGGARA",
                    "sulawesitenggara@tatakelolakesmas.com", "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "74");
                await CreateUserAsync("Gorontalo", "TempP@ss123#", "GORONTALO", "gorontalo@tatakelolakesmas.com",
                    "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "75");
                await CreateUserAsync("SulawesiBarat", "TempP@ss123#", "SULAWESI BARAT",
                    "sulawesibarat@tatakelolakesmas.com", "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "76");
                await CreateUserAsync("Maluku", "TempP@ss123#", "MALUKU", "maluku@tatakelolakesmas.com",
                    "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "81");
                await CreateUserAsync("MalukuUtara", "TempP@ss123#", "MALUKU UTARA", "malukuutara@tatakelolakesmas.com",
                    "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "82");
                await CreateUserAsync("PAPUA", "TempP@ss123#", "P A P U A", "pa p u a@tatakelolakesmas.com",
                    "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "91");
                await CreateUserAsync("PapuaBarat", "TempP@ss123#", "PAPUA BARAT", "papuabarat@tatakelolakesmas.com",
                    "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "92");
                await CreateUserAsync("PapuaSelatan", "TempP@ss123#", "PAPUA SELATAN",
                    "papuaselatan@tatakelolakesmas.com", "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "93");
                await CreateUserAsync("PapuaTengah", "TempP@ss123#", "PAPUA TENGAH", "papuatengah@tatakelolakesmas.com",
                    "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "94");
                await CreateUserAsync("PapuaPegunungan", "TempP@ss123#", "PAPUA PEGUNUNGAN",
                    "papuapegunungan@tatakelolakesmas.com", "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "95");
                await CreateUserAsync("PapuaBaratDaya", "TempP@ss123#", "PAPUA BARAT DAYA",
                    "papuabarat daya@tatakelolakesmas.com", "+1 (123) 000-0000", [RoleNameEnum.RegionUser.Code], "96");
            }
        }

                private async Task EnsureRoleAsync(string roleName, string description, string[] claims)
                {
                    if (await userRoleService.GetRoleByNameAsync(roleName) == null)
                    {
                        logger.LogInformation("Generating default role: {roleName}", roleName);

                        var applicationRole = new ApplicationRole(roleName, description);

                        var result = await userRoleService.CreateRoleAsync(applicationRole, claims);

                        if (!result.Succeeded)
                        {
                            throw new UserRoleException($"Seeding \"{description}\" role failed. Errors: " +
                                $"{string.Join(Environment.NewLine, result.Errors)}");
                        }
                    }
                }

                private async Task<ApplicationUser> CreateUserAsync(
                    string userName, string password, string fullName, string email, string phoneNumber, string[] roles, string region)
                {
                    logger.LogInformation("Generating default user: {userName}", userName);

                    var applicationUser = new ApplicationUser
                    {
                        UserName = userName,
                        FullName = fullName,
                        Email = email,
                        PhoneNumber = phoneNumber,
                        EmailConfirmed = true,
                        IsEnabled = true,
                        FkRegionId = region
                    };

                    var result = await userAccountService.CreateUserAsync(applicationUser, roles, password);

                    if (!result.Succeeded)
                    {
                        throw new UserAccountException($"Seeding \"{userName}\" user failed. Errors: " +
                            $"{string.Join(Environment.NewLine, result.Errors)}");
                    }

                    return applicationUser;
                }

                /************ DEMO DATA **************/

                // private async Task SeedDemoDataAsync()
                // {
                //     if (!await dbContext.Customers.AnyAsync() && !await dbContext.ProductCategories.AnyAsync())
                //     {
                //         logger.LogInformation("Seeding demo data");
                //
                //         var cust_1 = new Customer
                //         {
                //             Name = "Ebenezer Monney",
                //             Email = "contact@ebenmonney.com",
                //             Gender = Gender.Male
                //         };
                //
                //         var cust_2 = new Customer
                //         {
                //             Name = "Itachi Uchiha",
                //             Email = "uchiha@narutoverse.com",
                //             PhoneNumber = "+81123456789",
                //             Address = "Some fictional Address, Street 123, Konoha",
                //             City = "Konoha",
                //             Gender = Gender.Male
                //         };
                //
                //         var cust_3 = new Customer
                //         {
                //             Name = "John Doe",
                //             Email = "johndoe@anonymous.com",
                //             PhoneNumber = "+18585858",
                //             Address = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio.
                //             Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at elementum imperdiet",
                //             City = "Lorem Ipsum",
                //             Gender = Gender.Male
                //         };
                //
                //         var cust_4 = new Customer
                //         {
                //             Name = "Jane Doe",
                //             Email = "Janedoe@anonymous.com",
                //             PhoneNumber = "+18585858",
                //             Address = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio.
                //             Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at elementum imperdiet",
                //             City = "Lorem Ipsum",
                //             Gender = Gender.Male
                //         };
                //
                //         var prodCat_1 = new ProductCategory
                //         {
                //             Name = "None",
                //             Description = "Default category. Products that have not been assigned a category"
                //         };
                //
                //         var prod_1 = new Product
                //         {
                //             Name = "BMW M6",
                //             Description = "Yet another masterpiece from the world's best car manufacturer",
                //             BuyingPrice = 109775,
                //             SellingPrice = 114234,
                //             UnitsInStock = 12,
                //             IsActive = true,
                //             ProductCategory = prodCat_1
                //         };
                //
                //         var prod_2 = new Product
                //         {
                //             Name = "Nissan Patrol",
                //             Description = "A true man's choice",
                //             BuyingPrice = 78990,
                //             SellingPrice = 86990,
                //             UnitsInStock = 4,
                //             IsActive = true,
                //             ProductCategory = prodCat_1
                //         };
                //
                //         var ordr_1 = new Order
                //         {
                //             Discount = 500,
                //             Cashier = await dbContext.Users.OrderBy(u => u.UserName).FirstAsync(),
                //             Customer = cust_1
                //         };
                //
                //         var ordr_2 = new Order
                //         {
                //             Cashier = await dbContext.Users.OrderBy(u => u.UserName).FirstAsync(),
                //             Customer = cust_2
                //         };
                //
                //         ordr_1.OrderDetails.Add(new()
                //         {
                //             UnitPrice = prod_1.SellingPrice,
                //             Quantity = 1,
                //             Product = prod_1,
                //             Order = ordr_1
                //         });
                //         ordr_1.OrderDetails.Add(new()
                //         {
                //             UnitPrice = prod_2.SellingPrice,
                //             Quantity = 1,
                //             Product = prod_2,
                //             Order = ordr_1
                //         });
                //
                //         ordr_2.OrderDetails.Add(new()
                //         {
                //             UnitPrice = prod_2.SellingPrice,
                //             Quantity = 1,
                //             Product = prod_2,
                //             Order = ordr_2
                //         });
                //
                //         dbContext.Customers.Add(cust_1);
                //         dbContext.Customers.Add(cust_2);
                //         dbContext.Customers.Add(cust_3);
                //         dbContext.Customers.Add(cust_4);
                //
                //         dbContext.Products.Add(prod_1);
                //         dbContext.Products.Add(prod_2);
                //
                //         dbContext.Orders.Add(ordr_1);
                //         dbContext.Orders.Add(ordr_2);
                //
                //         await dbContext.SaveChangesAsync();
                //
                //         logger.LogInformation("Seeding demo data completed");
                //     }
                // }
            }
        }
