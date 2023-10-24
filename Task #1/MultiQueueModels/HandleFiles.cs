using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class HandleFiles
    {

        public int NumberOfServers { get; set; } = 1;
        public int StoppingNumber { get; set; }
        public int SelectionMethod { get; set; }
        public int StoppingCriteria { get; set; }
        public List<TimeDistribution> interArrivalDistribution { get; set; }
        public List<Server> servers { get; set; }
        public HandleFiles(string testCase)
        {
            this.interArrivalDistribution = new List<TimeDistribution>();
            this.servers = new List<Server>();

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName.Replace('\\', '/');
            string testDirectory = projectDirectory + "/MultiQueueSimulation/TestCases/";
            string file = Path.Combine(testDirectory, testCase);

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
                int serverID = 1;
                for (int i=0; i<lines.Length; i++)
                {
                    if (configMap.TryGetValue(lines[i], out Action<string> setProperty))
                    {
                        setProperty(lines[i + 1]);
                        i++;
                    }
                    if (lines[i] == "InterarrivalDistribution")
                    {
                        decimal sum = 0;
                        
                        while (i + 1 < lines.Length && lines[++i].Length != 0)
                        {
                            string []line = lines[i].Split(',');
                            TimeDistribution time = new TimeDistribution();
                            time.Time = int.Parse(line[0]);
                            time.Probability = decimal.Parse(line[1]);
                            sum += time.Probability;
                            time.CummProbability = sum;
                            time.MaxRange = (int)(time.CummProbability * 100);
                            if (this.interArrivalDistribution.Count == 0)
                                time.MinRange = 1;
                            else
                                time.MinRange = this.interArrivalDistribution[this.interArrivalDistribution.Count - 1].MaxRange + 1;
                            
                            this.interArrivalDistribution.Add(time);
                        }
                    }

                    else if (lines[i].IndexOf("ServiceDistribution") != -1)
                    {
                        Server ser = new Server();
                        ser.FinishTime = 0;
                        ser.TotalWorkingTime = 0;
                        ser.ID = serverID;
                        serverID++;
                        decimal sum = 0;
                        while (i+1<lines.Length && lines[++i].Length != 0)
                        {

                            string[] line = lines[i].Split(',');
                            TimeDistribution time = new TimeDistribution();
                            time.Time = int.Parse(line[0]);
                            time.Probability = decimal.Parse(line[1]);
                            sum += time.Probability;
                            time.CummProbability = sum;
                            time.MaxRange = (int)(time.CummProbability * 100);
                            if (ser.TimeDistribution.Count == 0)
                                time.MinRange = 1;
                            else
                                time.MinRange = ser.TimeDistribution[ser.TimeDistribution.Count - 1].MaxRange + 1;

                            ser.TimeDistribution.Add(time);
                        }
                        this.servers.Add(ser);
                        
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
            foreach (TimeDistribution i in this.interArrivalDistribution)
            {
                Console.WriteLine($"time: {i.Time}, prob: {i.Probability}, comProb: {i.CummProbability}, lowerRange: {i.MinRange}, upperRange: {i.MaxRange}");
            }
            Console.WriteLine("\n\n");
            foreach (Server ser in this.servers)
            {
                Console.WriteLine("Server #" + ser.ID);
                foreach (TimeDistribution i in ser.TimeDistribution)
                {
                    Console.WriteLine($"time: {i.Time}, prob: {i.Probability}, comProb: {i.CummProbability}, lowerRange: {i.MinRange}, upperRange: {i.MaxRange}");
                }
                Console.WriteLine("\n\n");
            }
        }
    }
}
