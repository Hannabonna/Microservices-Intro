using System;

namespace customer_services.Domain.Entities
{
    public class PaymentEn
    {
        public int Id { get; set; }
        public int Customer_Id { get; set; }
        public string NameOnCard { get; set; }
        public string ExpMonth { get; set; }
        public string ExpYear { get; set; }
        public int PostalCode { get; set; }
        public string CreditCardNum { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public CustomerEn customer { get; set; }
    }
}