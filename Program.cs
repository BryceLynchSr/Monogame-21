//Douglas Netzel - Projekt 1, 21:an - Spela spelet 21:an med datorn
using System.Drawing;

// byter bakgrundsfärg till blå och textfärg till vit
Console.BackgroundColor = ConsoleColor.DarkBlue;
Console.Clear();
Console.ForegroundColor = ConsoleColor.White;  

Console.WriteLine("HEJ OCH VÄLKOMMEN TILL 21:AN!");
Console.WriteLine();

// Deklarerar variabel av typen sträng för menyval och sätter värdet till noll
string val = "0";

//Skapar en slumpvariabel av typen Random
Random slump = new Random();

// Deklarerar variabel av typen sträng för senaste vinnaren och ger den ett ursprungligt neutralt värde
string senasteVinnaren = "Ingen vinnare än så länge";

// Deklarerar variabel av typen heltal för maxpoäng som ett kort kan ge och ger den värdet 10
int maxKortPoäng = 10;

// Deklarerar variabel av typen heltal för minst antal poäng som ett kort kan ge och ger den värdet 1
int minKortPoäng = 1;

// Utökning - Deklarerar variabel för totalpoäng där datorn slutar att dra nya kort, denna kan ändras av användaren
// om man vill göra spelet lättare. Till en början sätts denna till 21
int datornSlutadraPoäng = 21;

// Så länge användaren inte väljer menyval 4 går programmet tillbaka till denna meny
while (val != "4")
{
    Console.WriteLine();
    Console.WriteLine("Välj ett alternativ");

    Console.WriteLine("1. Spela 21:an");
    Console.WriteLine("2. Visa senaste vinnaren");
    Console.WriteLine("3. Spelets regler");
    Console.WriteLine("4. Avsluta programmet");
    val = Console.ReadLine();


    Console.WriteLine();

    // Användarens menyval hanteras av en switch case
    switch (val)
    {

// Menyval 1 startar en omgång av 21:an
        case "1":
            // Variabler för datorns resp spelarens totalpoäng deklareras och ursprungliga värdet sätts till 0
            int poängDator = 0;
            int poängSpelare = 0;

            // Programmet drar två kort var för dator resp spelare och slumpar fram två tal mellan det lägsta 
            // resp högsta kortvärdet som bestämdes tidigare. Dessa två tal adderas till den totala
            // poängen för dator resp spelare
            Console.WriteLine("Nu kommer två kort dras per spelare.");
            poängDator += slump.Next(minKortPoäng, maxKortPoäng+1);
            poängDator += slump.Next(minKortPoäng, maxKortPoäng+1);
            poängSpelare += slump.Next(minKortPoäng, maxKortPoäng+1);
            poängSpelare += slump.Next(minKortPoäng, maxKortPoäng+1);

            // Variabel för ny kortdragning av typen sträng deklareras och ett neutralt värde sätts
            string kortVal = "";

            // En while-sats styr så länge spelaren vill fortsätta att dra ett nytt kort och dennes totalpoäng
            // är max 21. Totalpoäng för dator resp spelare skrivs ut och spelaren får frågan om man vill
            // dra ytterligare ett kort. Programmet gör en paus, inväntar valet och fortsätter så länge
            // spelaren inte väljer "n" (nej)
            while(kortVal!= "n" && poängSpelare<= 21)
            {
                Console.WriteLine("Datorns poäng = " +poängDator);
                Console.WriteLine("Dina poäng = " +poängSpelare);
                Console.WriteLine("Vill du dra ett kort till (j/n)?");
                kortVal = Console.ReadLine();

// En ny switch case påbörjas baserat på vad spelaren väljer
                switch (kortVal)
                {
                    // Om spelaren väljer ja slumpas ett nytt kort fram och poängen adderas till spelarens
                    // totalpoäng. Värdet av kortet samt den nya totalpoängen skrivs ut
                    case "j":
                        int nyttKort = slump.Next(minKortPoäng, maxKortPoäng+1);
                        poängSpelare += nyttKort;
                        Console.WriteLine("Ditt nya kort har värde: " +nyttKort);
                        Console.WriteLine("Din totala poäng är nu: " +poängSpelare);
              
                        break;

                    // Om spelaren väljer nej hoppar programmet till nästa steg
                    case "n":
                        break;
                }
            }

            // En if-sats känner av om spelaren har mer än 21 poäng. I så fall har datorn vunnit och tilldelas
            // till variablen för den senaste vinnaren
            if (poängSpelare > 21)
            {
                Console.WriteLine("Du har nu över 21 poäng och har förlorat");
                senasteVinnaren = "datorn";
                break;
            }

            // Med en while-sats fortsätter programmet att dra nya kort för datorn så länge som datorn
            // inte har mer än den valda "sluta dra-poängen" och mindre poäng än spelaren
            while (poängDator <= datornSlutadraPoäng && poängDator < poängSpelare)
            {
                // Nytt kort för datorn slumpas fram och läggs till datorns totalpoäng. Kortets värde skrivs
                // ut och sedan pausar programmet i 0,2 sekunder
                int nyttKortDator = slump.Next(minKortPoäng, maxKortPoäng+1);
                poängDator += nyttKortDator;
                Console.WriteLine("Datorns nya kort har värde: " +nyttKortDator);
                Thread.Sleep(200);
            }

            // Respektive totalpoäng skrivs ut
            Console.WriteLine("Du har poäng: " +poängSpelare);
            Console.WriteLine("Datorns totala poäng: " +poängDator);

            // Om datorn har mer än 21 poäng vinner spelaren och får skriva in sitt namn som sparas till
            // variabeln för senaste vinnaren. Programmet pausar i 2 sekunder före och efter det att detta annonseras 
            if(poängDator > 21)
            {
                Thread.Sleep(2000);
                Console.WriteLine();
                Console.WriteLine("Grattis, datorn hade mer än 21 poäng och du har vunnit!");
                Thread.Sleep(2000);
                Console.WriteLine("Skriv in ditt namn: ");
                senasteVinnaren = Console.ReadLine();
            }
            
            // Utökning - SCENARIO 1 - Om datorn har mer poäng än spelaren och max 20 poäng ges spelaren en chans till att
            // vinna genom att denne får ett nytt kort där värdet slumpas fram. Programmet pausar i 2 sekunder före det att det nya
            // kortets värde annonseras och den nya totalpoängen skrivs ut
            else if(poängDator>poängSpelare && poängDator <=20)
            {
                Console.WriteLine("Datorn har just nu mer poäng än du men du ska få en chans till med ett nytt kort.");
                Thread.Sleep(2000);
                Console.Write("Ditt nya kort har värde: ");
                Thread.Sleep(2000);
                int nyttKort = slump.Next(minKortPoäng, maxKortPoäng + 1);
                poängSpelare += nyttKort;
                Console.WriteLine(nyttKort);
                Console.WriteLine("Din totala poäng är nu: " + poängSpelare);
                Console.WriteLine();

                // Om den nya totalpoängen för spelaren är över 21 har denne förlorat. Datorn tilldelas till variabeln för den
                // senaste vinnaren
                if (poängSpelare > 21)
                {
                    Console.WriteLine("Du har nu över 21 poäng och har förlorat");
                    senasteVinnaren = "datorn";
                    break;
                }

                // Om datorn fortfarande har mest poäng men inte mer än 21 har datorn vunnit och tilldelas till
                // variabeln för den senaste vinnaren
                else if (poängDator > poängSpelare && poängDator <= 21)
                {
                    Console.WriteLine("Sorry, datorn hade fler poäng än du och du har förlorat.");
                    senasteVinnaren = "datorn";
                    break;
                }

                // Om datorn och spelaren har lika många poäng har datorn vunnit och tilldelas till variabeln
                // för den senaste vinnaren
                else if(poängDator == poängSpelare)
                {
                    Console.WriteLine("Sorry, ni har nu lika många poäng och du har därmed förlorat.");
                    senasteVinnaren = "datorn";
                    break;
                }

                // Om spelaren nu har högst poäng men max 21 har spelaren vunnit. Detta skrivs ut och spelaren
                // får skriva in sitt namn som tilldelas till variabeln för den senaste vinnaren
                else if(poängSpelare>poängDator && poängSpelare<= 21)
                {
                    Console.WriteLine("Grattis, du har mer poäng än datorn och du har därmed vunnit!");
                    Thread.Sleep(2000);
                    Console.WriteLine("Skriv in ditt namn: ");
                    senasteVinnaren = Console.ReadLine();
                    break;
                }

                // Om SCENARIO 1 inte inträffar hoppar programmet direkt ner hit. Om datorn och spelaren har lika många poäng
                // har datorn vunnit och tilldelas till variabeln för den senaste vinnaren
            }
            else if(poängDator == poängSpelare)
            {
                Console.WriteLine("Sorry, datorn och du hade lika många poäng och därmed har du förlorat.");
                senasteVinnaren = "datorn";
            }

            // Om spelaren har högst poäng men max 21 har spelaren vunnit. Detta skrivs ut och spelaren 
            // får skriva in sitt namn som tilldelas till variabeln för den senaste vinnaren
           else if(poängSpelare>poängDator && poängSpelare <= 21)
            {
                Console.WriteLine("Grattis, du hade mer poäng än datorn och du har därmed vunnit!");
                Thread.Sleep(2000);
                Console.WriteLine("Skriv in ditt namn: ");
                senasteVinnaren = Console.ReadLine();
            }
            break;

// Menyval 2 visar den senaste vinnaren av spelet
        case "2":
            // Ändrar först tillfälligt bakgrundsfärg och färg på texten
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Senaste vinnaren är: " +senasteVinnaren);

            // Ändrar tillbaka till de ursprungliga färginställningarna
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            break;

// Menyval 3 visar spelets regler
        case "3":
            // Ändrar först tillfälligt bakgrundsfärg och färg på texten
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Ditt mål är att tvinga datorn att få mer än 21 poäng.");
            Console.WriteLine("Du får poäng genom att dra kort, varje kort har 1-10 poäng.");
            Console.WriteLine("Om du får mer än 21 poäng har du förlorat.");
            Console.WriteLine("Både du och datorn får två kort i början. Därefter får du");
            Console.WriteLine("dra fler kort tills du är nöjd eller får över 21.");
            Console.WriteLine("När du är färdig drar datorn kort till den har");
            Console.WriteLine("mer poäng än dig eller över 21 poäng.");

            // Ändrar tillbaka till de ursprungliga färginställningarna
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            break;

// Menyval 4 avslutar spelet
        case "4":
            Console.WriteLine("Tack för att du spelade 21:an. Ha en bra dag!");
            break;

// Meddelar användaren att man inte gjort ett korrekt val från menyn
           default:
            Console.WriteLine("Du har inte valt ett korrekt alternativ");
            Console.WriteLine();
            break;
    }

    Console.WriteLine();

}