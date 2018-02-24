using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project2
{
    class Program
    {
        static void Main()
        {
            List<Data> teams = new List<Data>();
            Data entry;            

            Console.Write("Please paste the file path here:");
            string userInput = Console.ReadLine();
            string FILEPATH = ($@"{userInput}");
            const char COMMA = ',';            
            string[] values;

            Console.Clear();

            superBowlWinners();
            Console.WriteLine("Press enter to see top five attended super bowls");
            Console.ReadLine();
            topAttendance();           

            //displays winners, year, coach, mvp, qb
            void superBowlWinners()
            {
                try
                {
                    FileStream file = new FileStream(FILEPATH, FileMode.Open, FileAccess.Read);
                    StreamReader read = new StreamReader(file);

                    values = read.ReadLine().Split(COMMA);//skip first row of csv

                    while (!read.EndOfStream)//loop to read csv file to console
                    {
                        values = read.ReadLine().Split(COMMA);
                        entry = new Data(values[1], values[0], values[5], values[3], values[4], values[11]);                        
                        Console.WriteLine(entry);
                        double winningPts = Double.Parse(values[6]);
                        double losingPts = Double.Parse(values[10]);
                        double difference = winningPts - losingPts;
                        Console.WriteLine("Point difference: " + difference);
                        teams.Add(entry);                        
                        Console.WriteLine();
                    }//end of reading loop                   
                    file.Close();
                    read.Close();
                }
                catch (Exception i)
                {
                    Console.WriteLine(i.Message);                    
                }
            }//end of superBowlWinners

            void topAttendance()
            {
                List<int> attList = new List<int>();
                
                FileStream file = new FileStream(FILEPATH, FileMode.Open, FileAccess.Read);
                StreamReader read = new StreamReader(file);
                

                values = read.ReadLine().Split(COMMA);
                

                while (!read.EndOfStream)
                {
                    values = read.ReadLine().Split(COMMA);
                    int row = Int32.Parse(values[2]);
                    attList.Add(row);                                       
                }

                var maxAtt = attList.OrderByDescending(x => x);
                int counter = 1;
                foreach(var x in maxAtt)
                {
                    Console.WriteLine(x);
                    counter = counter++;
                    if (counter == 5)
                    {
                        break;
                    }
                } 

                read.Close();
                file.Close();
                
            }//end of topAttendance

           
            Console.ReadKey();
        }
    }

    class Data
    {

        public string sb { get; set; }
        public string date { get; set; }
        public string winner { get; set; }
        public string loser { get; set; }
        
        public string quarterback { get; set; }
        public string coach { get; set; }
        public string mvp { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string stadium { get; set; }
        public int attendance { get; set; }


        public Data(string sb, string date, string winner, string quarterback, string coach, string mvp)
        {
            this.sb = sb;
            this.date = date;
            this.winner = winner;
            this.quarterback = quarterback;
            this.coach = coach;
            this.mvp = mvp;
        }
        public void Attendance(int attendance, string date, string winner, string loser, string city, string state, string stadium)
        {
            this.attendance = attendance;
            this.date = date;
            this.winner = winner;
            this.loser = loser;
            this.city = city;
            this.state = state;
            this.stadium = stadium;
        }
        public override string ToString()
        {
            return String.Format($"Super Bowl: {sb} \nDate: {date} \nWinner: {winner} \nQuarterback: {quarterback} \nCoach: {coach} \nMVP: {mvp}");
        }       
        
    }//end of Data class
    
}
