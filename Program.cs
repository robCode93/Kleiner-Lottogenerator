using Zahlen_Raten;

// Vars for the Programm
int[] myNumbers;
int start, end, counter, numberAdd;
TestingClass tester = new TestingClass();
decimal priceForOneTip;
decimal spendingMoney;
int weeks, months, years, perWeek;


Console.WriteLine("---------------------------------------------");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Der ultimative Glücksspiel-Generator");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("---------------------------------------------");
Console.WriteLine();
Console.Write("Preis pro Tipp: ");
priceForOneTip = Convert.ToDecimal(Console.ReadLine());
Console.Write("Wie oft pro Woche wird gespielt: ");
perWeek = Convert.ToInt32(Console.ReadLine());
Console.Write("Welche Zahl soll als Minimum gesetzt werden: ");
start = Convert.ToInt32(Console.ReadLine());
Console.Write("Welche Zahl soll als Maximum gesetzt werden: ");
end = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();
Console.Write("Wie viele Zahlen möchtest du testen: ");

myNumbers = tester.produceArray(Convert.ToInt32(Console.ReadLine()));

for (int i = 0; i < myNumbers.Length; i++)
{
    Console.Write("[{0}. Zahl]: ", i+1);
    numberAdd = Convert.ToInt32(Console.ReadLine());

    if (numberAdd >= start && numberAdd <= end)
    {
        if (Array.Exists(myNumbers, x => x == numberAdd))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("FEHLER! Keine Doppelten Zahlen verwenden...");
            Console.ForegroundColor = ConsoleColor.White;
            i--;
        }
        else
        {
            myNumbers[i] = numberAdd;
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("FEHLER! Zahl muss im angegebenen Bereich liegen! [START: {0} | END: {1}]", start, end);
        Console.ForegroundColor = ConsoleColor.White;
        i--;
    }

}

counter = tester.startLoop(start, end, myNumbers);
spendingMoney = priceForOneTip * counter;
weeks = counter / perWeek;
months = weeks / 4;
years = months / 12;

Console.WriteLine("----------------------------------------");
Console.WriteLine("Benöigte Versuche: {0}", counter);
Console.WriteLine("----------------------------------------");
Console.WriteLine("Preis pro Tipp: {0}", priceForOneTip);
Console.WriteLine("Ausgegeben bis Hauptgewinn: {0}", spendingMoney);
Console.WriteLine("Dauer bei {0} Ziehungen pro Woche: ", perWeek);
Console.WriteLine("Wochen: {0}", weeks);
Console.WriteLine("Monate: {0}", months);
Console.WriteLine("Jahre: {0}", years);

