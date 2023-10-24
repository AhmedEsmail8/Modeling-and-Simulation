using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class PerformanceMeasures
    {
        public decimal AverageWaitingTime { get; set; }
        public int MaxQueueLength { get; set; }
        public decimal WaitingProbability { get; set; }


        public decimal CalculateAverageWaitingTime(List<SimulationCase> simulationTable)
        {
            decimal totalWaitingTime = 0;
            int numberOfCustomers = simulationTable.Count;

            foreach (var item in simulationTable)
            {
                totalWaitingTime += item.TimeInQueue;
            }

            return (decimal)totalWaitingTime / numberOfCustomers;
        }


        public int CalculateMaxQueueLength(List<SimulationCase> simulationTable)
        {
            int maxQ = 0; 
            int QCounter = 0;
            int index = 0;
            int tmpStartTime = int.MaxValue;

            for (int i = 0; i < simulationTable.Count; i++)
            {
                if (simulationTable[i].TimeInQueue != 0)
                {
                    if (QCounter == 0)
                    {
                        index = i;
                        tmpStartTime = simulationTable[i].StartTime;
                    }
                    if (simulationTable[i].ArrivalTime < tmpStartTime)
                        QCounter++;
                    else
                    {
                        index++;
                        tmpStartTime = simulationTable[index].StartTime;
                    }
                }
                else
                    QCounter = 0;

                maxQ = Math.Max(maxQ, QCounter);
            }

            return maxQ ; 
        }


        public decimal CalculateProbabilityOfWaiting(List<SimulationCase> simulationTable)
        {
            int customersWithQueueTime = simulationTable.Count(item => item.TimeInQueue > 0);
            return (decimal)customersWithQueueTime / simulationTable.Count;
        }


        public void Calculateperformance(List<SimulationCase> simulationTable)
        {
            AverageWaitingTime = CalculateAverageWaitingTime(simulationTable);
            MaxQueueLength = CalculateMaxQueueLength(simulationTable);
            WaitingProbability = CalculateProbabilityOfWaiting(simulationTable);

        }

    }
}