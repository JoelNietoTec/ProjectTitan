namespace TitanWebAPI.Models.Financial
{
    public class Bank
    {
        public int ID { get; set; }

        public int BankTypeID { get; set; }

        public virtual BankType BankType {get; set;}

        public string Name { get; set; }

        public string ShortName { get; set; }
    }
}