namespace PrepareBill
{
    public enum CommodityCategory
    {
        Furniture,
        Grocery,
        Service
    }
    public class Commodity
    {
        public Commodity(CommodityCategory category, string commodityName, int commodityQuality, double commodityPrice)
        {
            category = Category;
            commodityName = CommodityName;
            commodityQuality = CommodityQuality;
            commodityPrice = CommodityPrice;
        }
        public CommodityCategory Category { get; set; }
        public string CommodityName { get; set; }
        public int CommodityQuality { get; set; }
        public double CommodityPrice { get; set; }
    }
    public class PrepareBill
    {
        public readonly IDictionary<CommodityCategory, double> _taxRates;
        public PrepareBill()
        { 
            _taxRates=new Dictionary<CommodityCategory, double>();
            
        }
        public void SetTaxRates(CommodityCategory category,double taxRate)
        {
            if (!_taxRates.ContainsKey(category))
            {
                _taxRates.Add(category, taxRate);
            }

            //Console.WriteLine(_taxRates);
        }
        public double CalculateBillAmount(IList<Commodity> items)
        {
            double totalAmount=0.0;
            foreach (var item in items)
            {
                if (!_taxRates.ContainsKey(item.Category))
                {
                    throw new ArgumentException();
                }
                totalAmount += (item.CommodityQuality * item.CommodityPrice) + ((item.CommodityQuality * item.CommodityPrice) * _taxRates[item.Category] / 100);

            }
            return totalAmount;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var Commodities = new List<Commodity>()
            {
                new Commodity(CommodityCategory.Furniture,"Bed",2,500000),
                new Commodity(CommodityCategory.Grocery,"Flour",5,80),
                new Commodity(CommodityCategory.Service, "Insurance", 8, 8500)

            };
            var prepareBill=new PrepareBill();
            prepareBill.SetTaxRates(CommodityCategory.Furniture,18);
            prepareBill.SetTaxRates(CommodityCategory.Grocery, 5);
            prepareBill.SetTaxRates(CommodityCategory.Service, 12);
            var billAmount = prepareBill.CalculateBillAmount(Commodities);
            Console.WriteLine($" {billAmount} ");

        }
    }
}
