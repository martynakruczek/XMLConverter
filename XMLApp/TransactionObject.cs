using System.Collections.Generic;
using System.Xml.Serialization;

namespace XMLApp
{
    [XmlRoot(ElementName = "ExportSettings")]
    public class ExportSettings
    {
        [XmlElement(ElementName = "FromDate")]
        public string FromDate { get; set; }
        [XmlElement(ElementName = "ToDate")]
        public string ToDate { get; set; }
        [XmlElement(ElementName = "Sections")]
        public string Sections { get; set; }
    }

    [XmlRoot(ElementName = "BuyerAddress")]
    public class BuyerAddress
    {
        [XmlElement(ElementName = "FullName")]
        public string FullName { get; set; }
        [XmlElement(ElementName = "Company")]
        public string Company { get; set; }
        [XmlElement(ElementName = "Phone")]
        public string Phone { get; set; }
        [XmlElement(ElementName = "Address")]
        public string Address { get; set; }
        [XmlElement(ElementName = "Zip")]
        public string Zip { get; set; }
        [XmlElement(ElementName = "City")]
        public string City { get; set; }
        [XmlElement(ElementName = "CountryName")]
        public string CountryName { get; set; }
    }

    [XmlRoot(ElementName = "DeliveryAddress")]
    public class DeliveryAddress
    {
        [XmlElement(ElementName = "FullName")]
        public string FullName { get; set; }
        [XmlElement(ElementName = "Company")]
        public string Company { get; set; }
        [XmlElement(ElementName = "Phone")]
        public string Phone { get; set; }
        [XmlElement(ElementName = "Address")]
        public string Address { get; set; }
        [XmlElement(ElementName = "Zip")]
        public string Zip { get; set; }
        [XmlElement(ElementName = "City")]
        public string City { get; set; }
        [XmlElement(ElementName = "CountryName")]
        public string CountryName { get; set; }
    }

    [XmlRoot(ElementName = "Deal")]
    public class Deal
    {
        [XmlElement(ElementName = "Id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "AukroDealId")]
        public string AukroDealId { get; set; }
        [XmlElement(ElementName = "AukroOfferId")]
        public string AukroOfferId { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Quantity")]
        public string Quantity { get; set; }
        [XmlElement(ElementName = "Price")]
        public string Price { get; set; }
        [XmlElement(ElementName = "SoldAt")]
        public string SoldAt { get; set; }
        [XmlElement(ElementName = "Signature")]
        public string Signature { get; set; }
        [XmlElement(ElementName = "ExternalId")]
        public string ExternalId { get; set; }
    }

    [XmlRoot(ElementName = "Deals")]
    public class Deals
    {
        [XmlElement(ElementName = "Deal")]
        public List<Deal> Deal { get; set; }
    }

    [XmlRoot(ElementName = "Transaction")]
    public class Transaction
    {
        [XmlElement(ElementName = "Id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "AukroTransactionId")]
        public string AukroTransactionId { get; set; }
        [XmlElement(ElementName = "TransactionNumber")]
        public string TransactionNumber { get; set; }
        [XmlElement(ElementName = "CreatedDate")]
        public string CreatedDate { get; set; }
        [XmlElement(ElementName = "BuyerFullName")]
        public string BuyerFullName { get; set; }
        [XmlElement(ElementName = "BuyerUsername")]
        public string BuyerUsername { get; set; }
        [XmlElement(ElementName = "BuyerAddress")]
        public BuyerAddress BuyerAddress { get; set; }
        [XmlElement(ElementName = "DeliveryAddress")]
        public DeliveryAddress DeliveryAddress { get; set; }
        [XmlElement(ElementName = "BuyerEmail")]
        public string BuyerEmail { get; set; }
        [XmlElement(ElementName = "TransactionPrice")]
        public string TransactionPrice { get; set; }
        [XmlElement(ElementName = "TotalPrice")]
        public string TotalPrice { get; set; }
        [XmlElement(ElementName = "DeliveryPrice")]
        public string DeliveryPrice { get; set; }
        [XmlElement(ElementName = "Shipment")]
        public string Shipment { get; set; }
        [XmlElement(ElementName = "PaymentType")]
        public string PaymentType { get; set; }
        [XmlElement(ElementName = "PaymentState")]
        public string PaymentState { get; set; }
        [XmlElement(ElementName = "PaidAmount")]
        public string PaidAmount { get; set; }
        [XmlElement(ElementName = "PaidAt")]
        public string PaidAt { get; set; }
        [XmlElement(ElementName = "Section")]
        public string Section { get; set; }
        [XmlElement(ElementName = "Deals")]
        public Deals Deals { get; set; }
        [XmlElement(ElementName = "Notes")]
        public Notes Notes { get; set; }
    }

    [XmlRoot(ElementName = "Note")]
    public class Note
    {
        [XmlElement(ElementName = "Author")]
        public string Author { get; set; }
        [XmlElement(ElementName = "Date")]
        public string Date { get; set; }
        [XmlElement(ElementName = "Text")]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Notes")]
    public class Notes
    {
        [XmlElement(ElementName = "Note")]
        public List<Note> Note { get; set; }
    }

    [XmlRoot(ElementName = "Transactions")]
    public class Transactions
    {
        [XmlElement(ElementName = "Transaction")]
        public List<Transaction> Transaction { get; set; }
    }

    [XmlRoot(ElementName = "ExportFromSM")]
    public class ExportFromSM
    {
        [XmlElement(ElementName = "ExportSettings")]
        public ExportSettings ExportSettings { get; set; }
        [XmlElement(ElementName = "Transactions")]
        public Transactions Transactions { get; set; }
    }

}
