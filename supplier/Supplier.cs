using System;
using System.Collections.Generic;

namespace av2_net.SupplierDomain
{
    public class Supplier
    {
        public Supplier(string cnpj, string name, string registration, float earnings)
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
        }

        public Supplier(string cnpj, string name, string registration, float earnings, List<Product> products)
        {
            this.cnpj = cnpj;
            this.name = name;
            this.registration = registration;
            this.earnings = earnings;
            // this.address = address;
            this.products = products;
        }

        public uint id { get; set; }
        public string cnpj { get; set; }
        public string name { get; set; }
        public string registration { get; set; }
        public float earnings { get; set; }
        // public List<Address> addresses { get; set; }

        public List<Product> products { get; set; }

        public override string ToString()
        {
            return this.name + " | " + this.earnings;
        }
    }
}
