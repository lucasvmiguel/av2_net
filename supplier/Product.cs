namespace av2_net.SupplierDomain
{
    public class Product
    {
        public Product(string name, string brand, string stock, Supplier supplier)
        {
            this.name = name;
            this.brand = brand;
            this.stock = stock;
            this.supplier = supplier;
        }

        public uint id { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public string stock { get; set; }
        public Supplier supplier { get; set; }
    }
}
