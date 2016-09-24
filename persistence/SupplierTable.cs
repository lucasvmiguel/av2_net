using System;
using System.Collections.Generic;
using av2_net.SupplierDomain;

namespace av2_net.Persistence
{
    class SupplierTable : ISupplierPersistence
    {
        private static SupplierTable instance;
        private List<Supplier> suppliers = new List<Supplier>();

        private SupplierTable() {}

        public static SupplierTable Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new SupplierTable();
                }
                return instance;
            }
        }

        public bool Add(Supplier t)
        {
            suppliers.Add(t);
            return true;
        }

        public List<Supplier> FindAll()
        {
            return suppliers;
        }
    }
}