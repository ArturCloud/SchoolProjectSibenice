using System;
using System.Xml;

namespace MujProjekt
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hra Sibenice");
            Console.Write("Napiste sve jmeno:");
            string vyberJmena = Console.ReadLine();     // pišeme tu svoje jmeno 
            Console.Clear();

            Console.WriteLine("Mate k dispozici 2 urovne obtiznosti: normalni a vysokou");
            Console.WriteLine("Pokud chcete vybrat normalni uroven, napiste \"norm\"");
            Console.WriteLine("Pokud chcete vybrat naopak vysokou obtiznost, napiste \"vys\"");
            string vyberUrovneObtiznosti = Console.ReadLine();   // můžeme tu vybrat vlastně obtižnost hry 
            Console.WriteLine(vyberUrovneObtiznosti);
            bool kontrolaObtiznosti = false; //kontrola
            int maxPocetMoznychChyb = 0;
            while (kontrolaObtiznosti==false)
            {
                switch (vyberUrovneObtiznosti)
                {
                    case "norm":                      // normalni uroven 
                        maxPocetMoznychChyb = 8;
                        kontrolaObtiznosti = true;
                        break;
                    case "vys":                       // vysoka uroven 
                        maxPocetMoznychChyb = 5;
                        kontrolaObtiznosti = true;
                        break;
                    default:                          //ošetření vstupu
                        Console.WriteLine("Takova uroven ve hre neni!");
                        Console.WriteLine("Napiste po nove");
                        vyberUrovneObtiznosti = Console.ReadLine();
                        break;

                }
            }
            Console.Clear();

            string[] poleSlov = { "kniha", "pocitac", "demokratie","lahev","lekar","maso","vitr" };    //pole skrytých slov
            string[] poleNapovedy = { "----Pomaha nam ziskat znalosti----", "----Informatici pouzivaji to moc hodne----", "----Politicky rezim----","----Pijeme pivo z...----","----Clovek,ktery se tyka zdravotnictvi----","----Moc chutne a stoji draho----","----Fouka....----" }; //napověda
            Random random = new Random();
            int vyber = random.Next(0, 3);
            string vyberNapovedy = poleNapovedy[vyber];                       //spojuje pole s randomem
            string vyberSlova = poleSlov[vyber];                              // tu taky
            char[] poleChar = new char[vyberSlova.Length];                     // dělá se pole s typem char, které bude nám sloužit místom pro skrytá písmena
            Console.WriteLine("Dobry den,pan(i) " + vyberJmena);
            Console.WriteLine("Tema skryteho slova: " + vyberNapovedy); 
            Console.WriteLine("\nVyberte, prosim, nejake pismeno");

            for (int a = 0; a < vyberSlova.Length; a++)                                          //mění všechna pismena na "-"
            {
                poleChar[a] = '-';
            }

            int chyba = 0;                          //vztvářejí se nová promenná "chyba", ktera bude zvětšovat při chybné odpovědi
            int shoda = 0;                             //vztvářejí se nová promenná "shoda", která bude zvětšovat při správné odpovědi

            while (chyba < maxPocetMoznychChyb && shoda != vyberSlova.Length)         // tu cyklus se opakuje do okamžiku,když jedna z dvou podmínek se skončí 
            {
                    bool kontrolaSpravnosti = false; //kontrola
                    char vyberPismena = Convert.ToChar(Console.ReadLine());        // vybíráme tu nějaké písmeno z klávesnice
                    Console.Clear();
                 for (int b = 0; b < vyberSlova.Length; b++) 
                 {
                    if ( vyberPismena== poleChar[b])              //nedává možnost zvětšit proměnnou "shoda" při stlačení opáčného písmena z klavesnice
                    {
                        shoda--;
                    }
                    if (vyberPismena == vyberSlova[b])           //mění "-" na vybráné nami písmeno, pokud máme právdu a zaroven se zvětšuje "shoda"
                    {
                            poleChar[b] = vyberPismena;
                            
                            shoda++;
                            kontrolaSpravnosti = true; //jestli jsme uhádli písmeno, "kontrolaSpravnosti" se nastaví na true a nepůjde k podmínce s "chyba" (podmínka je dolů)


                    }


                 }
                if (kontrolaSpravnosti == false) //pokud jsme neuhádli písmeno, tak se zvětší "chyba"
                {
                    chyba++;
                }
                    if (vyberUrovneObtiznosti == "vys") //pokud jsme si vybrali úroven "vys", tak se vybere ClovekVys, jinak se vzbere úroven "norm"
                    {

                        ClovekVys(chyba);
                    }
                    else
                    {

                        ClovekNorm(chyba);
                    }
                
                

                Console.WriteLine(poleChar);
                    Console.WriteLine($"Maximalni pocet moznych chyb: {maxPocetMoznychChyb}. Pocet vasich chyb:" + chyba);
               

            }
            

            if (vyberSlova.Length == shoda)               
            {
               Console.WriteLine("\nMate vitezstvi!");
            }
            else
            {
                Console.WriteLine("\nBohuzel,prohral jste. Zkuste znovu! ");
            }

        }
        static int ClovekVys(int chyba)            //Šibenice pro hru s vysokou obtiynosti, max. počet možných chyb - 5
        {
            switch (chyba)
            {
                case 1:
                    Console.WriteLine("Poof! Objevila se Sibenice!");
                    Console.WriteLine("____________");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("");
                    break;
                case 2:
                    Console.WriteLine("____________");
                    Console.WriteLine("|        |");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("");
                    break;
                case 3:
                    Console.WriteLine("____________");
                    Console.WriteLine("|        |");
                    Console.WriteLine("|        0");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("");
                    break;
                case 4:
                    Console.WriteLine("____________");
                    Console.WriteLine("|        |");
                    Console.WriteLine("|        0");
                    Console.WriteLine("|       |||");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("");
                    break;
                case 5:
                    Console.WriteLine("____________");
                    Console.WriteLine("|        |");
                    Console.WriteLine("|        0");
                    Console.WriteLine("|       |||");
                    Console.WriteLine("|       | | ");
                    Console.WriteLine("|");
                    Console.WriteLine("");
                    break;
                


            }
            return chyba;
        }
        static int ClovekNorm(int chyba)            //Šibenice pro hru s normální obtiynosti, max. počet možných chyb - 8
        {
            switch (chyba)
            {
                case 1:
                    Console.WriteLine("Poof! Objevila se Sibenice!");
                    Console.WriteLine("____________");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("");
                    break;
                case 2:
                    Console.WriteLine("____________");
                    Console.WriteLine("|        |");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("");
                    break;
                case 3:
                    Console.WriteLine("____________");
                    Console.WriteLine("|        |");
                    Console.WriteLine("|        0");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("");
                    break;
                case 4:
                    Console.WriteLine("____________");
                    Console.WriteLine("|        |");
                    Console.WriteLine("|        0");
                    Console.WriteLine("|        |");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("");
                    break;
                case 5:
                    Console.WriteLine("____________");
                    Console.WriteLine("|        |");
                    Console.WriteLine("|        0");
                    Console.WriteLine("|        ||");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("");
                    break;
                case 6:
                    Console.WriteLine("____________");
                    Console.WriteLine("|        |");
                    Console.WriteLine("|        0");
                    Console.WriteLine("|       |||");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("");
                    break;
                case 7:
                    Console.WriteLine("____________");
                    Console.WriteLine("|        |");
                    Console.WriteLine("|        0");
                    Console.WriteLine("|       |||");
                    Console.WriteLine("|       |");
                    Console.WriteLine("|");
                    Console.WriteLine("");
                    break;
                case 8:
                    Console.WriteLine("____________");
                    Console.WriteLine("|        |");
                    Console.WriteLine("|        0");
                    Console.WriteLine("|       |||");
                    Console.WriteLine("|       | |");
                    Console.WriteLine("|");
                    Console.WriteLine("");
                    break;



            }
            return chyba;
        }





    }

}











