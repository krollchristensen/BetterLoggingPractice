using System;
using System.IO;
/*
 * I dette eksempel vil jeg introducere en simpel logningsstruktur med niveauer (INFO, WARN, og ERROR)
 * for at vise, hvordan du kan differentiere mellem forskellige typer af logmeddelelser. 
 * Jeg vil dog undlade at anvende et avanceret logging framework som NLog eller log4net for at 
 * holde eksemplet enkelt, men det er værd at overveje i rigtige applikationer.
 */
class BetterLoggingPractice
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter username:");
        string username = Console.ReadLine();

        Console.WriteLine("Enter password:");
        // Bed om password, men log ikke denne handling for at beskytte følsomme data
        Console.ReadLine();

        if (!string.IsNullOrEmpty(username))
        {
            Log($"User login attempt: {username}", "INFO");

            // Antag, at valideringen lykkes uden at logge det faktiske password
            Log($"User {username} logged in successfully.", "INFO");

            // Eksempel på handlinger uden overlogging
            PerformUserAction(username, "A");
        }
        else
        {
            Log("Login attempt failed due to empty username or password.", "WARN");
        }
    }

    static void PerformUserAction(string username, string action)
    {
        // Simulerer en brugerhandling uden overlogging
        Log($"User {username} performed action {action}.", "INFO");
    }

    static void Log(string message, string level)
    {
        // Forbedret og mere struktureret logformat
        string formattedMessage = $"{DateTime.Now} [{level}]: {message}";
        Console.WriteLine(formattedMessage); // For demonstration, skriver vi også til konsollen
        File.AppendAllText("applog.txt", formattedMessage + Environment.NewLine);
    }
}
