// See https://aka.ms/new-console-template for more information

Console.ForegroundColor = ConsoleColor.White;
Console.Write("Please insert a string you would like to process: ");
string userInputString = Console.ReadLine();

int counter = 0;
long sumOfAllSubstrings = 0;
List<(string, int, int)> listOfSubstringsAndStartStopIndex = new List<(string, int, int)>();



foreach (char c in userInputString)
{
    CheckForSubStrings(c);
    counter++;
}



foreach ((string, int, int) substring in listOfSubstringsAndStartStopIndex)
{
    if (IsCharsNumbersOnly(substring.Item1) == true)
    {
        if (AreNumbersRepeated(substring.Item1) == false)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(userInputString.Substring(0, substring.Item2));

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(substring.Item1);

            Console.ForegroundColor = ConsoleColor.White;

            if (substring.Item3 < userInputString.Length - 1)
            {
                Console.Write(userInputString.Substring(substring.Item3 + substring.Item2));
            }
            Console.WriteLine();

            sumOfAllSubstrings = sumOfAllSubstrings += Convert.ToInt64(substring.Item1);
        }
    }

}
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("The sum of all marked substrings is: " + sumOfAllSubstrings);








void CheckForSubStrings(char charToCheck)
{
    for (int i = counter + 1; i < userInputString.Length; i++)
    {
        if (charToCheck == userInputString[i])
        {
            int substringStart = counter;
            int substringEnd = i + 1 - counter;

            string substrings = userInputString.Substring(substringStart, substringEnd);

            (string, int, int) substringWithStartStopIndex = (substrings, substringStart, substringEnd);

            listOfSubstringsAndStartStopIndex.Add(substringWithStartStopIndex);
        }
    }
}




static bool AreNumbersRepeated(string checkIfRepeated)
{
    bool isRepeated = false;
    string repeatedWord = checkIfRepeated;
    for (int i = 0; i < repeatedWord.Count() - 2; i++)
    {
        if (repeatedWord[0] == repeatedWord[i + 1])
        {
            isRepeated = true;
        }
    }
    return isRepeated;
}

static bool IsCharsNumbersOnly(string checkIfNumber)
{
    long n;
    bool isNumeric = long.TryParse(checkIfNumber, out n);
    return isNumeric;
}
