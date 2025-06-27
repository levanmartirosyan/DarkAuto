using DarkAuto.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkAuto.MainComponent
{
    public static class MainComponent
    {
        public static void Run()
        {
            LoaderService.Spinner(1000);
            bool run = true;

            var hasher = new PasswordHasher<object>();

            while (run)
            {
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

                Console.Write("\nEnter Action: ");

                Console.ForegroundColor = ConsoleColor.Green;
                string? mainAction = Console.ReadLine();

                Console.ResetColor();


                switch (mainAction)
                {
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
                                Console.WriteLine("8. My Profile");
                                if (LogInRes.Data.IsAdmin) Console.WriteLine("9. Admin Panel");
                                Console.WriteLine($"{(LogInRes.Data.IsAdmin ? "10" : "9")}. Log Out");

                                Console.Write("\nEnter Action: ");

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
                                                    Console.WriteLine($"\nID: {c.CarId}, Brand: {c.CarBrandName}, Model: {c.CarModelName}, Category: {c.CarCategoryName}, Engine: {c.Engine}, Manufacture Date: {c.ManufactureDate}, Price: {c.Price}$, Damage: {(c.IsDamaged ? "Yes" : "No")}, Sold: {(c.IsSold ? "Yes" : "No")}, Sell Date: {(c.SellDate != null ? c.SellDate : "N/A")}, Seller: {c.SellerName}, Location: {c.LocationName}");
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
                                                    Console.WriteLine($"\nID: {c.CarId}, Brand: {c.CarBrandName},Model: {c.CarModelName}, Category: {c.CarCategoryName}, Engine: {c.Engine}, Manufacture Date: {c.ManufactureDate}, Price: {c.Price}$, Damage: {(c.IsDamaged ? "Yes" : "No")}, Sold: {(c.IsSold ? "Yes" : "No")}, Sell Date: {(c.SellDate != null ? c.SellDate : "N/A")}, Seller: {c.SellerName}, Location: {c.LocationName}");
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
                                                    Console.WriteLine($"\nID: {c.CarId}, Brand: {c.CarBrandName},Model: {c.CarModelName}, Category: {c.CarCategoryName}, Engine: {c.Engine}, Manufacture Date: {c.ManufactureDate}, Price: {c.Price}$, Damage: {(c.IsDamaged ? "Yes" : "No")}, Sold: {(c.IsSold ? "Yes" : "No")}, Sell Date: {(c.SellDate != null ? c.SellDate : "N/A")}, Seller: {c.SellerName}, Location: {c.LocationName}");
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
                                    case "7":
                                        Console.Clear();
                                        LoaderService.Spinner(500);
                                        Console.Clear();

                                        var MyDeliveries = CommonService.GetDeliveriesByUserId(LogInRes.Data.UserId);

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("╔" + new string('═', 44) + "╗");

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("║" + "My Deliveries".PadLeft(25).PadRight(44) + "║");

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("╚" + new string('═', 44) + "╝");
                                        Console.ResetColor();

                                        if (MyDeliveries.IsSuccess && MyDeliveries.Data != null)
                                        {
                                            if (MyDeliveries.Data.Any())
                                            {
                                                foreach (var d in MyDeliveries.Data)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.WriteLine($"\nID: {d.DeliveryId}, Delivery Address: {d.DeliveryAddress}, Delivery Date: {d.DeliveryDate}, Delivery Status: {(d.IsDelivered ? "Delivered" : "In Progress")}, Delivery Company: {d.CompanyName}, Tracking Number: {d.TrackingNumber}, Delivery Price: {d.DeliveryCost}$, CarId: {d.CarId}, Car Brand: {d.CarBrandName}, Car Model: {d.CarModelName}, Car Category: {d.CarCategoryName}, Engine: {d.Engine}, Manufacture Date: {d.ManufactureDate}, Car Price: {d.Price}, Damage Status: {(d.IsDamaged ? "Damaged" : "Not Damaged")}, Sell Status: {(d.IsSold ? "Sold" : "Available")}, Sell Date: {(d.SellDate != null ? d.SellDate : "N/A")}, Seller: {d.SellerName}, Location: {d.LocationName}, Payment Status: {(d.isPaid ? "Paid" : "Pendind")}");
                                                    Console.ResetColor();
                                                }
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.WriteLine("No deliveries found.");
                                            }
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine($"Error fetching Deliveries: {MyDeliveries.ErrorMessage ?? "Unknown error"}");
                                        }

                                        Console.ForegroundColor = ConsoleColor.Yellow;

                                        Console.WriteLine("\nPress any key to return to main menu...");
                                        Console.ReadKey();

                                        Console.ResetColor();
                                        break;
                                    case "8":

                                        bool profile = true;
                                        while (profile)
                                        {
                                            Console.Clear();
                                            LoaderService.Spinner(500);
                                            Console.Clear();

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("╔" + new string('═', 44) + "╗");

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("║" + "My Profile".PadLeft(25).PadRight(44) + "║");

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("╚" + new string('═', 44) + "╝");
                                            Console.ResetColor();

                                            var AdminService2 = new AdminService();

                                            var UserInfo = AdminService2.GetAllUsers();

                                            var CurrentUser = UserInfo.Data.FirstOrDefault(u => u.Email.ToLower().Equals(LogInRes.Data.Email.ToLower(), StringComparison.OrdinalIgnoreCase));

                                            if (CurrentUser != null)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine($"\nID:       {CurrentUser.UserId}");
                                                Console.WriteLine($"Username: {CurrentUser.UserName}");
                                                Console.WriteLine($"E-mail:   {CurrentUser.Email}");
                                                Console.WriteLine($"Role:  {(CurrentUser.IsAdmin ? "Admin" : "User")}");
                                                Console.ResetColor();
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("\nError!");
                                                Console.ResetColor();
                                            }

                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("\nChoose Action:");
                                            Console.WriteLine("1. Edit Profile");
                                            Console.WriteLine("2. Go Back");
                                            
                                            Console.Write("\nEnter Action: ");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            string profileMenuActions = Console.ReadLine();
                                            Console.ResetColor();

                                            switch (profileMenuActions)
                                            {
                                                case "1":
                                                    bool ProfileUserMenu = true;

                                                    while (ProfileUserMenu)
                                                    {
                                                        Console.Clear();
                                                        LoaderService.Spinner(500);
                                                        Console.Clear();

                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                        Console.WriteLine("Choose Option To Edit:");
                                                        Console.WriteLine("1. Username");
                                                        Console.WriteLine("2. Email");
                                                        Console.WriteLine("3. Password");
                                                        Console.WriteLine("4. Go Back");

                                                        Console.Write("\nEnter Action: ");

                                                        Console.ForegroundColor = ConsoleColor.Green;

                                                        string editUSerMenuAction = Console.ReadLine();

                                                        switch (editUSerMenuAction)
                                                        {
                                                            case "1":
                                                                Console.Clear();
                                                                LoaderService.Spinner(500);
                                                                Console.Clear();

                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.Write("New username: ");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                string? newUsername = Console.ReadLine();
                                                                if (string.IsNullOrWhiteSpace(newUsername)) newUsername = null;

                                                                var editResult = AdminService2.EditUser(LogInRes.Data.UserId, newUsername, null, null, null)
                                                                    .GetAwaiter()
                                                                    .GetResult();

                                                                Console.ForegroundColor = editResult.IsSuccess
                                                                    ? ConsoleColor.Green
                                                                    : ConsoleColor.Red;

                                                                Console.WriteLine(editResult.Data
                                                                    ? "\nUsername edited successfully."
                                                                    : $"\nUsername edit failed: {editResult.ErrorMessage ?? "Unknown error"}");

                                                                Console.ResetColor();
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
                                                                Console.Write("New Email: ");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                string? newEmail = Console.ReadLine();
                                                                if (string.IsNullOrWhiteSpace(newEmail)) newEmail = null;

                                                                var editResult2 = AdminService2.EditUser(LogInRes.Data.UserId, null, newEmail, null, null)
                                                                    .GetAwaiter()
                                                                    .GetResult();

                                                                Console.ForegroundColor = editResult2.IsSuccess
                                                                    ? ConsoleColor.Green
                                                                    : ConsoleColor.Red;

                                                                Console.WriteLine(editResult2.Data
                                                                    ? "\nEmail edited successfully."
                                                                    : $"\nEmail edit failed: {editResult2.ErrorMessage ?? "Unknown error"}");

                                                                Console.ResetColor();
                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.WriteLine("\nPress any key to return to main menu...");
                                                                Console.ReadKey();
                                                                Console.ResetColor();
                                                                break;
                                                            case "3":
                                                                Console.Clear();
                                                                LoaderService.Spinner(500);
                                                                Console.Clear();

                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.Write("New Password: ");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                string? newPassword = Console.ReadLine();
                                                                if (string.IsNullOrWhiteSpace(newPassword)) newPassword = null;

                                                                var HashedEditPassword = hasher.HashPassword(null, newPassword.Trim());

                                                                var editResult3 = AdminService2.EditUser(LogInRes.Data.UserId, null, null, HashedEditPassword, null)
                                                                    .GetAwaiter()
                                                                    .GetResult();

                                                                Console.ForegroundColor = editResult3.IsSuccess
                                                                    ? ConsoleColor.Green
                                                                    : ConsoleColor.Red;

                                                                Console.WriteLine(editResult3.Data
                                                                    ? "\nPassword edited successfully."
                                                                    : $"\nPassword edit failed: {editResult3.ErrorMessage ?? "Unknown error"}");

                                                                Console.ResetColor();
                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.WriteLine("\nPress any key to return to main menu...");
                                                                Console.ReadKey();
                                                                Console.ResetColor();
                                                                break;
                                                            case "4":
                                                                ProfileUserMenu = false;
                                                                break;
                                                            default:
                                                                ProfileUserMenu = false;
                                                                break;
                                                        }
                                                    }
                                                    break;
                                                case "2":
                                                    profile = false;
                                                    break;
                                                default:
                                                    profile = false;
                                                    break;
                                            }
                                        }
                                        break;
                                    case "9" when LogInRes.Data.IsAdmin:

                                        bool adminActions = true;
                                        var AdminService = new AdminService();

                                        while (adminActions)
                                        {
                                            Console.Clear();
                                            LoaderService.Spinner(500);
                                            Console.Clear();

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("╔" + new string('═', 40) + "╗");

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("║" + "Admin Panel".PadLeft(25).PadRight(40) + "║");

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("╚" + new string('═', 40) + "╝");
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

                                            Console.Write("\nEnter Action: ");

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

                                                        Console.Write("\nEnter Action: ");

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
                                                                Console.Write("\nEnter Username: ");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                string AddUsername = Console.ReadLine();

                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.Write("\nEnter Email: ");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                string AddEmail = Console.ReadLine();

                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.Write("\nEnter Password: ");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                string AddPassword = Console.ReadLine();

                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.Write("\nIs Admin? [Y/N]: ");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                string AddIsAdmin = Console.ReadLine();

                                                                Console.ResetColor();

                                                                var HashedPass = hasher.HashPassword(null, AddPassword);

                                                                var AddRes = AdminService.AddUser(AddUsername, AddEmail, HashedPass, AddIsAdmin.Trim().ToLower() == "y" ? true : false)
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
                                                                bool editUserMenu = true;

                                                                while (editUserMenu)
                                                                {
                                                                    Console.Clear();
                                                                    LoaderService.Spinner(500);
                                                                    Console.Clear();

                                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                                    Console.WriteLine("Choose Option To Edit:");
                                                                    Console.WriteLine("1. Username");
                                                                    Console.WriteLine("2. Email");
                                                                    Console.WriteLine("3. Password");
                                                                    Console.WriteLine("4. Role");
                                                                    Console.WriteLine("5. Go Back");

                                                                    Console.Write("\nEnter Action: ");

                                                                    Console.ForegroundColor = ConsoleColor.Green;

                                                                    string editUSerMenuAction = Console.ReadLine();

                                                                    switch (editUSerMenuAction)
                                                                    {
                                                                        case "1":
                                                                            Console.Clear();
                                                                            LoaderService.Spinner(500);
                                                                            Console.Clear();

                                                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                                                            Console.Write("User ID to edit: ");
                                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                                            int id = int.Parse(Console.ReadLine()!);

                                                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                                                            Console.Write("\nNew username: ");

                                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                                            string? newUsername = Console.ReadLine();
                                                                            if (string.IsNullOrWhiteSpace(newUsername)) newUsername = null;

                                                                            var editResult = AdminService.EditUser(id, newUsername, null, null, null)
                                                                                .GetAwaiter()
                                                                                .GetResult();

                                                                            Console.ForegroundColor = editResult.IsSuccess 
                                                                                ? ConsoleColor.Green
                                                                                : ConsoleColor.Red;

                                                                            Console.WriteLine( editResult.Data
                                                                                ? "\nUsername edited successfully."
                                                                                : $"\nUsername edit failed: {editResult.ErrorMessage ?? "Unknown error"}");

                                                                            Console.ResetColor();
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
                                                                            Console.Write("User ID to edit: ");
                                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                                            int id2 = int.Parse(Console.ReadLine()!);

                                                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                                                            Console.Write("\nNew Email: ");

                                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                                            string? newEmail = Console.ReadLine();
                                                                            if (string.IsNullOrWhiteSpace(newEmail)) newEmail = null;

                                                                            var editResult2 = AdminService.EditUser(id2, null, newEmail, null, null)
                                                                                .GetAwaiter()
                                                                                .GetResult();

                                                                            Console.ForegroundColor = editResult2.IsSuccess
                                                                                ? ConsoleColor.Green
                                                                                : ConsoleColor.Red;

                                                                            Console.WriteLine(editResult2.Data
                                                                                ? "\nEmail edited successfully."
                                                                                : $"\nEmail edit failed: {editResult2.ErrorMessage ?? "Unknown error"}");

                                                                            Console.ResetColor();
                                                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                                                            Console.WriteLine("\nPress any key to return to main menu...");
                                                                            Console.ReadKey();
                                                                            Console.ResetColor();
                                                                            break;
                                                                        case "3":
                                                                            Console.Clear();
                                                                            LoaderService.Spinner(500);
                                                                            Console.Clear();

                                                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                                                            Console.Write("User ID to edit: ");
                                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                                            int id3 = int.Parse(Console.ReadLine()!);

                                                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                                                            Console.Write("\nNew Password: ");

                                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                                            string? newPassword = Console.ReadLine();
                                                                            if (string.IsNullOrWhiteSpace(newPassword)) newPassword = null;

                                                                            var HashedEditPassword = hasher.HashPassword(null, newPassword.Trim());

                                                                            var editResult3 = AdminService.EditUser(id3, null, null, HashedEditPassword, null)
                                                                                .GetAwaiter()
                                                                                .GetResult();

                                                                            Console.ForegroundColor = editResult3.IsSuccess
                                                                                ? ConsoleColor.Green
                                                                                : ConsoleColor.Red;

                                                                            Console.WriteLine(editResult3.Data
                                                                                ? "\nPassword edited successfully."
                                                                                : $"\nPassword edit failed: {editResult3.ErrorMessage ?? "Unknown error"}");

                                                                            Console.ResetColor();
                                                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                                                            Console.WriteLine("\nPress any key to return to main menu...");
                                                                            Console.ReadKey();
                                                                            Console.ResetColor();
                                                                            break;
                                                                        case "4":
                                                                            Console.Clear();
                                                                            LoaderService.Spinner(500);
                                                                            Console.Clear();

                                                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                                                            Console.Write("User ID to edit: ");
                                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                                            int id4 = int.Parse(Console.ReadLine()!);

                                                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                                                            Console.Write("\nIs Admin? [Y/N]: ");

                                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                                            string? newRoles = Console.ReadLine();
                                                                            if (string.IsNullOrWhiteSpace(newRoles)) newRoles = null;

                                                                            var editResult4 = AdminService.EditUser(id4, null, null, null, newRoles.Trim().ToLower() == "y" ? true : false)
                                                                                .GetAwaiter()
                                                                                .GetResult();

                                                                            Console.ForegroundColor = editResult4.IsSuccess
                                                                                ? ConsoleColor.Green
                                                                                : ConsoleColor.Red;

                                                                            Console.WriteLine(editResult4.Data
                                                                                ? "\nRole edited successfully."
                                                                                : $"\nRole edit failed: {editResult4.ErrorMessage ?? "Unknown error"}");

                                                                            Console.ResetColor();
                                                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                                                            Console.WriteLine("\nPress any key to return to main menu...");
                                                                            Console.ReadKey();
                                                                            Console.ResetColor();
                                                                            break;
                                                                        case "5":
                                                                            editUserMenu = false;
                                                                            break;
                                                                        default:
                                                                            editUserMenu = false;
                                                                            break;
                                                                    }
                                                                }
                                                                break;
                                                            case "4":
                                                                Console.Clear();
                                                                LoaderService.Spinner(500);
                                                                Console.Clear();

                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.Write("Enter User ID: ");

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
                        }
                        else
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
                            break;
                        }

                        if (Regpassword.Length < 8 && Regpassword2.Length < 8)
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


                            break;
                        }

                        var HashedPassword = hasher.HashPassword(null, Regpassword.Trim());

                        var regRes = RegisterService
                                     .Register(RegUsername!, RegEmail!, HashedPassword)
                                     .GetAwaiter()
                                     .GetResult();

                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(regRes.IsSuccess && regRes.Data
                            ? "Registration Successful"
                            : $"Registration Failed: {regRes.ErrorMessage ?? "Unknown error"}");

                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.WriteLine("\nPress any key to return to main menu...");
                        Console.ReadKey();

                        Console.ResetColor();
                        break;
                    case "3":
                        Console.Clear();
                        LoaderService.Spinner(500);
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
                        string RecEmail = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(RecEmail))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nE-mail can’t be empty");
                            Console.ResetColor();
                            break;
                        }


                        Console.ResetColor();

                        var AdminService3 = new AdminService();

                        var UserInfoForRec = AdminService3.GetAllUsers();

                        var CurrentRecUser = UserInfoForRec.Data.FirstOrDefault(u => u.Email.ToLower().Equals(RecEmail.ToLower(), StringComparison.OrdinalIgnoreCase));
                        
                        if (CurrentRecUser != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("\nPassword: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string Recpassword = Console.ReadLine();

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("\nRepeat Password: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string Recpassword2 = Console.ReadLine();

                            if (Recpassword.Trim() != Recpassword2.Trim())
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
                                break;
                            }

                            if (Recpassword.Length < 8 && Recpassword2.Length < 8)
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


                                break;
                            }

                            var HashedRecoveryPassword = hasher.HashPassword(null, Recpassword.Trim());

                            var RecResult3 = AdminService3.EditUser(CurrentRecUser.UserId, null, null, HashedRecoveryPassword, null)
                                .GetAwaiter()
                                .GetResult();

                            Console.ForegroundColor = RecResult3.IsSuccess
                                ? ConsoleColor.Green
                                : ConsoleColor.Red;

                            Console.WriteLine(RecResult3.Data
                                ? "\nPassword recovered successfully."
                                : $"\nPassword recover failed: {RecResult3.ErrorMessage ?? "Unknown error"}");


                            Console.ForegroundColor = ConsoleColor.Yellow;

                            Console.WriteLine("\nPress any key to return to main menu...");
                            Console.ReadKey();

                            Console.ResetColor();
                        }
                        break;
                    case "4":
                        run = false;
                        break;

                    default:
                        run = false;
                        break;
                }
            }
        }
    }
}
