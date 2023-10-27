using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueTesting;
using MultiQueueModels;
using System.IO;
using OfficeOpenXml;

namespace MultiQueueSimulation
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static Form1 form1 { get; set; }
        public static graphs graph { get; set; }
        public static HandleFiles file { get; set; }
        public static SimulationSystem system { get; set; }
        public static void init(string path, bool flag = true)
        {
            string tmp = path;
            if (!flag)
            {
                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName.Replace('\\', '/');
                string testDirectory = projectDirectory + "/MultiQueueSimulation/TestCases/";
                
                if (File.Exists(Path.Combine(testDirectory, "UserTest.txt")))
                    File.Delete(Path.Combine(testDirectory, "UserTest.txt"));

                File.Copy(path, Path.Combine(testDirectory, "UserTest.txt"));
                tmp = "UserTest.txt";
            }
            file = new HandleFiles(tmp);
            //file.display();

            system = new SimulationSystem();
            system.NumberOfServers = file.NumberOfServers;
            system.StoppingCriteria = (Enums.StoppingCriteria)file.StoppingCriteria;
            system.SelectionMethod = (Enums.SelectionMethod)file.SelectionMethod;
            system.StoppingNumber = file.StoppingNumber;
            system.InterarrivalDistribution = new List<TimeDistribution>(file.interArrivalDistribution);
            system.Servers = new List<Server>(file.servers);

            system.start();
            PerformanceMeasures obj1 = new PerformanceMeasures();
            
            obj1.Calculateperformance(system.SimulationTable);

            system.PerformanceMeasures = obj1;

            //PrintSimulationTable(system.SimulationTable);

            string result = TestingManager.Test(system, tmp);
            MessageBox.Show(result);

        }
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            form1 = new Form1();
            graph = new graphs();
            
            //init(Constants.FileNames.TestCase1);
           
            Application.EnableVisualStyles();
            
            Application.Run(form1);

        }
        static void PrintSimulationTable(List<SimulationCase> simulationTable)
        {
            Console.WriteLine("SimulationTable:");
            Console.WriteLine("CustomerNumber | RandomInterArrival | InterArrival | ArrivalTime | RandomService | ServiceTime | AssignedServer | StartTime | EndTime | TimeInQueue");

            foreach (var item in simulationTable)
            {
                string formattedRow = string.Format("{0, -14} | {1, -18} | {2, -12} | {3, -11} | {4, -14} | {5, -12} | {6, -14} | {7, -9} | {8, -7} | {9, -12}",
                    item.CustomerNumber, item.RandomInterArrival, item.InterArrival, item.ArrivalTime,
                    item.RandomService, item.ServiceTime, item.AssignedServer.ID, item.StartTime,
                    item.EndTime, item.TimeInQueue);

                Console.WriteLine(formattedRow);
            }
        }
    }
}
