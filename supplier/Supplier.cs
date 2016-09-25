using System;
using System.Collections.Generic;
using av2_net.ProcessDomain;

namespace av2_net.SupplierDomain
{
    public class Supplier
    {


        public uint id { get; set; }
        public string cnpj { get; set; }
        public string name { get; set; }
        public string registration { get; set; }
        public float earnings { get; set; }
        public List<Process> processes { get; set; }
        
        public Supplier(string cnpj, string name, string registration, float earnings, List<Process> processes)
        {
            if(cnpj == ""){
                throw new ArgumentException("CNPJ nao pode ser vazio");
            }

            if(name == ""){
                throw new ArgumentException("Nome nao pode ser vazio");
            }

            if(registration == ""){
                throw new ArgumentException("Registro nao pode ser vazio");
            }

            this.cnpj = cnpj;
            this.name = name;
            this.registration = registration;
            this.earnings = earnings;
            this.processes = processes;
        }

        public override string ToString()
        {
            return this.name + " | " + this.earnings;
        }
    }
}
