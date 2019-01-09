using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace XMLApp
{
    class ConvertService
    {

        static string GetOrderID(List<Deal> list)
        {
            var orderIdList = new List<string>();
            foreach (var item in list)
            {
                orderIdList.Add(item.AukroOfferId);
            }
            var result = string.Join(", ", orderIdList.ToArray());
            return result;
        }

        static string GetNames(List<Deal> list)
        {
            var namesList = new List<string>();
            foreach (var item in list)
            {
                namesList.Add(item.Name);
            }
            var result = string.Join(", ", namesList.ToArray());
            return result;
        }

        static string GetNamesPolish(List<Product> list)
        {
            var namesList = new List<string>();
            foreach (var item in list)
            {
                namesList.Add(item.Name);
            }
            var result = string.Join(", ", namesList.ToArray());
            return result;
        }

        static string GetOrderIDPolish(List<Product> list)
        {
            var orderIdList = new List<string>();
            foreach (var item in list)
            {
                orderIdList.Add(item.Code);
            }
            var result = string.Join(", ", orderIdList.ToArray());
            return result;
        }

        public void ConvertXML(string path)
        {

            List<Transaction> list = new List<Transaction>();
            XmlSerializer serializer = new XmlSerializer(typeof(ExportFromSM));
            XmlReaderSettings settings = new XmlReaderSettings
            {
                Async = true
            };
            ExportFromSM result = new ExportFromSM();
            using (XmlReader reader = XmlReader.Create(path, settings))
            {
                result = (ExportFromSM)serializer.Deserialize(reader);
            }
            string text = DateTime.Now.ToString("MM'.'dd'.'yyyy-HH'-'mm'-'ss");
            using (XmlWriter writer = XmlWriter.Create($"{text}.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("transactions");
                writer.WriteStartElement("range");
                writer.WriteElementString("from", result.ExportSettings.FromDate);
                writer.WriteElementString("to", result.ExportSettings.ToDate);
                writer.WriteElementString("sections", result.ExportSettings.Sections);
                writer.WriteEndElement();

                foreach (Transaction transaction in result.Transactions.Transaction)
                {
                    writer.WriteStartElement("transaction");
                    writer.WriteElementString("parentId", transaction.Id);
                    writer.WriteElementString("Name", GetNames(transaction.Deals.Deal));
                    writer.WriteElementString("CustomerName", transaction.BuyerFullName);
                    writer.WriteElementString("CustomerPhone", transaction.BuyerAddress.Phone);
                    writer.WriteElementString("CustomerAddress", transaction.BuyerAddress.Address);
                    writer.WriteElementString("CustomerZip", transaction.BuyerAddress.Zip);
                    writer.WriteElementString("CustomerCity", transaction.BuyerAddress.City);
                    writer.WriteElementString("CustomerCountryCode", "CZ");
                    writer.WriteElementString("CustomerCountryName", transaction.BuyerAddress.CountryName);
                    writer.WriteElementString("OrderId", GetOrderID(transaction.Deals.Deal));
                    writer.WriteElementString("InvoiceName", transaction.BuyerFullName);
                    writer.WriteElementString("InvoiceCompanyName", transaction.BuyerFullName);
                    writer.WriteElementString("InvoiceAddress", transaction.BuyerAddress.Address);
                    writer.WriteElementString("InvoiceZip", transaction.BuyerAddress.Zip);
                    writer.WriteElementString("InvoiceCity", transaction.BuyerAddress.City);
                    writer.WriteElementString("InvoiceCountryCode", "CZ");
                    writer.WriteElementString("InvoiceCountryName", transaction.BuyerAddress.CountryName);
                    writer.WriteElementString("VAT-ID", null);
                    writer.WriteElementString("Id", transaction.TransactionNumber);
                    writer.WriteElementString("Total", transaction.TotalPrice);
                    writer.WriteElementString("CustomerEmail", transaction.BuyerEmail);
                    writer.WriteElementString("PaymentType", transaction.PaymentType);
                    writer.WriteElementString("Currency", "CZK");
                    writer.WriteElementString("DeliveryCost", transaction.DeliveryPrice);
                    writer.WriteElementString("DeliveryType", transaction.Shipment);
                    writer.WriteElementString("CustomerLogin", transaction.BuyerUsername);
                    writer.WriteElementString("RecipientName", transaction.BuyerFullName);
                    writer.WriteElementString("RecipientCompanyName", transaction.BuyerFullName);
                    writer.WriteElementString("RecipientPhone", transaction.BuyerAddress.Phone);
                    writer.WriteElementString("RecipientAddress", transaction.BuyerAddress.Address);
                    writer.WriteElementString("RecipientZip", transaction.BuyerAddress.Zip);
                    writer.WriteElementString("RecipientCity", transaction.BuyerAddress.City);
                    writer.WriteElementString("RecipientCountryCode", "CZ");
                    writer.WriteElementString("RecipientCountryName", transaction.BuyerAddress.CountryName);
                    writer.WriteElementString("ExchangeRate", "1");
                    writer.WriteElementString("SellDate", transaction.PaidAt);

                    if (transaction.Deals.Deal.Count() > 1)
                    {
                        writer.WriteStartElement("subtransactions");
                        foreach (var deal in transaction.Deals.Deal)
                        {
                            writer.WriteStartElement("subtransaction");
                            writer.WriteElementString("transactionId", deal.Id);
                            writer.WriteElementString("Name", deal.Name);
                            writer.WriteElementString("OrderId", deal.AukroOfferId);
                            writer.WriteElementString("Id", deal.AukroDealId);
                            writer.WriteElementString("SellDate", deal.SoldAt);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteStartElement("positions");

                    foreach (var deal in transaction.Deals.Deal)
                    {
                        writer.WriteStartElement("position");
                        writer.WriteElementString("transactionId", deal.Id);
                        writer.WriteElementString("Name", deal.Name);
                        writer.WriteElementString("Price", deal.Price);
                        writer.WriteElementString("Quantity", deal.Quantity);
                        writer.WriteElementString("OfferName", deal.Name);
                        writer.WriteElementString("Signature", deal.Signature);
                        writer.WriteEndElement();

                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
        public void ConvertPolishXML(string path)
        {
            List<Transaction> list = new List<Transaction>();
            XmlSerializer serializer = new XmlSerializer(typeof(Orders));
            XmlReaderSettings settings = new XmlReaderSettings
            {
                Async = true
            };
            Orders result = new Orders();
            using (XmlReader reader = XmlReader.Create(path, settings))
            {
                result = (Orders)serializer.Deserialize(reader);
            }
            string text = DateTime.Now.ToString("MM'.'dd'.'yyyy-HH'-'mm'-'ss");

            using (XmlWriter writer = XmlWriter.Create($"{text}.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("transactions");
                writer.WriteStartElement("range");
                writer.WriteElementString("from", null);// todo
                writer.WriteElementString("to", null); // todo
                writer.WriteElementString("sections", null);// todo
                writer.WriteEndElement();

                foreach (Order order in result.Order)
                {
                    writer.WriteStartElement("transaction");
                    writer.WriteElementString("parentId", null);
                    writer.WriteElementString("Name", GetNamesPolish(order.Products.Product));
                    writer.WriteElementString("CustomerName", order.Info.DeliveryAdess.Name);
                    writer.WriteElementString("CustomerPhone", order.Info.DeliveryAdess.Phone);
                    writer.WriteElementString("CustomerAddress", order.Info.DeliveryAdess.Adress);
                    writer.WriteElementString("CustomerZip", order.Info.DeliveryAdess.ZipCode);
                    writer.WriteElementString("CustomerCity", order.Info.DeliveryAdess.City);
                    writer.WriteElementString("CustomerCountryCode", "PL");
                    writer.WriteElementString("CustomerCountryName", "Polska");
                    writer.WriteElementString("OrderId", GetOrderIDPolish(order.Products.Product));
                    writer.WriteElementString("InvoiceName", order.Info.InvoiceNumber);
                    writer.WriteElementString("InvoiceCompanyName", order.Info.BillingInformation.Company);
                    writer.WriteElementString("InvoiceAddress", order.Info.DeliveryAdess.Adress);
                    writer.WriteElementString("InvoiceZip", order.Info.DeliveryAdess.ZipCode);
                    writer.WriteElementString("InvoiceCity", order.Info.DeliveryAdess.City);
                    writer.WriteElementString("InvoiceCountryCode", "PL");
                    writer.WriteElementString("InvoiceCountryName", "Polska");
                    writer.WriteElementString("VAT-ID", null);
                    writer.WriteElementString("Id", order.Info.OrderID);
                    writer.WriteElementString("Total", order.Info.Total);
                    writer.WriteElementString("CustomerEmail", order.Info.DeliveryAdess.Email);
                    writer.WriteElementString("PaymentType", order.Info.PaidName);
                    writer.WriteElementString("Currency", "ZŁ");
                    writer.WriteElementString("DeliveryCost", order.Info.PostagePrice);
                    writer.WriteElementString("DeliveryType", order.Info.PostageName);
                    writer.WriteElementString("CustomerLogin", order.Info.BillingInformation.Email);
                    writer.WriteElementString("RecipientName", order.Info.BillingInformation.Name);
                    writer.WriteElementString("RecipientCompanyName", order.Info.BillingInformation.Company);
                    writer.WriteElementString("RecipientPhone", order.Info.BillingInformation.Phone);
                    writer.WriteElementString("RecipientAddress", order.Info.BillingInformation.Adress);
                    writer.WriteElementString("RecipientZip", order.Info.BillingInformation.ZipCode);
                    writer.WriteElementString("RecipientCity", order.Info.BillingInformation.City);
                    writer.WriteElementString("RecipientCountryCode", "PL");
                    writer.WriteElementString("RecipientCountryName", "Polska");
                    writer.WriteElementString("ExchangeRate", "1");
                    writer.WriteElementString("SellDate", null);//todo

                    if (order.Products.Product.Count() > 1)
                    {
                        writer.WriteStartElement("subtransactions");
                        foreach (var product in order.Products.Product)
                        {
                            writer.WriteStartElement("subtransaction");
                            writer.WriteElementString("transactionId", order.Info.OrderID);
                            writer.WriteElementString("Name", product.Name);
                            writer.WriteElementString("OrderId", product.Code);
                            writer.WriteElementString("Id", null);
                            writer.WriteElementString("SellDate", null);//todo
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteStartElement("positions");

                    foreach (var product in order.Products.Product)
                    {
                        writer.WriteStartElement("position");
                        writer.WriteElementString("transactionId", order.Info.OrderID);
                        writer.WriteElementString("Name", null);
                        writer.WriteElementString("Price", product.PriceIncldVAT);
                        writer.WriteElementString("Quantity", product.Pieces);
                        writer.WriteElementString("OfferName", product.Name);
                        writer.WriteElementString("Signature", null); //todo
                        writer.WriteEndElement();

                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
            }
        }
    }
}
