using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class Server
    {
        public Server()
        {
            this.TimeDistribution = new List<TimeDistribution>();
        }

        public int ID { get; set; }
        public decimal IdleProbability { get; set; }
        public decimal AverageServiceTime { get; set; } 
        public decimal Utilization { get; set; }

        public List<TimeDistribution> TimeDistribution;
        
        //optional if needed use them
        public int FinishTime { get; set; }
        public int TotalWorkingTime { get; set; }

        public void calcutilization(List<SimulationCase> simulationTable)
        {
            decimal totalServiceTime = 0;
            int no_customer = 0;
            decimal serverIdleTime = 0;

            for (int i = 0; i < simulationTable.Count; i++)
            {
                if (simulationTable[i].AssignedServer.ID == this.ID)
                {
                    totalServiceTime += simulationTable[i].ServiceTime;
                    no_customer++;
                }
                else
                {
                    serverIdleTime += simulationTable[i].ServiceTime; 
                }
            }

            decimal totalSimulationTime = simulationTable[simulationTable.Count - 1].EndTime;
            decimal totalIdleTime = totalSimulationTime - (this.TotalWorkingTime + totalServiceTime); 

            this.IdleProbability = totalIdleTime / totalSimulationTime;

            this.AverageServiceTime = no_customer > 0 ? totalServiceTime / no_customer : 0;
            this.Utilization = totalServiceTime / totalSimulationTime;
        }



    }
}
