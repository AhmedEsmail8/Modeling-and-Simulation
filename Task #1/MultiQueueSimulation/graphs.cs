using MultiQueueModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MultiQueueSimulation
{
    public partial class graphs : Form
    {
        public graphs()
        {
            InitializeComponent();
        }

        private void graphs_Load(object sender, EventArgs e)
        {
            comboBoxBuilder();
        }

        private void graphs_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        public void comboBoxBuilder()
        {
            servers.Items.Clear();
            for (int i = 0; i < Program.system.NumberOfServers; i++)
            {
                servers.Items.Add(Program.system.Servers[i].ID);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.form1.Show();
        }

        private void servers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            for (int i = 0; i < Program.system.NumberOfServers; i++)
            {
                if (Program.system.Servers[i].ID == int.Parse(servers.SelectedItem.ToString()))
                {
                    index = i;
                    break;
                }
            }

            Server server = Program.system.Servers[index];

            avg_service_time.Text = server.AverageServiceTime.ToString();
            utilization.Text = server.Utilization.ToString();
            idile_state_probability.Text = server.IdleProbability.ToString();

            buildChart(index);
        }

        void buildChart(int index)
        {
            server_graph.Series.Clear();

            server_graph.ChartAreas[0].AxisX.Interval = 1;
            server_graph.ChartAreas[0].AxisX.Minimum = 0;
            server_graph.ChartAreas[0].AxisX.Maximum = Program.system.SimulationTable.Last().EndTime + 2;

            server_graph.ChartAreas[0].AxisY.Interval = 1;
            server_graph.ChartAreas[0].AxisY.Minimum = 0;
            server_graph.ChartAreas[0].AxisY.Maximum = 1.3;
            //server_graph.ChartAreas[0].AxisY.LabelStyle.Enabled = false;

            server_graph.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            server_graph.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            server_graph.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            server_graph.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            server_graph.Legends.Clear();
            //////////////////////////
            int position = 0;
            int size = 20;

            if (Program.system.SimulationTable.Last().EndTime + 2 > size)
            {
                server_graph.ChartAreas[0].CursorX.AutoScroll = true;
                server_graph.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                server_graph.ChartAreas[0].AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
                server_graph.ChartAreas[0].AxisX.ScaleView.Zoom(position, size);
                server_graph.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
                server_graph.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = size;
            }

            for (int i = 0; i < Program.system.SimulationTable.Count; i++)
            {
                if (Program.system.Servers[index].ID == Program.system.SimulationTable[i].AssignedServer.ID)
                {
                    Series series = new Series();
                    series.ChartType = SeriesChartType.Area;

                    series.Points.AddXY(Program.system.SimulationTable[i].StartTime, 1);
                    series.Points.AddXY(Program.system.SimulationTable[i].EndTime, 1);

                    series.Color = Color.DarkGray;
                    server_graph.Series.Add(series);
                }
               
            }  

        }

        private void server_graph_VisibleChanged(object sender, EventArgs e)
        {
            avg_service_time.Text = "";
            utilization.Text = "";
            idile_state_probability.Text = "";
        }

        private void server_graph_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
