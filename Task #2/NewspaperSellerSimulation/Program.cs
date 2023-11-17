using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewspaperSellerTesting;
using NewspaperSellerModels;

namespace NewspaperSellerSimulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SimulationSystem system = new SimulationSystem();

            GetData data = new GetData(Constants.FileNames.TestCase1);
            Console.WriteLine(data.ToString());
            data.FillSystem(ref system);

            system.start();
            PrintSimulationTable(system.SimulationTable);

            string result = TestingManager.Test(system, Constants.FileNames.TestCase1);
            
            
            MessageBox.Show(result);

            Form1 form = new Form1();
            Application.Run(form);
        }

        static void PrintSimulationTable(List<SimulationCase> simulationTable)
        {
            Console.WriteLine("SimulationTable:");
            Console.WriteLine("Day | Rondom Digits for Type of Newsday | Type of Newsday | Rondom Digits for Demand | Demand | Revenue from Sales | Lost Profit from Excess Demand | Salvage from Sale of Scrap | Daily Profit");

            foreach (var item in simulationTable)
            {
                string formattedRow = string.Format("{0, -3} | {1, -33} | {2, -15} | {3, -24} | {4, -6} | {5, -18} | {6, -30} | {7, -26} | {8, -7}",
                    item.DayNo, item.RandomNewsDayType, item.NewsDayType, item.RandomDemand,
                    item.Demand, item.DailyCost, item.LostProfit, item.ScrapProfit, item.DailyNetProfit
                );

                Console.WriteLine(formattedRow);
            }
        }
    }
}
