using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadi_Homework
{
    public class HomeWork1
    {
        public static void Homework()
        {
            DataBase db = new DataBase();
            db.CheckFile();

            bool whileLoop = true;
            int userCount = 1;
            Console.WriteLine("Hello, please enter your name");
            string userName = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Hi ");

            while (whileLoop)
            {
                Console.WriteLine($"{userName} What do you want to do?");
                Console.WriteLine("1: See the list of Users");
                Console.WriteLine("2: Add a new user to the list");
                Console.WriteLine("3: Update User");
                Console.WriteLine("4: Delete User");
                Console.WriteLine("5: Close the application");

                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        ShowList();
                        break;
                    case "2":
                        AddUsers(userCount);
                        userCount++;
                        break;
                    case "3":
                        ShowList();
                        UpdateUser();
                        break;
                    case "4":
                        ShowList();
                        DeleteUser();
                        break;
                    case "5":
                        whileLoop = false;
                        break;
                    default:
                        Console.WriteLine("Error . Please enter a valid option.");
                        Console.WriteLine("");
                        break;
                }
            }
        }

        public static void ShowList()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("List of the Users:");
            DataBase data = new DataBase();
            List<User> users = data.ReadFile();

            if (users != null && users.Count > 0)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    User user = users[i];
                    Console.WriteLine($"User{user.Id}: User ID : {user.Id} Name : {user.Name}, Age : {user.Age}, Nationakity : {user.Nationality}, Gender : {user.Gender}");
                }
            }
            else
            {
                Console.WriteLine("No users found.");
            }

            Console.WriteLine("-------------------------------");
        }

        public static void AddUsers(int userCount)
        {

            User user = new User();
            Console.WriteLine($"Enter the information for User{userCount}:");

            Console.WriteLine("Enter the name:");
            user.Name = Console.ReadLine();

            Console.WriteLine("Enter the age:");
            bool ageCheck = true;
            while (ageCheck)
            {
                string userUnput = Console.ReadLine();
                int age = 0;
                try
                {
                    age = int.Parse(userUnput);

                    if (age > 0)
                    {
                        ageCheck = false;
                    }
                    else
                    {
                        Console.WriteLine("There is an Error, Please enter a valid Number.");
                        Console.WriteLine("");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error. Please enter a valid Number.");
                    Console.WriteLine("");
                }
            }

            Console.WriteLine("Enter the Nationality:");
            bool nationalityCheck = true;
            while (nationalityCheck)
            {
                List<string> nationalities = new List<string> { "Jordanian", "American", "British", "Canadian", "French", "German", "Italian", "Japanese", "Mexican", "Russian", "Australian" };

                Console.WriteLine("Choose your Nationalities:");

                for (int i = 0; i < nationalities.Count; i++)
                {
                    Console.WriteLine($"{i + 1} : {nationalities[i]}");
                }
                string userChoose = Console.ReadLine();
                switch (userChoose)
                {
                    case "1":
                        user.Nationality = nationalities[0];
                        nationalityCheck = false;
                        break;
                    case "2":
                        user.Nationality = nationalities[1];
                        nationalityCheck = false;
                        break;
                    case "3":
                        user.Nationality = nationalities[2];
                        nationalityCheck = false;
                        break;
                    case "4":
                        user.Nationality = nationalities[3];
                        nationalityCheck = false;
                        break;
                    case "5":
                        user.Nationality = nationalities[4];
                        nationalityCheck = false;
                        break;
                    case "6":
                        user.Nationality = nationalities[5];
                        nationalityCheck = false;
                        break;
                    case "7":
                        user.Nationality = nationalities[6];
                        nationalityCheck = false;
                        break;
                    case "8":
                        user.Nationality = nationalities[7];
                        nationalityCheck = false;
                        break;
                    case "9":
                        user.Nationality = nationalities[8];
                        nationalityCheck = false;
                        break;
                    case "10":
                        user.Nationality = nationalities[9];
                        nationalityCheck = false;
                        break;
                    case "11":
                        user.Nationality = nationalities[10];
                        nationalityCheck = false;
                        break;
                    default:
                        Console.WriteLine("please enter a vaild option");
                        break;
                }
            }

            bool genderCheck = true;
            while (genderCheck)
            {
                Console.WriteLine("Enter the Gender 1: Male, 2: Female:");
                int genderChoice = Convert.ToInt32(Console.ReadLine());

                switch (genderChoice)
                {
                    case 1:
                        user.Gender = "Male";
                        genderCheck = false;
                        break;
                    case 2:
                        user.Gender = "Female";
                        genderCheck = false;
                        break;
                    default:
                        Console.WriteLine("Invalid gender choice. Defaulting to 'Other'.");
                        user.Gender = "Other";
                        break;
                }
            }

            Console.WriteLine("");
            DataBase db = new DataBase();
            db.AddData(user);
        }

        public static void DeleteUser()
        {
            bool checkId = true;
            while (checkId)
            {
                Console.WriteLine("Enter the ID of the user you want to delete:");
                string userId = Console.ReadLine();
                DataBase db = new DataBase();
                List<User> users = db.ReadFile();
                User userToDelete = null;
                int userid;
                try
                {
                    userid = int.Parse(userId);
                    foreach (User user in users)
                    {
                        if (user.Id == userid)
                        {
                            userToDelete = user;
                            break;
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error. Please enter a valid ID.");
                    Console.WriteLine("");
                }

                if (userToDelete != null)
                {
                    users.Remove(userToDelete);
                    db.UpdateData(users);
                    Console.WriteLine($"User {userId} has been deleted");
                    checkId = false;
                }
            }
        }

        public static void UpdateUser()
        {
            bool checkId = true;
            while (checkId)
            {
                Console.WriteLine("Enter the ID for the user that you want to update:");
                string userId = Console.ReadLine();
                DataBase db = new DataBase();
                List<User> users = db.ReadFile();
                User userToUpdate = null;
                int userid;
                try
                {
                    userid = int.Parse(userId);
                    foreach (User user in users)
                    {
                        if (user.Id == userid)
                        {
                            userToUpdate = user;
                            break;
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error. Please enter a valid ID.");
                    Console.WriteLine("");
                }
                if (userToUpdate != null)
                {
                    Console.WriteLine($"Enter the information for the User");

                    Console.WriteLine("Enter the name:");
                    userToUpdate.Name = Console.ReadLine();

                    Console.WriteLine("Enter the age:");
                    bool ageCheck = true;
                    while (ageCheck)
                    {
                        string userUnput = Console.ReadLine();
                        int age = 0;
                        try
                        {
                            age = int.Parse(userUnput);

                            if (age > 0)
                            {
                                ageCheck = false;
                            }
                            else
                            {
                                Console.WriteLine("There is an Error, Please enter a valid Number.");
                                Console.WriteLine("");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error. Please enter a valid Number.");
                            Console.WriteLine("");
                        }
                    }

                    Console.WriteLine("Enter the Nationality:");
                    bool nationalityCheck = true;
                    while (nationalityCheck)
                    {
                        List<string> nationalities = new List<string> { "Jordanian", "American", "British", "Canadian", "French", "German", "Italian", "Japanese", "Mexican", "Russian", "Australian" };

                        Console.WriteLine("Choose your Nationalities:");

                        for (int i = 0; i < nationalities.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} : {nationalities[i]}");
                        }
                        string userChoose = Console.ReadLine();
                        switch (userChoose)
                        {
                            case "1":
                                userToUpdate.Nationality = nationalities[0];
                                nationalityCheck = false;
                                break;
                            case "2":
                                userToUpdate.Nationality = nationalities[1];
                                nationalityCheck = false;
                                break;
                            case "3":
                                userToUpdate.Nationality = nationalities[2];
                                nationalityCheck = false;
                                break;
                            case "4":
                                userToUpdate.Nationality = nationalities[3];
                                nationalityCheck = false;
                                break;
                            case "5":
                                userToUpdate.Nationality = nationalities[4];
                                nationalityCheck = false;
                                break;
                            case "6":
                                userToUpdate.Nationality = nationalities[5];
                                nationalityCheck = false;
                                break;
                            case "7":
                                userToUpdate.Nationality = nationalities[6];
                                nationalityCheck = false;
                                break;
                            case "8":
                                userToUpdate.Nationality = nationalities[7];
                                nationalityCheck = false;
                                break;
                            case "9":
                                userToUpdate.Nationality = nationalities[8];
                                nationalityCheck = false;
                                break;
                            case "10":
                                userToUpdate.Nationality = nationalities[9];
                                nationalityCheck = false;
                                break;
                            case "11":
                                userToUpdate.Nationality = nationalities[10];
                                nationalityCheck = false;
                                break;
                            default:
                                Console.WriteLine("please enter a vaild option");
                                break;
                        }
                    }
                    Console.WriteLine("");
                    bool genderCheck = true;
                    while (genderCheck)
                    {
                        Console.WriteLine("Enter the Gender 1: Male, 2: Female:");
                        int genderChoice = Convert.ToInt32(Console.ReadLine());

                        switch (genderChoice)
                        {
                            case 1:
                                userToUpdate.Gender = "Male";
                                genderCheck = false;
                                break;
                            case 2:
                                userToUpdate.Gender = "Female";
                                genderCheck = false;
                                break;
                            default:
                                Console.WriteLine("Invalid gender choice. Defaulting to 'Other'.");
                                userToUpdate.Gender = "Other";
                                break;
                        }
                    }
                    db.UpdateData(users);

                    Console.WriteLine($"User {userId} has been updated successfully.");
                }
            }
        }
    }
}
