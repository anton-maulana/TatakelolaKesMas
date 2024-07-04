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

namespace TatakelolaKesMas.Core.Infrastructure
{
    public class DatabaseSeeder(ApplicationDbContext dbContext, ILogger<DatabaseSeeder> logger,
        IUserAccountService userAccountService, IUserRoleService userRoleService) : IDatabaseSeeder
    {
        public async Task SeedAsync()
        {
            await dbContext.Database.MigrateAsync();
            await SeedDemoDataAsync();
        }

        /************ DEFAULT USERS **************/

        private async Task SeedDefaultUsersAsync()
        {
            await EnsureRoleAsync(RoleNameEnum.RegionUser.Code, "Default user", []);
            await CreateUserAsync("Aceh","tempP@ss123","ACEH","aceh@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "11"); 
            await CreateUserAsync("SumateraUtara","tempP@ss123","SUMATERA UTARA","sumaterautara@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "12"); 
            await CreateUserAsync("SumateraBarat","tempP@ss123","SUMATERA BARAT","sumaterabarat@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "13"); 
            await CreateUserAsync("Riau","tempP@ss123","RIAU","riau@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "14"); 
            await CreateUserAsync("Jambi","tempP@ss123","JAMBI","jambi@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "15"); 
            await CreateUserAsync("SumateraSelatan","tempP@ss123","SUMATERA SELATAN","sumateraselatan@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "16"); 
            await CreateUserAsync("Bengkulu","tempP@ss123","BENGKULU","bengkulu@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "17"); 
            await CreateUserAsync("Lampung","tempP@ss123","LAMPUNG","lampung@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "18"); 
            await CreateUserAsync("KepulauanBangkaBelitung","tempP@ss123","KEPULAUAN BANGKA BELITUNG","kepulauanbangka belitung@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "19"); 
            await CreateUserAsync("KepulauanRiau","tempP@ss123","KEPULAUAN RIAU","kepulauanriau@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "21"); 
            await CreateUserAsync("DkiJakarta","tempP@ss123","DKI JAKARTA","dkijakarta@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "31"); 
            await CreateUserAsync("JawaBarat","tempP@ss123","JAWA BARAT","jawabarat@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "32"); 
            await CreateUserAsync("JawaTengah","tempP@ss123","JAWA TENGAH","jawatengah@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "33"); 
            await CreateUserAsync("DaerahIstimewaYogyakarta","tempP@ss123","DAERAH ISTIMEWA YOGYAKARTA","daerahistimewa yogyakarta@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "34"); 
            await CreateUserAsync("JawaTimur","tempP@ss123","JAWA TIMUR","jawatimur@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "35"); 
            await CreateUserAsync("Banten","tempP@ss123","BANTEN","banten@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "36"); 
            await CreateUserAsync("Bali","tempP@ss123","BALI","bali@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "51"); 
            await CreateUserAsync("NusaTenggaraBarat","tempP@ss123","NUSA TENGGARA BARAT","nusatenggara barat@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "52"); 
            await CreateUserAsync("NusaTenggaraTimur","tempP@ss123","NUSA TENGGARA TIMUR","nusatenggara timur@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "53"); 
            await CreateUserAsync("KalimantanBarat","tempP@ss123","KALIMANTAN BARAT","kalimantanbarat@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "61"); 
            await CreateUserAsync("KalimantanTengah","tempP@ss123","KALIMANTAN TENGAH","kalimantantengah@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "62"); 
            await CreateUserAsync("KalimantanSelatan","tempP@ss123","KALIMANTAN SELATAN","kalimantanselatan@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "63"); 
            await CreateUserAsync("KalimantanTimur","tempP@ss123","KALIMANTAN TIMUR","kalimantantimur@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "64"); 
            await CreateUserAsync("KalimantanUtara","tempP@ss123","KALIMANTAN UTARA","kalimantanutara@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "65"); 
            await CreateUserAsync("SulawesiUtara","tempP@ss123","SULAWESI UTARA","sulawesiutara@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "71"); 
            await CreateUserAsync("SulawesiTengah","tempP@ss123","SULAWESI TENGAH","sulawesitengah@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "72"); 
            await CreateUserAsync("SulawesiSelatan","tempP@ss123","SULAWESI SELATAN","sulawesiselatan@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "73"); 
            await CreateUserAsync("SulawesiTenggara","tempP@ss123","SULAWESI TENGGARA","sulawesitenggara@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "74"); 
            await CreateUserAsync("Gorontalo","tempP@ss123","GORONTALO","gorontalo@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "75"); 
            await CreateUserAsync("SulawesiBarat","tempP@ss123","SULAWESI BARAT","sulawesibarat@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "76"); 
            await CreateUserAsync("Maluku","tempP@ss123","MALUKU","maluku@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "81"); 
            await CreateUserAsync("MalukuUtara","tempP@ss123","MALUKU UTARA","malukuutara@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "82"); 
            await CreateUserAsync("PAPUA","tempP@ss123","P A P U A","pa p u a@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "91"); 
            await CreateUserAsync("PapuaBarat","tempP@ss123","PAPUA BARAT","papuabarat@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "92"); 
            await CreateUserAsync("PapuaSelatan","tempP@ss123","PAPUA SELATAN","papuaselatan@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "93"); 
            await CreateUserAsync("PapuaTengah","tempP@ss123","PAPUA TENGAH","papuatengah@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "94"); 
            await CreateUserAsync("PapuaPegunungan","tempP@ss123","PAPUA PEGUNUNGAN","papuapegunungan@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "95"); 
            await CreateUserAsync("PapuaBaratDaya","tempP@ss123","PAPUA BARAT DAYA","papuabarat daya@tatakelolakesmas.com","+1 (123) 000-0000",[RoleNameEnum.RegionUser.Code], "96"); 

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

                private async Task SeedDemoDataAsync()
                {
                    if (!await dbContext.Customers.AnyAsync() && !await dbContext.ProductCategories.AnyAsync())
                    {
                        logger.LogInformation("Seeding demo data");

                        var cust_1 = new Customer
                        {
                            Name = "Ebenezer Monney",
                            Email = "contact@ebenmonney.com",
                            Gender = Gender.Male
                        };

                        var cust_2 = new Customer
                        {
                            Name = "Itachi Uchiha",
                            Email = "uchiha@narutoverse.com",
                            PhoneNumber = "+81123456789",
                            Address = "Some fictional Address, Street 123, Konoha",
                            City = "Konoha",
                            Gender = Gender.Male
                        };

                        var cust_3 = new Customer
                        {
                            Name = "John Doe",
                            Email = "johndoe@anonymous.com",
                            PhoneNumber = "+18585858",
                            Address = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio.
                            Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at elementum imperdiet",
                            City = "Lorem Ipsum",
                            Gender = Gender.Male
                        };

                        var cust_4 = new Customer
                        {
                            Name = "Jane Doe",
                            Email = "Janedoe@anonymous.com",
                            PhoneNumber = "+18585858",
                            Address = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio.
                            Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at elementum imperdiet",
                            City = "Lorem Ipsum",
                            Gender = Gender.Male
                        };

                        var prodCat_1 = new ProductCategory
                        {
                            Name = "None",
                            Description = "Default category. Products that have not been assigned a category"
                        };

                        var prod_1 = new Product
                        {
                            Name = "BMW M6",
                            Description = "Yet another masterpiece from the world's best car manufacturer",
                            BuyingPrice = 109775,
                            SellingPrice = 114234,
                            UnitsInStock = 12,
                            IsActive = true,
                            ProductCategory = prodCat_1
                        };

                        var prod_2 = new Product
                        {
                            Name = "Nissan Patrol",
                            Description = "A true man's choice",
                            BuyingPrice = 78990,
                            SellingPrice = 86990,
                            UnitsInStock = 4,
                            IsActive = true,
                            ProductCategory = prodCat_1
                        };

                        var ordr_1 = new Order
                        {
                            Discount = 500,
                            Cashier = await dbContext.Users.OrderBy(u => u.UserName).FirstAsync(),
                            Customer = cust_1
                        };

                        var ordr_2 = new Order
                        {
                            Cashier = await dbContext.Users.OrderBy(u => u.UserName).FirstAsync(),
                            Customer = cust_2
                        };

                        ordr_1.OrderDetails.Add(new()
                        {
                            UnitPrice = prod_1.SellingPrice,
                            Quantity = 1,
                            Product = prod_1,
                            Order = ordr_1
                        });
                        ordr_1.OrderDetails.Add(new()
                        {
                            UnitPrice = prod_2.SellingPrice,
                            Quantity = 1,
                            Product = prod_2,
                            Order = ordr_1
                        });

                        ordr_2.OrderDetails.Add(new()
                        {
                            UnitPrice = prod_2.SellingPrice,
                            Quantity = 1,
                            Product = prod_2,
                            Order = ordr_2
                        });

                        dbContext.Customers.Add(cust_1);
                        dbContext.Customers.Add(cust_2);
                        dbContext.Customers.Add(cust_3);
                        dbContext.Customers.Add(cust_4);

                        dbContext.Products.Add(prod_1);
                        dbContext.Products.Add(prod_2);

                        dbContext.Orders.Add(ordr_1);
                        dbContext.Orders.Add(ordr_2);

                        await dbContext.SaveChangesAsync();

                        logger.LogInformation("Seeding demo data completed");
                    }
                }
            }
        }
