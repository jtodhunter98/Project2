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
            List<Team> teams = new List<Team>();
            Team entry;
            const string FILEPATH = @"C:\Users\todjord\Documents\Visual Studio 2017\Projects\Project2\Super_Bowl_Project.csv";
            const char COMMA = ',';            
            string[] values;

            try
            {
                FileStream file = new FileStream(FILEPATH, FileMode.Open, FileAccess.Read);
                StreamReader read = new StreamReader(file);
                while (!read.EndOfStream)
                {
                    values = read.ReadLine().Split(COMMA);
                    entry = new Team(values[1],values[5],values[3],values[4],values[11]);
                    Console.WriteLine(entry);
                    teams.Add(entry);
                    Console.WriteLine();
                }
                
                read.Close();
                file.Close();
            }catch(Exception i)
            {
                Console.WriteLine(i.Message);
            }

            
            Console.ReadKey();
        }
    }

    class Team
    {        
        public string winner { get; set; }
        public string sb { get; set; }       
        public string quarterback { get; set; }
        public string coach { get; set; }
        public string mvp { get; set; }
        

        public Team(string sb, string winner, string quarterback, string coach, string mvp)
        {            
            
            this.sb = sb;
            this.winner = winner;            
            this.quarterback = quarterback;
            this.coach = coach;
            this.mvp = mvp;
        }
        public override string ToString()
        {
            return String.Format($"Super Bowl: {sb} \nWinner: {winner} \nQuarterback: {quarterback} \nCoach: {coach} \nMVP: {mvp}");
        }
    }
}
