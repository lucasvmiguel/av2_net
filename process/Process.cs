using System;
using System.Collections.Generic;
using av2_net.SupplierDomain;

namespace av2_net.ProcessDomain
{
    public class Process
    {
        public Process(string report, DateTime date, string reporter, Supplier supplier)
        {
            if(report == ""){
                throw new ArgumentException("Relatorio nao pode ser vazio");
            }

            if(reporter == ""){
                throw new ArgumentException("Fiscal nao pode ser vazio");
            }

            this.report = report;
            this.date = date;
            this.reporter = reporter;
            this.supplier = supplier;
        }

        public uint id { get; set; }
        public string report { get; set; }
        public DateTime date { get; set; }
        public string reporter { get; set; }
        public Supplier supplier { get; set; }

        public override string ToString()
        {
            return this.report + " | " + this.reporter + " | " + this.date.ToString();
        }
    }
}
