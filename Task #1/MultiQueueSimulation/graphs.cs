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

            
        }

        private void server_graph_VisibleChanged(object sender, EventArgs e)
        {
            avg_service_time.Text = "";
            utilization.Text = "";
            idile_state_probability.Text = "";
        }
    }
}
