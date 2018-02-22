﻿using System;
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
            const string FILEPATH = @"C:\Users\todjord\Documents\Visual Studio 2017\Projects\Project2\Super_Bowl_Project.csv";
            const char COMMA = ',';            
            string[] values;

            superBowlWinners();
            Console.WriteLine("Press enter to see top five attended super bowls");
            Console.ReadKey();

            //displays winners, year, coach, mvp, qb
            void superBowlWinners()
            {
                try
                {
                    FileStream file = new FileStream(FILEPATH, FileMode.Open, FileAccess.Read);
                    StreamReader read = new StreamReader(file);
                    values = read.ReadLine().Split(COMMA);
                    while (!read.EndOfStream)
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
                    }

                    read.Close();
                    file.Close();
                }
                catch (Exception i)
                {
                    Console.WriteLine(i.Message);
                }
            }//end of superBowlWinners

            void topAttendance()
            {

            }

            
            
            Console.ReadKey();
        }
    }

    class Data
    {        
        
        public string sb { get; set; }
        public string date { get; set; }
        public string winner { get; set; }
        public string quarterback { get; set; }
        public string coach { get; set; }
        public string mvp { get; set; }
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
        public override string ToString()
        {
            return String.Format($"Super Bowl: {sb} \nDate: {date} \nWinner: {winner} \nQuarterback: {quarterback} \nCoach: {coach} \nMVP: {mvp}");
        }
        
        
        public static void getHighAttendance(List<Data> teams)
        {
            
                


        }
    }//end of Data class

    class Attendance
    {
        public int attendance { get; set; }

        public Attendance(int attendance)
        {
            this.attendance = attendance;
        }        
        
    }
}
