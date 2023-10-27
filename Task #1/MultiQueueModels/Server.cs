using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiQueueModels;

namespace MultiQueueModels
{
    public class Server
    {
        public Server()
        {
            this.TimeDistribution = new List<TimeDistribution>();
            no_customers = 0;
            TotalWorkingTime = 0;
        }

        public int ID { get; set; }
        public decimal IdleProbability { get; set; }
        public decimal AverageServiceTime { get; set; }
        public decimal Utilization { get; set; }

        public List<TimeDistribution> TimeDistribution;

        //optional if needed use them
        public int FinishTime { get; set; }
        public int TotalWorkingTime { get; set; }
        public int no_customers { get; set; }

        public void Calculate_server_performance(decimal totalSimulationTime)
        {
            this.AverageServiceTime = no_customers > 0 ? (decimal)this.TotalWorkingTime / no_customers : 0;
            this.Utilization = (decimal)this.TotalWorkingTime / totalSimulationTime;
            this.IdleProbability = (decimal)(totalSimulationTime - this.TotalWorkingTime) /(decimal) totalSimulationTime;
/*            this.IdleProbability = 1 - this.Utilization;
            if (this.IdleProbability < 0)
                this.IdleProbability *= -1;*/
        }

        public override string ToString()
        {
            return $"Server ID: {ID}\n" +
                   $"Idle Probability: {IdleProbability}\n" +
                   $"Average Service Time: {AverageServiceTime}\n" +
                   $"Utilization: {Utilization}\n"+
                   $"totalWorkingTime: {TotalWorkingTime}\n\n";
        }

    }
}
