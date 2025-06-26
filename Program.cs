using DarkAuto;
using DarkAuto.DTOs;
using DarkAuto.Models;
using DarkAuto.Repositories.GetAllUsers;
using DarkAuto.Repositories.Users;
using DarkAuto.Services;
using EntityFrameworkLesson.Models.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

class Program
{

    static void Main()
    {
        LoaderService.Spinner(1000);
        bool run = true;

        while (run) {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔" + new string('═', 32) + "╗");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("║" + "Welcome To DarkAuto!".PadLeft(26).PadRight(32) + "║");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╚" + new string('═', 32) + "╝");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nChoose Action:");
            Console.WriteLine("1. Log In");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Password Recovery");
            Console.WriteLine("4. Exit");

            Console.WriteLine("\nEnter Action:");

            Console.ForegroundColor = ConsoleColor.Green;
            string? mainAction = Console.ReadLine();

            Console.ResetColor();


            switch (mainAction) {
                case "1":

                    Console.Clear();
                    LoaderService.Spinner(1000);
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("╔" + new string('═', 32) + "╗");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("║" + "Enter Credentials".PadLeft(25).PadRight(32) + "║");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("╚" + new string('═', 32) + "╝");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\nEmail: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string? email = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\nPassword: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string? password = Console.ReadLine();

                    Console.ResetColor();

                    var LogInService = new LogInService();

                    var LogInRes = LogInService.LogIn(email!, password!);

                    if (LogInRes.IsSuccess && LogInRes.Data is not null)
                    {


                        bool user = true;
                        while (user)
                        {
                            Console.Clear();
                            LoaderService.Spinner(1250);
                            Console.Clear();

                            string userDisplay = $"Welcome - {LogInRes.Data.UserName} [{(LogInRes.Data.IsAdmin ? "Admin" : "User")}]";

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("╔" + new string('═', 32) + "╗");

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("║" + userDisplay.PadLeft((32 + userDisplay.Length) / 2).PadRight(32) + "║");

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("╚" + new string('═', 32) + "╝");
                            Console.ResetColor();

                            string logoutOption = LogInRes.Data.IsAdmin ? "10" : "9";

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nChoose Action:");
                            Console.WriteLine("1. All Cars");
                            Console.WriteLine("2. Available Cars");
                            Console.WriteLine("3. Buy Car");
                            Console.WriteLine("4. Delivery Companies");
                            Console.WriteLine("5. Locations");
                            Console.WriteLine("6. My Cars");
                            Console.WriteLine("7. My Deliveries");
                            Console.WriteLine("8. Settings");
                            if (LogInRes.Data.IsAdmin) Console.WriteLine("9. Admin Panel");
                            Console.WriteLine($"{(LogInRes.Data.IsAdmin ? "10" : "9")}. Log Out");

                            Console.WriteLine("\nEnter Action:");

                            Console.ForegroundColor = ConsoleColor.Green;
                            string? authActions = Console.ReadLine();

                            Console.ResetColor();

                            var CarService = new CarsService();
                            var CommonService = new CommonService();

                            switch (authActions)
                            {
                                case "1":
                                    Console.Clear();
                                    LoaderService.Spinner(500);
                                    Console.Clear();

                                    var Cars = CarService.GetAllCars();

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("╔" + new string('═', 44) + "╗");

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("║" + "All Cars".PadLeft(25).PadRight(44) + "║");

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("╚" + new string('═', 44) + "╝");
                                    Console.ResetColor();

                                    if (Cars.IsSuccess && Cars.Data != null)
                                    {
                                        if (Cars.Data.Any())
                                        {
                                            foreach (var c in Cars.Data)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.WriteLine($"\nID: {c.CarId}, Brand: {c.CarBrandName}, Category: {c.CarCategoryName}, Engine: {c.Engine}, Manufacture Date: {c.ManufactureDate:d}, Price: {c.Price}$, Damage: {(c.IsDamaged ? "Yes" : "No")}, Sold: {(c.IsSold ? "Yes" : "No")}, Sell Date: {(c.SellDate != null ? c.SellDate : "N/A")}, Seller: {c.SellerName}, Location: {c.LocationName}");
                                                Console.ResetColor();
                                            }
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("No cars found.");
                                        }
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"Error fetching cars: {Cars.ErrorMessage ?? "Unknown error"}");
                                    }

                                    Console.ForegroundColor = ConsoleColor.Yellow;

                                    Console.WriteLine("\nPress any key to return to main menu...");
                                    Console.ReadKey();

                                    Console.ResetColor();
                                    break;
                                case "2":
                                    Console.Clear();
                                    LoaderService.Spinner(500);
                                    Console.Clear();

                                    var availableCars = CarService.GetAvailabeCars();

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("╔" + new string('═', 44) + "╗");

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("║" + "Available Cars".PadLeft(25).PadRight(44) + "║");

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("╚" + new string('═', 44) + "╝");
                                    Console.ResetColor();

                                    if (availableCars.IsSuccess && availableCars.Data != null)
                                    {
                                        if (availableCars.Data.Any())
                                        {
                                            foreach (var c in availableCars.Data)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.WriteLine($"\nID: {c.CarId}, Brand: {c.CarBrandName}, Category: {c.CarCategoryName}, Engine: {c.Engine}, Manufacture Date: {c.ManufactureDate:d}, Price: {c.Price}$, Damage: {(c.IsDamaged ? "Yes" : "No")}, Sold: {(c.IsSold ? "Yes" : "No")}, Sell Date: {(c.SellDate != null ? c.SellDate : "N/A")}, Seller: {c.SellerName}, Location: {c.LocationName}");
                                                Console.ResetColor();
                                            }
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("No cars found.");
                                        }
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"Error fetching cars: {availableCars.ErrorMessage ?? "Unknown error"}");
                                    }

                                    Console.ForegroundColor = ConsoleColor.Yellow;

                                    Console.WriteLine("\nPress any key to return to main menu...");
                                    Console.ReadKey();

                                    Console.ResetColor();
                                    break;
                                case "4":
                                    Console.Clear();
                                    LoaderService.Spinner(500);
                                    Console.Clear();

                                    var Companies = CommonService.GetDeliveryCompanies();

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("╔" + new string('═', 44) + "╗");

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("║" + "Delivery Companies".PadLeft(25).PadRight(44) + "║");

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("╚" + new string('═', 44) + "╝");
                                    Console.ResetColor();

                                    if (Companies.IsSuccess && Companies.Data != null)
                                    {
                                        if (Companies.Data.Any())
                                        {
                                            foreach (var c in Companies.Data)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.WriteLine($"\nID: {c.CompanyId}, Name: {c.CompanyName}");
                                                Console.ResetColor();
                                            }
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("No companies found.");
                                        }
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"Error fetching companies: {Companies.ErrorMessage ?? "Unknown error"}");
                                    }

                                    Console.ForegroundColor = ConsoleColor.Yellow;

                                    Console.WriteLine("\nPress any key to return to main menu...");
                                    Console.ReadKey();

                                    Console.ResetColor();
                                    break;
                                case "5":
                                    Console.Clear();
                                    LoaderService.Spinner(500);
                                    Console.Clear();

                                    var Locations = CommonService.GetLocations();

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("╔" + new string('═', 44) + "╗");

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("║" + "Locations".PadLeft(25).PadRight(44) + "║");

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("╚" + new string('═', 44) + "╝");
                                    Console.ResetColor();

                                    if (Locations.IsSuccess && Locations.Data != null)
                                    {
                                        if (Locations.Data.Any())
                                        {
                                            foreach (var l in Locations.Data)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.WriteLine($"\nID: {l.LocationId}, Name: {l.LocationName}");
                                                Console.ResetColor();
                                            }
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("No locations found.");
                                        }
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"Error fetching locations: {Locations.ErrorMessage ?? "Unknown error"}");
                                    }

                                    Console.ForegroundColor = ConsoleColor.Yellow;

                                    Console.WriteLine("\nPress any key to return to main menu...");
                                    Console.ReadKey();

                                    Console.ResetColor();
                                    break;
                                case "6":
                                    Console.Clear();
                                    LoaderService.Spinner(500);
                                    Console.Clear();

                                    var MyCars = CarService.GetCarsByUserId(LogInRes.Data.UserId);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("╔" + new string('═', 44) + "╗");

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("║" + "All Cars".PadLeft(25).PadRight(44) + "║");

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("╚" + new string('═', 44) + "╝");
                                    Console.ResetColor();

                                    if (MyCars.IsSuccess && MyCars.Data != null)
                                    {
                                        if (MyCars.Data.Any())
                                        {
                                            foreach (var c in MyCars.Data)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.WriteLine($"\nID: {c.CarId}, Brand: {c.CarBrandName}, Category: {c.CarCategoryName}, Engine: {c.Engine}, Manufacture Date: {c.ManufactureDate:d}, Price: {c.Price}$, Damage: {(c.IsDamaged ? "Yes" : "No")}, Sold: {(c.IsSold ? "Yes" : "No")}, Sell Date: {(c.SellDate != null ? c.SellDate : "N/A")}, Seller: {c.SellerName}, Location: {c.LocationName}");
                                                Console.ResetColor();
                                            }
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("No cars found.");
                                        }
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"Error fetching cars: {MyCars.ErrorMessage ?? "Unknown error"}");
                                    }

                                    Console.ForegroundColor = ConsoleColor.Yellow;

                                    Console.WriteLine("\nPress any key to return to main menu...");
                                    Console.ReadKey();

                                    Console.ResetColor();
                                    break;
                                case "9" when LogInRes.Data.IsAdmin:

                                    bool adminActions = true;
                                    var AdminService = new AdminService();
                                    var HashPasswordService2 = new HashPasswordService();

                                    while (adminActions)
                                    {
                                        Console.Clear();
                                        LoaderService.Spinner(500);
                                        Console.Clear();

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("╔" + new string('═', 32) + "╗");

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("║" + "Admin Panel".PadLeft(25).PadRight(32) + "║");

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("╚" + new string('═', 32) + "╝");
                                        Console.ResetColor();


                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\nChoose Action:");
                                        Console.WriteLine("1. Users");
                                        Console.WriteLine("2. Cars");
                                        Console.WriteLine("3. Brands");
                                        Console.WriteLine("4. Categories");
                                        Console.WriteLine("5. Deliveries");
                                        Console.WriteLine("6. Delivery Companies");
                                        Console.WriteLine("7. Locations");
                                        Console.WriteLine("8. Payments");
                                        Console.WriteLine("9. Sellers");
                                        Console.WriteLine("10. Bids");
                                        Console.WriteLine("11. Go back");

                                        Console.WriteLine("\nEnter Action:");

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        string? adminMenuActions = Console.ReadLine();

                                        Console.ResetColor();
                                       

                                        switch (adminMenuActions)
                                        {
                                            case "1":
                                                bool usersSection = true;

                                                while (usersSection)
                                                {
                                                    Console.Clear();
                                                    LoaderService.Spinner(500);
                                                    Console.Clear();

                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("╔" + new string('═', 42) + "╗");

                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("║" + "Users".PadLeft(25).PadRight(42) + "║");

                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("╚" + new string('═', 42) + "╝");
                                                    Console.ResetColor();


                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.WriteLine("\nChoose Action:");
                                                    Console.WriteLine("1. All Users");
                                                    Console.WriteLine("2. Add User");
                                                    Console.WriteLine("3. Edit User");
                                                    Console.WriteLine("4. Delete User");
                                                    Console.WriteLine("5. Go Back");

                                                    Console.WriteLine("\nEnter Action:");

                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    string? usersSectionAction = Console.ReadLine();

                                                    Console.ResetColor();

                                                    switch (usersSectionAction)
                                                    {
                                                        case "1":

                                                            Console.Clear();
                                                            LoaderService.Spinner(500);
                                                            Console.Clear();

                                                            var users = AdminService.GetAllUsers();

                                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                                            Console.WriteLine(new string('═', 50)); 

                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine("{0," + ((50 + "All Users".Length) / 2).ToString() + "}", "All Users");  

                                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                                            Console.WriteLine(new string('═', 50)); 

                                                            Console.ResetColor();

                                                            if (users.IsSuccess && users.Data != null)
                                                            {
                                                                foreach (var u in users.Data)
                                                                {
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.WriteLine($"\nID: {u.UserId}, Username: {u.UserName}, Email: {u.Email}, Role: {(u.IsAdmin ? "Admin" : "User")}");
                                                                    Console.ResetColor();
                                                                }
                                                            }

                                                            Console.ForegroundColor = ConsoleColor.Yellow;

                                                            Console.WriteLine("\nPress any key to return to main menu...");
                                                            Console.ReadKey();

                                                            Console.ResetColor();
                                                            break;
                                                        case "2":
                                                            Console.Clear();
                                                            LoaderService.Spinner(500);
                                                            Console.Clear();

                                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                                            Console.WriteLine(new string('═', 50));

                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine("{0," + ((50 + "Add User".Length) / 2).ToString() + "}", "All Users");

                                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                                            Console.WriteLine(new string('═', 50));

                                                            Console.ResetColor();

                                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                                            Console.WriteLine("\nEnter Username:");

                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            string AddUsername = Console.ReadLine();

                                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                                            Console.WriteLine("\nEnter Email:");

                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            string AddEmail = Console.ReadLine();

                                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                                            Console.WriteLine("\nEnter Password:");

                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            string AddPassword = Console.ReadLine();

                                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                                            Console.WriteLine("\nIs Admin? [Y/N]:");

                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            string AddIsAdmin = Console.ReadLine();

                                                            Console.ResetColor();

                                                            var HashedPass = HashPasswordService2.HashPassword(AddPassword);

                                                            var AddRes = AdminService.AddUser(AddUsername, AddEmail, HashedPass, AddIsAdmin.Trim() == "y" ? true : false)
                                                                   .GetAwaiter()
                                                                   .GetResult();

                                                            Console.Clear();
                                                            LoaderService.Spinner(500);
                                                            Console.Clear();

                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine(AddRes.IsSuccess && AddRes.Data
                                                                ? "User Creation Successful"
                                                                : $"User Creation Failed: {AddRes.ErrorMessage ?? "Unknown error"}");

                                                            Console.ForegroundColor = ConsoleColor.Yellow;

                                                            Console.WriteLine("\nPress any key to return to main menu...");
                                                            Console.ReadKey();

                                                            Console.ResetColor();
                                                            break;
                                                        case "3":

                                                            break;
                                                        case "4":
                                                            Console.Clear();
                                                            LoaderService.Spinner(500);
                                                            Console.Clear();

                                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                                            Console.WriteLine("Enter User ID:");

                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            int SelectedUserID = int.Parse(Console.ReadLine());

                                                            Console.ResetColor();

                                                            var deleteRes = AdminService.DeleteUser(SelectedUserID)
                                                                .GetAwaiter()
                                                                .GetResult();

                                                            Console.Clear();
                                                            LoaderService.Spinner(500);
                                                            Console.Clear();

                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine(deleteRes.IsSuccess && deleteRes.Data
                                                                ? "Deletion Successful"
                                                                : $"Deletion Failed: {deleteRes.ErrorMessage ?? "Unknown error"}");

                                                            Console.ForegroundColor = ConsoleColor.Yellow;

                                                            Console.WriteLine("\nPress any key to return to main menu...");
                                                            Console.ReadKey();

                                                            Console.ResetColor();


                                                            break;
                                                        case "5":
                                                            usersSection = false;
                                                            break;
                                                        default:
                                                            usersSection = false;
                                                            break;
                                                    }
                                                }
                                                break;
                                            case "11":
                                                adminActions = false;
                                                break;
                                            default:
                                                adminActions = false;
                                                break;
                                        }
                                    }
                                    break;
                                case var action when action == logoutOption:
                                    user = false;
                                    break;

                                default:
                                    user = false;
                                    break;
                            }
                        }
                    } else
                    {
                        Console.Clear();
                        LoaderService.Spinner(500);
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Credentials!");

                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.WriteLine("\nPress any key to return to main menu...");
                        Console.ReadKey();

                        Console.ResetColor();

                    }


                        break;
                case "2":
                    Console.Clear();
                    LoaderService.Spinner(1000);
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("╔" + new string('═', 32) + "╗");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("║" + "Enter Credentials".PadLeft(25).PadRight(32) + "║");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("╚" + new string('═', 32) + "╝");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\nUsername: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string RegUsername = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\nEmail: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string RegEmail = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\nPassword: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string Regpassword = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\nRepeat Password: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string Regpassword2 = Console.ReadLine();

                    Console.ResetColor();

                    var RegisterService = new RegisterService();
                    var HashPasswordService = new HashPasswordService();

                    if (Regpassword.Trim() != Regpassword2.Trim())
                    {
                        Console.Clear();
                        LoaderService.Spinner(500);
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Password Do Not Match!");

                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.WriteLine("\nPress any key to return to main menu...");
                        Console.ReadKey();

                        Console.ResetColor();
                        return;
                    }

                    if (Regpassword.Length < 8 || Regpassword2.Length < 8)
                    {
                        Console.Clear();
                        LoaderService.Spinner(500);
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Password length must be minumum 8 symbols!");

                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.WriteLine("\nPress any key to return to main menu...");
                        Console.ReadKey();

                        Console.ResetColor();


                        return;
                    }

                    var HashedPassword = HashPasswordService.HashPassword(Regpassword!);

                    var regRes = RegisterService
                                 .Register(RegUsername!, RegEmail!, HashedPassword)
                                 .GetAwaiter()
                                 .GetResult();


                    Console.WriteLine(regRes.IsSuccess && regRes.Data
                        ? "Registration Successful"
                        : $"Registration Failed: {regRes.ErrorMessage ?? "Unknown error"}");

                    Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.WriteLine("\nPress any key to return to main menu...");
                        Console.ReadKey();

                        Console.ResetColor();
                        break;
                case "4":
                    run =  false;
                    break;

                default:
                    run = false;
                    break;
            }
        }
    }
}
