using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueModels;
using MultiQueueTesting;

namespace MultiQueueSimulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "txt files(*.txt)|*.txt";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    fileLocation = dialog.FileName.Replace('\\', '/');
                    MessageBox.Show("File uploaded");
                    Program.init(fileLocation, false);
                }

                FileName.Text = Path.GetFileName(fileLocation);

                getPerformanceSystem();

                getSimulationTable();
            }
            catch (Exception error)
            {
                MessageBox.Show("An error occured while uploading your image. " + error.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FileName_Click(object sender, EventArgs e)
        {

        }

        void getPerformanceSystem()
        {
            PerformanceMeasures measures = Program.system.PerformanceMeasures;
            avg_wating_time.Text = measures.AverageWaitingTime.ToString();
            max_queue_length.Text = measures.MaxQueueLength.ToString();
            customer_probability.Text = measures.WaitingProbability.ToString();
        }

        void getSimulationTable()
        {
            List<SimulationCase> tableData = Program.system.SimulationTable;
            dataGridView1.Rows.Clear();
            foreach (SimulationCase simulationCase in tableData)
            {
                dataGridView1.Rows.Add(
                    simulationCase.CustomerNumber,
                    simulationCase.RandomInterArrival,
                    simulationCase.InterArrival,
                    simulationCase.ArrivalTime,
                    simulationCase.RandomService,
                    simulationCase.ServiceTime,
                    simulationCase.AssignedServer.ID,
                    simulationCase.StartTime,
                    simulationCase.EndTime,
                    simulationCase.TimeInQueue
                );
            }
        }

        private void show_graphs_Click(object sender, EventArgs e)
        {
            if (FileName.Text != "No files added yet")
            {
                Program.graph.comboBoxBuilder();
                Hide();
                Program.graph.Show();
            }
            else
            {
                MessageBox.Show("Please add file");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }
    }
}
