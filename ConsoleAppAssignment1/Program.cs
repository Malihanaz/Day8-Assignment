using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class TextAnalyzer
{
    static void Main()
    {
        // User Input
        Console.Write("Enter a piece of text: ");
        string userInput = Console.ReadLine();

        // Word Count
        int wordCount = CountWords(userInput);

        // Email Validation
        List<string> emailAddresses = ValidateEmail(userInput);

        // Mobile Number Extraction
        List<string> mobileNumbers = ExtractMobileNumbers(userInput);

        // Custom Regex Search
        Console.Write("Enter custom regex pattern: ");
        string customRegexPattern = Console.ReadLine();
        List<string> customRegexResults = CustomRegexSearch(userInput, customRegexPattern);

        // Display Results
        Console.WriteLine($"Word Count: {wordCount}");
        Console.WriteLine("Email Addresses: " + string.Join(", ", emailAddresses));
        Console.WriteLine("Mobile Numbers: " + string.Join(", ", mobileNumbers));
        Console.WriteLine("Custom Regex Search Results: " + string.Join(", ", customRegexResults));
    }

    static int CountWords(string text)
    {
        string[] words = text.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }

    static List<string> ValidateEmail(string text)
    {
        string emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
        MatchCollection matches = Regex.Matches(text, emailPattern);
        List<string> emails = new List<string>();

        foreach (Match match in matches)
        {
            emails.Add(match.Value);
        }

        return emails;
    }

    static List<string> ExtractMobileNumbers(string text)
    {
        string phonePattern = @"\b\d{10}\b";
        MatchCollection matches = Regex.Matches(text, phonePattern);
        List<string> numbers = new List<string>();

        foreach (Match match in matches)
        {
            numbers.Add(match.Value);
        }

        return numbers;
    }

    static List<string> CustomRegexSearch(string text, string regexPattern)
    {
        MatchCollection matches = Regex.Matches(text, regexPattern);
        List<string> results = new List<string>();

        foreach (Match match in matches)
        {
            results.Add(match.Value);
        }

        return results;
    }
}
