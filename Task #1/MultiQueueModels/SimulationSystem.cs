using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    class com : IComparer<Server>
    {
        public int Compare(Server x, Server y)
        {
            return x.FinishTime.CompareTo(y.FinishTime);
        }
    }

    public class SimulationSystem
    {
        Random rnd = new Random();

        public SimulationSystem()
        {
            this.Servers = new List<Server>();

            this.InterarrivalDistribution = new List<TimeDistribution>();
            this.PerformanceMeasures = new PerformanceMeasures();
            this.SimulationTable = new List<SimulationCase>();
        }

        public void start()
        {
            int customers = 1, total_time = 0;
            while ((StoppingCriteria == Enums.StoppingCriteria.NumberOfCustomers && customers<=StoppingNumber) ||
                (StoppingCriteria == Enums.StoppingCriteria.SimulationEndTime && total_time <= StoppingNumber))
            {
                List<int> index = new List<int>();
                SimulationCase simCase = new SimulationCase();

                simCase.CustomerNumber = customers;
                customers++;



                handle_interArrival(simCase);
                assignServer(simCase);
                handle_service_time(simCase);
                

                for (int i=0; i<Servers.Count; i++)
                {
                    if (Servers[i].ID == simCase.AssignedServer.ID)
                    {
                        Servers[i].FinishTime = simCase.EndTime;
                        Servers[i].TotalWorkingTime += simCase.ServiceTime;
                        Servers[i].no_customers++;
                        Servers[i].Utilization = (decimal)(Servers[i].TotalWorkingTime / simCase.EndTime);
                        break;
                    }
                }
                
                total_time = simCase.StartTime;
                if (StoppingCriteria == Enums.StoppingCriteria.SimulationEndTime && total_time > StoppingNumber)
                    break;
                SimulationTable.Add(simCase);
            }
            for (int i=0; i<NumberOfServers; i++)
            {
                Servers[i].FinishTime = 0;
                Servers[i].Calculate_server_performance(this.SimulationTable.Last().EndTime);
                //Console.WriteLine(Servers[i].ToString());
            }
        }

        public void handle_interArrival(SimulationCase simCase)
        {
            if (simCase.CustomerNumber == 1)
            {
                simCase.RandomInterArrival = 1;
                simCase.InterArrival = 0;
                simCase.ArrivalTime = 0;
            }
            else
            {
                simCase.RandomInterArrival = rnd.Next(1, 101);
                foreach (TimeDistribution i in InterarrivalDistribution)
                {
                    if (simCase.RandomInterArrival >= i.MinRange && simCase.RandomInterArrival <= i.MaxRange)
                    {
                        simCase.InterArrival = i.Time;
                        break;
                    }
                }
                simCase.ArrivalTime = SimulationTable.Last().ArrivalTime + simCase.InterArrival;
            }
        }

        public void assignServer(SimulationCase simCase)
        {
            List<Server> availableServers = new List<Server>();
            

            foreach (Server ser in Servers)
            {
                if (ser.FinishTime <= simCase.ArrivalTime)
                    availableServers.Add(ser);
            }
            if (availableServers.Count == 0)
            {
                List<Server> tmp = new List<Server>(Servers);
                com cmp = new com();
                tmp.Sort(cmp);
                for (int i = 0; i < Servers.Count; i++)
                {
                    if (Servers[i].FinishTime == tmp.First().FinishTime)
                        availableServers.Add(Servers[i]);
                }
            }

            if (SelectionMethod == Enums.SelectionMethod.Random)
            {
                int idx = rnd.Next(availableServers.Count);
                simCase.AssignedServer = availableServers[idx];
            }
            else if (SelectionMethod == Enums.SelectionMethod.HighestPriority)
            {

                Server highestPriorityServer = null;
                int highestPriority = int.MaxValue;

                foreach (Server server in availableServers)
                {
                    if (server.ID < highestPriority)
                    {
                        highestPriority = server.ID;
                        highestPriorityServer = server;
                    }
                }

                simCase.AssignedServer = highestPriorityServer;
            }
            else if (SelectionMethod == Enums.SelectionMethod.LeastUtilization)
            {
                Server leastUtilizationServer = null;
                decimal leastUtilization = decimal.MaxValue;

                foreach (Server server in availableServers)
                {
                    //Console.WriteLine("server #" + server.ID + "    utilization = " + server.Utilization);
                    if (server.Utilization < leastUtilization)
                    {
                        leastUtilization = server.Utilization;
                        leastUtilizationServer = server;
                    }
                }
                //Console.WriteLine("====================");
                simCase.AssignedServer = leastUtilizationServer;

            }

            if (simCase.AssignedServer.FinishTime > simCase.ArrivalTime)
            {
                simCase.TimeInQueue = simCase.AssignedServer.FinishTime - simCase.ArrivalTime;
            }
        }

        public void handle_service_time(SimulationCase simCase)
        {
            simCase.RandomService = rnd.Next(1, 101);
            foreach (TimeDistribution time in simCase.AssignedServer.TimeDistribution)
            {
                if (simCase.RandomService >= time.MinRange && simCase.RandomService <= time.MaxRange)
                {
                    simCase.ServiceTime = time.Time;
                    break;
                }
            }

            simCase.StartTime = Math.Max(simCase.AssignedServer.FinishTime, simCase.ArrivalTime);
            simCase.EndTime = simCase.StartTime + simCase.ServiceTime;
        }

        ///////////// INPUTS ///////////// 
        public int NumberOfServers { get; set; }
        public int StoppingNumber { get; set; }
        public List<Server> Servers { get; set; }
        public List<TimeDistribution> InterarrivalDistribution { get; set; }
        public Enums.StoppingCriteria StoppingCriteria { get; set; }
        public Enums.SelectionMethod SelectionMethod { get; set; }

        ///////////// OUTPUTS /////////////
        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }

    }
}
