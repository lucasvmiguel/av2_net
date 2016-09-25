using System;
using System.Collections.Generic;
using av2_net.ProcessDomain;

namespace av2_net.Persistence
{
    class ProcessTable
    {
        private uint index = 0;
        private static ProcessTable instance;
        private List<Process> processes = new List<Process>();

        private ProcessTable() {}

        public static ProcessTable Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new ProcessTable();
                }
                return instance;
            }
        }

        public bool Add(Process t)
        {
            index++;
            t.id = index;
            processes.Add(t);
            return true;
        }

        public List<Process> FindAll()
        {
            return processes;
        }

        public Process Find(uint id)
        {
            var index = processes.FindIndex(t => t.id == id);
            return processes[index];
        }

        public bool Edit(Process p)
        {
            var index = processes.FindIndex(t => t.id == p.id);
            processes[index] = p;
            return true;
        }

        public bool Remove(uint id)
        {
            var index = processes.FindIndex(t => t.id == id);
            processes.RemoveAt(index);
            return true;
        }
    }
}