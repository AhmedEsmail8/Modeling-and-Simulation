using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public struct tableCase
    {
        public double time, prob, comProb, lowerRange, upperRange;
        public override string ToString()
        {
            return $"time: {time}, prob: {prob}, comProb: {comProb}, lowerRange: {lowerRange}, upperRange: {upperRange}";
        }
    }
    public class HandleFiles
    {

        public int NumberOfServers { get; set; }
        public int StoppingNumber { get; set; }
        public int SelectionMethod { get; set; }
        public int StoppingCriteria { get; set; }
        public List<tableCase> interArrivalDistribution { get; set; }
        public List<List<tableCase>> serverTime { get; set; }
        public HandleFiles(string testCase)
        {
            this.interArrivalDistribution = new List<tableCase>();
            this.serverTime = new List<List<tableCase>>();

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string testDirectory = projectDirectory.Replace('\\', '/') + "/MultiQueueSimulation/TestCases/";
            string file = testDirectory + testCase;

            var configMap = new Dictionary<string, Action<string>>
            {
                { "NumberOfServers", value => this.NumberOfServers = int.Parse(value) },
                { "StoppingNumber", value => this.StoppingNumber = int.Parse(value) },
                { "StoppingCriteria", value => this.StoppingCriteria = int.Parse(value) },
                { "SelectionMethod", value => this.SelectionMethod = int.Parse(value) }
            };

            if (File.Exists(file))
            {
                string[] lines = File.ReadAllLines(file);

                for (int i=0; i<lines.Length; i++)
                {
                    if (configMap.TryGetValue(lines[i], out Action<string> setProperty))
                    {
                        setProperty(lines[i + 1]);
                        i++;
                    }
                    if (lines[i] == "InterarrivalDistribution")
                    {
                        double sum = 0;
                        while (i + 1 < lines.Length && lines[++i].Length != 0)
                        {
                            string []line = lines[i].Split(',');
                            tableCase tmp = new tableCase();

                            tmp.time = double.Parse(line[0]);
                            tmp.prob = double.Parse(line[1]);
                            sum += tmp.prob;
                            tmp.comProb = sum;
                            tmp.upperRange = tmp.comProb * 100;
                            if (this.interArrivalDistribution.Count == 0)
                                tmp.lowerRange = 0;
                            else
                                tmp.lowerRange = this.interArrivalDistribution[this.interArrivalDistribution.Count - 1].upperRange + 1;

                            this.interArrivalDistribution.Add(tmp);
                        }
                    }

                    else if (lines[i].IndexOf("ServiceDistribution") != -1)
                    {
                        List<tableCase> table = new List<tableCase>();
                        double sum = 0;
                        while (i+1<lines.Length && lines[++i].Length != 0)
                        {
                            string[] line = lines[i].Split(',');
                            tableCase tmp = new tableCase();

                            tmp.time = double.Parse(line[0]);
                            tmp.prob = double.Parse(line[1]);
                            sum += tmp.prob;
                            tmp.comProb = sum;
                            tmp.upperRange = tmp.comProb * 100;
                            if (table.Count == 0)
                                tmp.lowerRange = 0;
                            else
                                tmp.lowerRange = table[table.Count - 1].upperRange + 1;

                            table.Add(tmp);
                        }
                        this.serverTime.Add(table);
                    }
                }
            }
        }

        public void display()
        {
            Console.WriteLine("NumberOfServers = " + this.NumberOfServers);
            Console.WriteLine("SelectionMethod = " + this.SelectionMethod);
            Console.WriteLine("StoppingCriteria = " + this.StoppingCriteria);
            Console.WriteLine("StoppingNumber = " + this.StoppingNumber);
            Console.WriteLine("\n\nInterarrivalDistribution");
            foreach (tableCase i in this.interArrivalDistribution)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine("\n\n");
            int tmp = 0;
            foreach (List<tableCase> i in this.serverTime)
            {
                Console.WriteLine("Server #" + tmp);
                tmp++;
                foreach (tableCase j in i)
                    Console.WriteLine(j.ToString());
                Console.WriteLine("\n\n");
            }
        }
    }
}
