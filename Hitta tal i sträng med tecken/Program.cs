using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Hitta_tal_i_sträng_med_tecken
{
    class Program
    {

        //Kommenterat kod längre ner, det går att ta bort hela och bara köra den som ligger under, allt ligger med som t.ex. using, etc.. men är mer klottrad pga så många kommentarer. 
        
         static void Main(string[] args)
        {

            string text = "29535123p48723487597645723645"; // Original text (Fungerar med alla texter)
            char value; 
            int valueIndex1 = 0; 
            int valueIndex2 = 0; 
            string substring = ""; 
            int indexOf = 0; 
            long countingSubstrings = 0; 


            // Loop 1: 
            for (int i = 0; i < text.Length; i++)
            {

                if (!char.IsDigit(text[i]))
                {
                    continue; 
                }
                else
                {
                    valueIndex1 = i; 
                    value = text[i]; 
                }


                // Loop 2:
                for (int j = valueIndex1 + 1; j < text.Length; j++) 

                {
                    
                    if (!char.IsDigit(text[j]))
                    {
                        break; 
                    }
                    else if (text[i] == text[j]) 
                    {
                        valueIndex2 = j; 
                        indexOf = text.IndexOf(value, valueIndex1+1); 
                        indexOf -= valueIndex1;
                        substring = text.Substring(valueIndex1, indexOf + 1);
                        countingSubstrings += long.Parse(substring);

                        string firststring = text.Substring(0, valueIndex1);
                        string secondstring = text.Substring(valueIndex2 + 1);

                        Console.Write(firststring);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(substring);
                        Console.ResetColor();
                        Console.Write(secondstring);
                        Console.WriteLine();                  
                        break;

                    }
                }                            
            }
            Console.WriteLine();
            Console.WriteLine("Totalen av alla substring: " + countingSubstrings);

        }

    }

}


/*
using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Hitta_tal_i_sträng_med_tecken
{
    class Program
    {

        static void Main(string[] args)
        {
            string text = "29535123p48723487597645723645"; // Original text (Fungerar med alla texter)

            char value; // Value sparar siffran som den håller på undersöka
            int valueIndex1 = 0; // Sparar första indexet för första loopen, bättre förklaring längre ner
            int valueIndex2 = 0; // Sparar andra indexet för andra loopen, bättre förklaring längre ner
            string substring = ""; // Sparar delsträngen som den hittar, t.ex. 535 
            int indexOf = 0; // Används tills slut för att hitta längden för vår substring.
            long countingSubstrings = 0; // Räknar alla våra substring och plussar ihop dem.


            //Första loopen:

            for (int i = 0; i < text.Length; i++) // Nästan helt automatiskt genererad kodsnippet, men använder text.Length som sin längd parameter.
            {

                // Vår if sats, letar efter en bokstav så att den kan skippa den och fortsätta i loopen. 
                // Vi använder oss utav en char.IsDigit metod som egentligen ska kolla så att det är en siffra
                // men vi inverterar metoden med ett utropstecken och kollar istället när det inte är en siffra.

                if (!char.IsDigit(text[i]))
                {
                    continue; // När den hittar en bokstav så säger vi till programmet att bara hoppa över det och fortsätta loopen på nästa varv.
                }

                // Om det inte var en bokstav så hamnar vi här, där den helt enkelt sparar (i) - vår räknare i en
                // valueIndex1 för enklare läsbarhet och samtidigt så sparar vi siffran som den står på, första gången i varvet
                // så sparas det en 0 på valueIndex1 och en 2 i value, pga att den går in på index 0 och tar ut 2an därifrån.
                // Skriver ut det framför variablerna för enklare läsning.
                else
                {
                    valueIndex1 = i; // 0 (Första gången i varvet)
                    value = text[i]; // 2 (Första gången i varvet)
                }


                //Andra loopen:
                // Vi använder oss utav variabeln j den här gången. Startar på valueIndex1 + 1 (0 + 1) = 1. Första gången i varvet.
                // Anledningen till att vi inte startar på 0 är att den kommer gå och kolla på 2an igen vilket är onödigt, vi vill
                // att den ska fortsätta med nästa nummer (9)[1]. Sedan så kör vi samma sak och kollar på text.Length som förra gången.

                //Loop nr 2: Går igenom bokstäverna 2953512.... Börjar på 9, går vidare på 5, sedan till 3, medans loop nummer 1 håller kvar på nr 2 för att jämföra med.
                for (int j = valueIndex1 + 1; j < text.Length; j++)

                {
                    // Precis som förra gången så letar vi efter en bokstav igen, den här gången så letar vi i loop nr 2(j).
                    if (!char.IsDigit(text[j]))
                    {
                        break; // Skillnaden är att vi hoppar ut från loop nr 2 och fortsätter på loop nr 1 om vi hittar en bokstav. 
                    }
                    else if (text[i] == text[j]) // Nu letar vi efter en matchning, en 2 ska matcha 2 och den ska heller inte avbrytas pga en bokstav/char, etc..
                    {

                        valueIndex2 = j; // Vi sparar variabeln j för enklare läsbarhet.

                        // Indexof metod på text. Den tar value(2) som parameter, där anger vi vilken char vi letar efter, i vårt fall är det en 2a (valueIndex1 = [0])
                        // Sedan så anger vi start positionen där den ska börja leta efter en 2, vilket är positionen på vår första tvåa + 1 [1]. 
                        indexOf = text.IndexOf(value, valueIndex1 + 1);
                                                                                                           //0123456
                        // Sedan så går vi tillbaka till indexOf variabeln för att den är då satt som en 6, (2953512), men vår substring tar Length som nästa parameter så vi måste
                        // ta bort startvärdet alltså 6-0 = 6, vilket i första varvet inte är så förklarigt men.. senare så på 535 så är första valueIndex på 2 och nästa på 4..
                        // för att vi har sparat värdet på andra värdet utav värdet 5 så börjar vi där och tar bort valueIndex1 vilket är första indexet.. vilket är 2. 
                        // Så för 535 exemplet blir det 4 - 2 = 2 -- indexOf har nu en 2åa.
                        indexOf -= valueIndex1;

                        // Sen så använder vi vår substring variabel och delar upp värdet som vi är intresserad utav. Vi tar då i substring metoden att vi vill starta på valueIndex1 och
                        // vi anger att längden är indexOf + 1. Så indexof innehöll en 2a, vilket betyder att den ska flytta sig 2 steg frammåt i vår 535 exempel, + 1 behöver vi lägga till 
                        // så att den inkluderar 5an också annars tar den bara "53".
                        substring = text.Substring(valueIndex1, indexOf + 1);

                        // Vi använder en countingSubstring variabel och lägger till alla värden som substring tar ut med en parse funktion för att omvandla string strängen till siffror.
                        countingSubstrings += long.Parse(substring);

                        // Vi skapar 2 nya variabeler för enklare läsbarhet, det skulle kunna gå att skriva ut det i Console.Write(direkt) men jag föredrog att ha dem i variabler först.
                        // firstString börjar alltid på 0 och går så många steg som valueIndex1 är, i första exemplet så går den bara 0 steg.
                        // secondString börjar istället på valueIndex2, i vårt första varv börjar den på 6 men vi vill inte inkludera den så vi hoppar fram ett steg och börjar på index 7.
                        string firstString = text.Substring(0, valueIndex1);
                        string secondString = text.Substring(valueIndex2 + 1);

                        Console.Write(firstString); // Vi skriver ut delsträngen (Första varvet skrivs inget ut). Annars skrivs allt innan substringen ut.
                        Console.ForegroundColor = ConsoleColor.DarkRed; // Vi byter nu färg för att vi vill skriva ut substringen härnäst.
                        Console.Write(substring); // Vi kör en write så att allt hamnar på samma rad och skriver ut vår substring.
                        Console.ResetColor(); // Återställning av färgen så att vår secondstring inte skrivs ut i röd färg också.
                        Console.Write(secondString); // Sedan så skriver vi bara ut slutet av strängen som är kvar.
                        Console.WriteLine(); // Vi gör en tom rad för nästa gång den ska loopa om för nästa siffror så att det hamnar på nästa rad.

                        break; // Vi avslutar vår andra loop efter att vi har hittat, delat och skrivit ut siffrorna vi är intresserade utav och fortsätter med nästa siffra. 

                    }

                }

            }

            Console.WriteLine(); // Vi gör bara en tom rad innan vi skriver ut vår total.
            Console.WriteLine("Totalen av alla substring: " + countingSubstrings);

        }

    }

}
*/