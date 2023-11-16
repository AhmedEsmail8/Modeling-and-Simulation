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

            string result = TestingManager.Test(system, Constants.FileNames.TestCase1);
            MessageBox.Show(result);

            Form1 form = new Form1();
            Application.Run(form);
        }
    }
}
