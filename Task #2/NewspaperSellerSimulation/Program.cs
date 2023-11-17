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
            PerformanceMeasures performance = new PerformanceMeasures();

            performance.CalcPerformace(system.SimulationTable);

            system.PerformanceMeasures = performance;
            PrintSimulationTable(system.SimulationTable);
            performance_measures(performance);
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
        static void performance_measures(PerformanceMeasures performance)
        {
            Console.WriteLine("Performance Measures:");

            string Performance_Row = $"Total sales profit: {performance.TotalSalesProfit} $";
            Console.WriteLine(Performance_Row);

            Performance_Row = $"Total Cost: {performance.TotalCost} $";
            Console.WriteLine(Performance_Row);

            Performance_Row = $"Total Lost Profit: {performance.TotalLostProfit} $";
            Console.WriteLine(Performance_Row);

            Performance_Row = $"Total Scrap Profit: {performance.TotalScrapProfit} $";
            Console.WriteLine(Performance_Row);

            Performance_Row = $"Total Net Profit: {performance.TotalNetProfit} $";
            Console.WriteLine(Performance_Row);

            Performance_Row = $"Days With More Demand: {performance.DaysWithMoreDemand}";
            Console.WriteLine(Performance_Row);

            Performance_Row = $"Days With Unsold Papers: {performance.DaysWithUnsoldPapers}";
            Console.WriteLine(Performance_Row);

        }
    }
}

