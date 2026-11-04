using Blackjack;
using System.Xml.Serialization;

Console.WriteLine("---Magic Turtels---");
Console.WriteLine();
while(true)
{
    Console.WriteLine("============= Black Jack ============================================");
    Console.Write("1: Spela ");
    Console.Write("2: Topplista ");
    Console.Write("3: Regler ");
    Console.Write("4: Avsluta ");
    Console.WriteLine();
    Console.Write("Välj ett alternativ 1-4: ");
    string choice = Console.ReadLine() ??""; 






    
    if(choice == "1") // Val 1 i menyn Spela
    {

    }
    //------------1: Spela slut här----------------





    else if(choice == "2") // Val 2 menyn Topplista
    {

    }
    //-----------2: Topplista slutar här-----------




    else if(choice == "3") // Val 3 i menyn Regler
    {
        Console.WriteLine();
        Console.WriteLine("============= Regler ================================================");
        Console.WriteLine("Målet: Kom så nära 21 poäng som möjligt utan att gå över. ");
        Console.WriteLine("Du spelar mot dealern (banken).");
        Console.WriteLine();
        Console.WriteLine("       Situation          |       Resultat");
        Console.WriteLine("---------------------------------------------------------------------");
        Console.WriteLine("Du har 20, dealern 18     |       Du vinner");
        Console.WriteLine("Du har 18, dealern 20     |       Dealern vinner ");
        Console.WriteLine("Du har 19, dealern 19     |       Oavgjort");
        Console.WriteLine("Du får över 21            |       Du förlorar");
        Console.WriteLine("Dealern får över 21       |       Du vinner om du inte redan förlorat"); 
        Console.WriteLine("Ess + 10 första två kort  |       Blackjack");
        Console.WriteLine("---------------------------------------------------------------------");
        Console.WriteLine("Dealern måste normalt dra kort tills den har minst 17 poäng.");
        Console.WriteLine("När du stannar spelar dealern sin tur.");
        Console.WriteLine("Om du får över 21 förlorar du direkt.");
        Console.WriteLine("");
        Console.WriteLine("Du väljer mellan:");
        Console.WriteLine("Hit (Ta kort): Dra ytterligare ett kort.");
        Console.WriteLine("Stand (Stanna): Behåll dina poäng.");
        Console.WriteLine("Du och dealern får två kort var.");
        Console.WriteLine("Ess: 1 eller 11 poäng, beroende på vad som är bäst för handen.");
        Console.WriteLine("Knekt, dam, kung: 10 poäng.");
        Console.WriteLine("2–10: Kortets värde.");
        Console.WriteLine("");
        Console.WriteLine("");
    }
    //---------3: Regler Slutar här----------------




    else if(choice == "4") // Val 4 i menyn Avsluta
    {
        break;
    }
    //----------4: Avsluta slutar här--------------



        
}  // Här Slutar while Loopen!
