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
        [STAThread]
        static void Main()
        {
            HandleFiles file = new HandleFiles(Constants.FileNames.TestCase4);
            file.display();

            SimulationSystem system = new SimulationSystem();
            system.NumberOfServers = file.NumberOfServers;
            system.StoppingCriteria = (Enums.StoppingCriteria)file.StoppingCriteria;
            system.SelectionMethod = (Enums.SelectionMethod)file.SelectionMethod;
            system.StoppingNumber = file.StoppingNumber;
            system.InterarrivalDistribution = new List<TimeDistribution>(file.interArrivalDistribution);
            system.Servers = new List<Server>(file.servers);

            system.start();

            PrintSimulationTable(system.SimulationTable);

            string result = TestingManager.Test(system, Constants.FileNames.TestCase4);
            MessageBox.Show(result);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

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
