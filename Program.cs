// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

class LogIn
{
    public static String setPassword()
    {

        Console.WriteLine("\nSet a Password");
        while (true)
        {
            bool isValid = false;
            Console.WriteLine("\nInput your new Password");
            String input1 = Console.ReadLine();
            Console.WriteLine("Repeat Inputted Password");
            String input2 = Console.ReadLine();

            // prashant_srivastava
            string regex = "^(?=.*[a-z])(?=." + "*[A-Z])(?=.*\\d)" + "(?=.*[-+_!@#$%^&*., ?]).+$";
            Regex p = new Regex(regex);
            Match m = p.Match(input1);
            if (m.Success)
            {
                isValid = true;
            }
            //

            if (input1 != input2)
            {
                Console.WriteLine("Repeated Password does not match first input,\nplease re-enter your chosen Password");
            }
            else if (input1.Length < 8)
            {
                Console.WriteLine("Password must be 8 characters or longer");
            }
            else if (!isValid)
            {
                Console.WriteLine("Password must contain uppercase, lowercase, number, and symbol");
            }
            else
            {
                Console.WriteLine("Password Changed");
                return input1;
            }
        }

    }
    public static bool loginSection(String password, String email)
    {
        bool loggedIn = false;
        int loginAttempts = 3;

        Console.WriteLine("\n -------------------\n |\tLogin\t   |\n -------------------");
        while (!loggedIn && loginAttempts > 0)
        {
            Console.WriteLine("\nEnter Password:");
            String attempt = Console.ReadLine();
            if (attempt == password)
            {
                Console.WriteLine("User Logged In");
                loggedIn = true;
            }
            else if (attempt == "/reset")
            {
                password = resetPassword(password, email);
                loginAttempts = 3;
            }
            else
            {
                loginAttempts -= 1;
                Console.WriteLine("Incorrect Password");
                Console.WriteLine("Attempts Remaining: " + loginAttempts);
            }
        }
        if (loginAttempts == 0)
        {
            Console.WriteLine("Login Attempt Failed");

        }
        return loggedIn;
    }

    public static String resetPassword(String currentPassword, String userEmail)
    {
        Console.WriteLine("Enter your email:");
        String emailInput = Console.ReadLine();
        if (userEmail == emailInput)
        {
            return setPassword();
        }
        else
        {
            Console.WriteLine("Email does not Match given Email, please check your inbox for further information");
            return currentPassword;
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        //String currentPassword = null;
        String currentPassword = "password";
        String email = "johndoe@gmail.com";

        if (currentPassword == null)
        {
            currentPassword = LogIn.setPassword();
        }
        bool logStatus = LogIn.loginSection(currentPassword, email);

        if (logStatus)
        {
            Console.WriteLine("\n\n[Insert Program]");

        }

        Console.ReadLine();
    }
}


