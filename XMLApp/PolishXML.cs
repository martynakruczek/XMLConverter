using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace XMLApp
{
    [XmlRoot(ElementName = "deliveryAdess")]
    public class DeliveryAdess
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "adress")]
        public string Adress { get; set; }
        [XmlElement(ElementName = "city")]
        public string City { get; set; }
        [XmlElement(ElementName = "zipCode")]
        public string ZipCode { get; set; }
        [XmlElement(ElementName = "email")]
        public string Email { get; set; }
        [XmlElement(ElementName = "phone")]
        public string Phone { get; set; }
        [XmlElement(ElementName = "company")]
        public string Company { get; set; }
        [XmlElement(ElementName = "companyRegNumber")]
        public string CompanyRegNumber { get; set; }
        [XmlElement(ElementName = "taxRegNumber")]
        public string TaxRegNumber { get; set; }
        [XmlElement(ElementName = "VATRegNumber")]
        public string VATRegNumber { get; set; }
    }

    [XmlRoot(ElementName = "billingInformation")]
    public class BillingInformation
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "adress")]
        public string Adress { get; set; }
        [XmlElement(ElementName = "city")]
        public string City { get; set; }
        [XmlElement(ElementName = "zipCode")]
        public string ZipCode { get; set; }
        [XmlElement(ElementName = "email")]
        public string Email { get; set; }
        [XmlElement(ElementName = "phone")]
        public string Phone { get; set; }
        [XmlElement(ElementName = "company")]
        public string Company { get; set; }
        [XmlElement(ElementName = "companyRegNumber")]
        public string CompanyRegNumber { get; set; }
        [XmlElement(ElementName = "taxRegNumber")]
        public string TaxRegNumber { get; set; }
        [XmlElement(ElementName = "VATRegNumber")]
        public string VATRegNumber { get; set; }
    }

    [XmlRoot(ElementName = "info")]
    public class Info
    {
        [XmlElement(ElementName = "orderID")]
        public string OrderID { get; set; }
        [XmlElement(ElementName = "date")]
        public string Date { get; set; }
        [XmlElement(ElementName = "invoiceDate")]
        public string InvoiceDate { get; set; }
        [XmlElement(ElementName = "maturityDate")]
        public string MaturityDate { get; set; }
        [XmlElement(ElementName = "DateOfTheChargeableEvent")]
        public string DateOfTheChargeableEvent { get; set; }
        [XmlElement(ElementName = "total")]
        public string Total { get; set; }
        [XmlElement(ElementName = "totalIncldVAT")]
        public string TotalIncldVAT { get; set; }
        [XmlElement(ElementName = "discountPercentage")]
        public string DiscountPercentage { get; set; }
        [XmlElement(ElementName = "discount")]
        public string Discount { get; set; }
        [XmlElement(ElementName = "postageName")]
        public string PostageName { get; set; }
        [XmlElement(ElementName = "postagePrice")]
        public string PostagePrice { get; set; }
        [XmlElement(ElementName = "postageNote")]
        public string PostageNote { get; set; }
        [XmlElement(ElementName = "paidName")]
        public string PaidName { get; set; }
        [XmlElement(ElementName = "paidPrice")]
        public string PaidPrice { get; set; }
        [XmlElement(ElementName = "paidNote")]
        public string PaidNote { get; set; }
        [XmlElement(ElementName = "paidRemark")]
        public string PaidRemark { get; set; }
        [XmlElement(ElementName = "paid")]
        public string Paid { get; set; }
        [XmlElement(ElementName = "completed")]
        public string Completed { get; set; }
        [XmlElement(ElementName = "payerVAT")]
        public string PayerVAT { get; set; }
        [XmlElement(ElementName = "invoiceNumber")]
        public string InvoiceNumber { get; set; }
        [XmlElement(ElementName = "variableSymbol")]
        public string VariableSymbol { get; set; }
        [XmlElement(ElementName = "invoiceType")]
        public string InvoiceType { get; set; }
        [XmlElement(ElementName = "noteCustomer")]
        public string NoteCustomer { get; set; }
        [XmlElement(ElementName = "noteInvoice")]
        public string NoteInvoice { get; set; }
        [XmlElement(ElementName = "deliveryAdess")]
        public DeliveryAdess DeliveryAdess { get; set; }
        [XmlElement(ElementName = "billingInformation")]
        public BillingInformation BillingInformation { get; set; }
    }

    [XmlRoot(ElementName = "product")]
    public class Product
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "code")]
        public string Code { get; set; }
        [XmlElement(ElementName = "price")]
        public string Price { get; set; }
        [XmlElement(ElementName = "priceIncldVAT")]
        public string PriceIncldVAT { get; set; }
        [XmlElement(ElementName = "tax")]
        public string Tax { get; set; }
        [XmlElement(ElementName = "pieces")]
        public string Pieces { get; set; }
        [XmlElement(ElementName = "unitOfMeasure")]
        public string UnitOfMeasure { get; set; }
        [XmlElement(ElementName = "parameter1")]
        public string Parameter1 { get; set; }
        [XmlElement(ElementName = "parameter2")]
        public string Parameter2 { get; set; }
        [XmlElement(ElementName = "parameter3")]
        public string Parameter3 { get; set; }
        [XmlElement(ElementName = "weight")]
        public string Weight { get; set; }
        [XmlElement(ElementName = "postageSurcharge")]
        public string PostageSurcharge { get; set; }
        [XmlElement(ElementName = "postageName")]
        public string PostageName { get; set; }
        [XmlElement(ElementName = "noteCustomer")]
        public string NoteCustomer { get; set; }
        [XmlElement(ElementName = "producer")]
        public string Producer { get; set; }
    }

    [XmlRoot(ElementName = "products")]
    public class Products
    {
        [XmlElement(ElementName = "product")]
        public List<Product> Product { get; set; }
    }

    [XmlRoot(ElementName = "order")]
    public class Order
    {
        [XmlElement(ElementName = "info")]
        public Info Info { get; set; }
        [XmlElement(ElementName = "products")]
        public Products Products { get; set; }
    }

    [XmlRoot(ElementName = "orders")]
    public class Orders
    {
        [XmlElement(ElementName = "order")]
        public List<Order> Order { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
        [XmlAttribute(AttributeName = "ICO")]
        public string ICO { get; set; }
    }

}
