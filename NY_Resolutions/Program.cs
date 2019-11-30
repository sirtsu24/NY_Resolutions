using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace NewYear
{
    class Resolutions
    {

        public string description;
        int Count = 0;

        public Resolutions(string _description)
        {
            description = _description;
            Count++;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\demo\NewYear.txt";
            List<string> NYResolution = File.ReadAllLines(filePath).ToList();
            List<Resolutions> ResolutionsList = new List<Resolutions>();
            string userAnswer;


            Console.WriteLine("Write your New Years resolutions (separated by semicolon)");
            userAnswer = Console.ReadLine();


            List<string> ToFile = new List<string>(userAnswer.Split(';').Select(p => p.Trim()).ToList());
            File.WriteAllLines(filePath, ToFile);
            int i = 1;
            foreach (string line in ToFile)
            {

                Console.WriteLine($"Resolution {i}: {line}");
                i++;
            }


            Console.WriteLine("Add new resolution: ");
            string userInput = Console.ReadLine();

            Resolutions userResolutions = new Resolutions(userInput);


            ToFile.Add(userInput);

            File.WriteAllLines(filePath, ToFile);
            int k = 1;
            foreach (string line in ToFile)
            {

                Console.WriteLine($"Resolution {k}: {line}");
                k++;
            }




            Console.WriteLine("Which resolution you want to delete?");
            string userChoice = Console.ReadLine().ToLower();

            for (int j = 0; j < ToFile.Count; j++)
            {
                if (ToFile[j] == userChoice)
                {

                    ToFile.Remove(ToFile[j]);

                    break;
                }
            }
            File.WriteAllLines(filePath, ToFile);

            int l = 1;
            foreach (string line in ToFile)
            {

                Console.WriteLine($"Resolution {l}: {line}");
                l++;
            }

        }
    }
}
