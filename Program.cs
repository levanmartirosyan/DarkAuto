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
            Console.WriteLine("Welcome To DarkAuto!");

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
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Enter Credentials");

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

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Welcome - {LogInRes.Data.UserName} [{(LogInRes.Data.IsAdmin ? "Admin" : "User")}]");
                            Console.ResetColor();

                            string logoutOption = LogInRes.Data.IsAdmin ? "8" : "9";

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nChoose Action:");
                            Console.WriteLine("1. All Cars");
                            Console.WriteLine("2. Available Cars");
                            Console.WriteLine("3. Delivery Companies");
                            Console.WriteLine("4. Our Locations");
                            Console.WriteLine("5. My Cars");
                            Console.WriteLine("6. My Deliveries");
                            Console.WriteLine("7. Settings");
                            if (LogInRes.Data.IsAdmin)
                            {
                                Console.WriteLine("\n8. Admin Panel\n");
                            }
                            Console.WriteLine($"{logoutOption}. Log Out");

                            Console.WriteLine("\nEnter Action:");

                            Console.ForegroundColor = ConsoleColor.Green;
                            string? authActions = Console.ReadLine();

                            Console.ResetColor();

                            
                            switch (authActions)
                            {
                                case "1":
        
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid Credentials!");

                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.WriteLine("\nPress any key to return to main menu...");
                        Console.ReadKey();

                        Console.ResetColor();

                    }


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
