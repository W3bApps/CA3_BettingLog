using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA3_10379529_Console
{
    class Races
    {
        public string Track { get; set; }
        public DateTime RaceDate { get; set; }
        public double Winnings { get; set; }
        public bool Result { get; set; }

        public Races()
        {
        }

        public Races(string track, DateTime racedate, double winnings, bool result)
        {
            Track = track;
            RaceDate = racedate;
            Winnings = winnings;
            Result = result;
        }
        

        


        public string Console_Call(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }



        public string Add_Track()
        {
            string message = "Please enter track name where the race was run: ";
            return Console_Call(message);
        }

        public DateTime Add_Date_Of_Race()
        {
            string message = "Please enter date the race was run (YYYY-MM-DD): ";
            string message2 = "Date of race cannot be in the future. Please enter date correctly (YYYY-MM-DD)";
            string date = Console_Call(message);

            if (DateTime.TryParse(date, out DateTime DateOfRaces))
            {
                if(DateOfRaces > DateTime.Now)
                {
                    string Date = Console_Call(message2);
                    while (DateTime.TryParse(Date, out DateTime DateOfRace) && (DateTime.Parse(Date) > DateTime.Now))
                    {
                        Date = Console_Call(message2);
                        while (!DateTime.TryParse(Date, out DateTime dateOfRace))
                        {
                            Date = Console_Call(message);
                        }
                    }
                    return DateTime.Parse(Date);
                }
                return DateOfRaces;
            }
            else
            {
                while (!DateTime.TryParse(date, out DateTime DateOfRace))
                {
                    date = Console_Call(message);
                }
                return DateTime.Parse(date);
            }
        }

        public double Add_Winnings()
        {
            string message = "Please enter bet placed (if lost) or winnings (if won) ($): ";
            string winnings = Console_Call(message);

            if (double.TryParse(winnings, out double amountWon))
            {
                return amountWon;
            }
            else
            {
                while (!double.TryParse(winnings, out double AmountWon))
                {
                    winnings = Console_Call(message);
                }
                return double.Parse(winnings);
            }
        }

        public bool Add_Win_Or_Lose()
        {
            string message1 = "Please enter if your horse won or lost (Win / Lose): ";
            string message2 = "Please enter \"win or lose\" details correctly (Win / Lose): ";
            string winOrLose = Console_Call(message1);
            bool winLose = false;

            if ((winOrLose.ToUpper() == "WIN") || (winOrLose.ToUpper() == "WON") || (winOrLose.ToUpper() == "W"))
            {
                winLose = true;
            }
            else
            {
                while (!((winOrLose.ToUpper() == "WIN") || (winOrLose.ToUpper() == "WON") || (winOrLose.ToUpper() == "W") || (winOrLose.ToUpper() == "LOSE") || (winOrLose.ToUpper() == "LOST") || (winOrLose.ToUpper() == "L")))
                {
                    winOrLose = Console_Call(message2);
                }
                if ((winOrLose.ToUpper() == "WIN") || (winOrLose.ToUpper() == "WON") || (winOrLose.ToUpper() == "W"))
                {
                    winLose = true;
                }
                return winLose;
            }
            return winLose;
        }

        

        
    }
}

