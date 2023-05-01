using System.Text;
using System.Text.RegularExpressions;

internal class Program
{
    public const int MODUL_97 = 97;

    static void Main(string[] args)
    {

        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("Моля въведете IBAN за проверка: ");
        string IBAN = Console.ReadLine().Replace(" ", "");
        bool isValid = IBANvalidator(IBAN);
        Console.WriteLine("Вашият IBAN е: " + (isValid == true ? "Валиден" : "Невалиден"));

    }

    static bool IBANvalidator(string IBAN)
    {
        if (RegexValidation(IBAN) && ControlNumberValidation(IBAN)) { return true; }
        else return false;
    }
    static bool ControlNumberValidation(string IBAN)
    {
        int controlNumber = ControlNumberCalculator(IBAN);
        IBAN = IBAN.Remove(2, 2).Insert(2, controlNumber.ToString());
        bool isValid = ControlNumberValidityCheck(IBAN);
        return true;
    }

    static int ControlNumberCalculator(string IBAN)
    {
        string modifiedIBAN = SendToBackFirstFourLetters(IBAN);
        string IBANasNumbers = TranslateIBANtoNumbers(modifiedIBAN);
        int remainder = BigNumberRemainderCalculator(IBANasNumbers, MODUL_97);
        int subtraction = 98 - remainder;
        return subtraction;
    }

    static bool ControlNumberValidityCheck(string IBAN)
    {
        string modifiedIBAN = SendToBackFirstFourLetters(IBAN);
        string IBANasNumbers = TranslateIBANtoNumbers(modifiedIBAN);
        int remainder = BigNumberRemainderCalculator(IBANasNumbers, MODUL_97);
        if (remainder == 1)
        {
            return true;
        }
        return false;
    }

    static bool RegexValidation(string IBAN)
    {
        string pattern = @"^(BG\d{2}[A-Z0-9]{4}\d{4}\d{2}[A-Z0-9]{8})$";
        var match = Regex.Match(IBAN, pattern);
        if (match.Success)
        {
            return true;
        }

        return false;
    }
    static int BigNumberRemainderCalculator(string numberAsString, int m)
    {
        int reminder = 0;
        for (int i = 0; i < numberAsString.Length; i++)
        {
            int digit = numberAsString[i] - '0';
            reminder = (reminder * 10 + digit) % m;
        }
        return reminder;
    }

    static string TranslateIBANtoNumbers(string input)
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];
            if ((int)currentChar > 64 && (int)currentChar < 90)
            {
                result.Append((int)input[i] - 55);
            }
            else
            {
                result.Append(currentChar);
            }
        }

        return result.ToString();
    }

    static string SendToBackFirstFourLetters(string input)
    {
        string firstFour = input.Substring(0, 4);
        input = input.Remove(0, 4);
        input += firstFour;
        return input;
    }
}
