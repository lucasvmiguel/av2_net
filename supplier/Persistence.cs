using System.Collections.Generic;

namespace av2_net.SupplierDomain
{
    interface ISupplierPersistence
    {
        List<Supplier> FindAll();
        bool Add(Supplier t);
    }
}