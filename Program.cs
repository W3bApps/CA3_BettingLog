using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA3_10379529_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            RaceList raceList1 = new RaceList();
            raceList1.WriteRaceList();

            string options = "";
            int Options_Int;

            while (options != "exit".ToUpper() && options != "8")
            {
                Console.WriteLine(Environment.NewLine + "Please select option from the below list: " + Environment.NewLine);
                Console.WriteLine("1. Review Race Betting History");
                Console.WriteLine("2. Add a new bet to the racing log");
                Console.WriteLine("3. Summary of annual wins -v- losses");
                Console.WriteLine("4. Races listed in order of date");
                Console.WriteLine("5. Biggest financial loss incurred in a single race");
                Console.WriteLine("6. Biggest financial gain in a single race");
                Console.WriteLine("7. Race prediction success rate");
                Console.WriteLine("8. EXIT" + Environment.NewLine);
                options = Console.ReadLine().ToUpper();

                int.TryParse(options, out Options_Int);
                {
                    if(Options_Int == 1)
                    {  
                        raceList1.ReadRaceList();
                        raceList1.ReadAllRaces();
                    }
                    else if(Options_Int == 2)
                    {
                        raceList1.WriteNewRace();
                        raceList1.ReadRaceList();
                    }
                    else if(Options_Int == 3)
                    {
                        raceList1.ReadRaceList();
                        raceList1.AnnualWinLoss();
                    }
                    else if(Options_Int == 4)
                    {
                        raceList1.ReadRaceList();
                        raceList1.listedByDate();
                    }
                    else if (Options_Int == 5)
                    {
                        raceList1.ReadRaceList();
                        raceList1.BiggestLoss();
                    }
                    else if (Options_Int == 6)
                    {
                        raceList1.ReadRaceList();
                        raceList1.BiggestWin(); 
                    }
                    else if (Options_Int == 7)
                    {
                        raceList1.ReadRaceList();
                        raceList1.SuccessRate();
                    }
                    else if (Options_Int == 8)
                    {
                        options = "8";
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry. Please try again by choosing one of th options listed below");
                    }
                }

            }
            Console.WriteLine(Environment.NewLine + "Thank you for using HotTipster. Goodbye");
            Console.ReadLine();
        }
    }
}
