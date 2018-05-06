namespace TitanWebAPI.Models.Financial
{
    public class FinancialProduct
    {
        public int ID { get; set; }

        public int ProductTypeID { get; set; }

        public virtual ProductType ProductType { get; set; }

        public string Name { get; set; }

        public string EnglishName { get; set; }
    }
}