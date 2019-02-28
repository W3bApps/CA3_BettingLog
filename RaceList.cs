using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CA3_10379529_Console
{
    class RaceList
    {
        List<Races> raceList = new List<Races>() {
            new Races("Aintree", DateTime.Parse("2017-05-12"), 11.58, true),
            new Races("Punchestown", DateTime.Parse("2016-12-22"), 122.52, true),
            new Races("Sandown", DateTime.Parse("2016-11-17"), 20.00, false),
            new Races("Ayr", DateTime.Parse("2016-11-03"), 25.00, false),
            new Races("Fairyhouse", DateTime.Parse("2016-12-02"), 65.75, true),
            new Races("Ayr", DateTime.Parse("2017-03-11"), 12.05, true),
            new Races("Doncaster", DateTime.Parse("2017-12-02"), 10.00, false),
            new Races("Towcester", DateTime.Parse("2016-03-12"), 50.00, false),
            new Races("Goodwood", DateTime.Parse("2017-10-07"), 525.74, true),
            new Races("Kelso", DateTime.Parse("2016-09-13"), 43.21, true),
            new Races("Punchestown", DateTime.Parse("2017-07-05"), 35.00, false),
            new Races("Ascot", DateTime.Parse("2016-02-04"), 23.65, true),
            new Races("Kelso", DateTime.Parse("2017-08-02"), 30.00, false),
            new Races("Towcester", DateTime.Parse("2017-05-01"), 104.33, true),
            new Races("Ascot", DateTime.Parse("2017-06-21"), 25.00, false),
            new Races("Bangor", DateTime.Parse("2016-12-22"), 30.00, false),
            new Races("Ayr", DateTime.Parse("2017-05-22"), 11.50, true),
            new Races("Ascot", DateTime.Parse("2017-06-23"), 30.00, false),
            new Races("Ascot", DateTime.Parse("2017-06-23"), 374.27, true),
            new Races("Goodwood", DateTime.Parse("2016-10-05"), 34.12, true),
            new Races("Dundalk", DateTime.Parse("2016-11-09"), 20.00, false),
            new Races("Haydock", DateTime.Parse("2016-11-12"), 87.00, true),
            new Races("Perth", DateTime.Parse("2017-01-20"), 15.00, false),
            new Races("York", DateTime.Parse("2017-11-11"), 101.25, true),
            new Races("Punchestown", DateTime.Parse("2016-12-22"), 11.50, true),
            new Races("Chester", DateTime.Parse("2016-08-14"), 10.00, false),
            new Races("Kelso", DateTime.Parse("2016-09-18"), 10.00, false),
            new Races("Kilbeggan", DateTime.Parse("2017-03-03"), 20.00, false),
            new Races("Fairyhouse", DateTime.Parse("2017-03-11"), 55.50, true),
            new Races("Punchestown", DateTime.Parse("2016-11-15"), 10.00, false),
            new Races("Towcester", DateTime.Parse("2016-05-08"), 16.55, true),
            new Races("Punchestown", DateTime.Parse("2016-05-23"), 13.71, true),
            new Races("Cork", DateTime.Parse("2016-11-30"), 20.00, false),
            new Races("Punchestown", DateTime.Parse("2016-04-25"), 13.45, true),
            new Races("Bangor", DateTime.Parse("2016-01-23"), 10.00, false),
            new Races("Sandown", DateTime.Parse("2017-08-07"), 25.00, false)
        };

        
        public void WriteRaceList()
        {
            int historicalRaces = 0;

            if (historicalRaces == 0)
            {
                using (Stream fs = File.Open(@"..\..\..\Betting_Log1.txt", FileMode.OpenOrCreate))
                {
                    fs.Seek(0, SeekOrigin.End);
                    using (BinaryWriter binWriter = new BinaryWriter(fs))
                    {
                        try
                        {
                            foreach (Races race in raceList)
                            {

                                binWriter.Write(race.Track);
                                binWriter.Write(race.RaceDate.ToString());
                                binWriter.Write(race.Winnings);
                                binWriter.Write(race.Result);

                            }
                            Console.WriteLine("Binary file created and written to successfully");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                historicalRaces++;
            }
            else
            {
                Console.WriteLine("Historical Races list previously written to file.");
            }
            
                
        }

        public void WriteNewRace()
        {
            using (Stream fs = File.Open(@"..\..\..\Betting_Log1.txt", FileMode.OpenOrCreate))
            {
                fs.Seek(0, SeekOrigin.End);
                using (BinaryWriter binWriter = new BinaryWriter(fs))
                {
                    try
                    {
                        Races race1 = new Races();

                        string Track = race1.Add_Track();
                        DateTime RaceDate = race1.Add_Date_Of_Race();
                        double Winnings = race1.Add_Winnings();
                        bool Result = race1.Add_Win_Or_Lose();

                        //raceList.Add(new Races(Track, RaceDate, Winnings, Result));

                        binWriter.Write(Track);
                        binWriter.Write(RaceDate.ToString());
                        binWriter.Write(Winnings);
                        binWriter.Write(Result);

                        Console.WriteLine("Binary file created and written to successfully");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            
        }

        
        List<Races> raceListRead1 = new List<Races>();

        public void ReadAllRaces()
        {
            try
            {
                int i = 0;

                foreach (var item in raceListRead1)
                {
                    Console.WriteLine($"No. {i+1}" + Environment.NewLine
                                    + $"Track is: {raceListRead1[i].Track}" + Environment.NewLine
                                    + $"Run on: {raceListRead1[i].RaceDate}" + Environment.NewLine
                                    + $"Amount won or lost was: ${raceListRead1[i].Winnings}" + Environment.NewLine
                                    + $"The race was won by our horse: {raceListRead1[i].Result}" + Environment.NewLine);
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }  
        }

        public void ReadRaceList()
        {
            raceListRead1 = new List<Races>();

            using (Stream fs = File.Open(@"..\..\..\Betting_Log1.txt", FileMode.OpenOrCreate))
            {
                using (BinaryReader binReader = new BinaryReader(fs))
                {
                    try
                    {
                        int position = 0;
                        fs.Seek(position, SeekOrigin.Begin);

                        while (position<1)
                        {
                            Races race = new Races();

                            race.Track = binReader.ReadString();
                            race.RaceDate = DateTime.Parse(binReader.ReadString());
                            race.Winnings = binReader.ReadDouble();
                            race.Result = binReader.ReadBoolean();

                            raceListRead1.Add(race);
                        }
                        Console.WriteLine("Binary file read successfully");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        public void AnnualWinLoss()
        {
            int Year = 2016;
            Console.WriteLine("YEAR; Total Won; Total Lost");

            for (int year = Year; year < DateTime.Today.Year; year++)
            {
                var winnings = from race in raceListRead1
                               where race.RaceDate.Year == year
                               where race.Result == true
                               select race;

                var losses = from race in raceListRead1
                             where race.RaceDate.Year == year
                             where race.Result == false
                             select race;

                double TotalWinnings = 0;
                double TotalLosses = 0;

                foreach (var race in winnings)
                {
                    TotalWinnings = TotalWinnings + race.Winnings;
                }

                foreach (var race in losses)
                {
                    TotalLosses = TotalLosses + race.Winnings;
                }
                
                Console.WriteLine(year + "; $" + TotalWinnings + ";     $" + TotalLosses);
            }
        }

        public void listedByDate()
        {
            var sortedbydate = from race in raceListRead1
                               orderby race.RaceDate ascending
                               select race;

            foreach(var race in sortedbydate)
            {
                Console.WriteLine(race.RaceDate.ToShortDateString() + "; " + race.Track + "; " + race.Result + "; $" + race.Winnings);
            }
        }

        public void BiggestWin()
        {
            var sortedByWinnings = from race in raceListRead1
                                   where race.Result == true
                                   orderby race.Winnings descending
                                   select race;

            foreach (var race in sortedByWinnings)
            {
                Console.WriteLine("Biggest win was: $" + race.Winnings);
                break;
            }
        }

        public void BiggestLoss()
        {
            var sortedByLosses = from race in raceListRead1
                                   where race.Result == false
                                   orderby race.Winnings descending
                                   select race;

            foreach (var race in sortedByLosses)
            {
                Console.WriteLine("Biggest loss was: $" + race.Winnings);
                break;
            }
        }

        public void SuccessRate()
        {
            double Total = raceListRead1.Count;
            var wins = (from race in raceListRead1
                       where race.Result == true
                       select race).ToList();

            double winTotal = wins.Count;

            Console.WriteLine("Hot Tipster has a success rate of {0}%" , Math.Round((winTotal / Total)*100, 0));
            Console.WriteLine("Of {0} races, Hot Tipster has predicted {1} wins", Total, winTotal);
        }
    }
}
