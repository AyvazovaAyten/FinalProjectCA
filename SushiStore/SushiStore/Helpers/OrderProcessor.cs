using SushiStore.Interfaces;
using SushiStore.Models;
using SushiStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiStore.Helpers
{
    public class OrderProcessor : IOrder
    {
        public StringBuilder ProcessOrder(List<CartProduct> cart, ShippingDetail shippingDetail)
        {
            StringBuilder body = new StringBuilder()
                    .AppendLine("New Order")
                    .AppendLine("---")
                    .AppendLine("Products:");

            decimal totalAmount = 0;

            foreach (CartProduct product in cart)
            {
                var subtotal = product.CurrentPrice * product.Quantity;
                body.AppendLine("<hr/>");
                body.AppendFormat("{0} x {1} (Total: {2:'AZN'})",
                    product.Quantity, product.Name, subtotal);
                body.AppendLine("<br/>");

                totalAmount = Decimal.Add(subtotal,totalAmount);

                body.AppendLine("<br/>");
            }


            body.AppendFormat("<h3>Total Amount: {0:c}", totalAmount +"</h3>")
                .AppendLine("<hr/>")
                .AppendLine("<h3>Shipping Details</h3>")
                .AppendLine("<h5>Name: " + shippingDetail.Name +"</h5>")
                .AppendLine("<h5>SurName: " + shippingDetail.SurName + "</h5>")
                .AppendLine("<h5>Phone Number: " + shippingDetail.PhoneNumber + "</h5>")
                .AppendLine("<h5>Adress: " + shippingDetail.Adress + "</h5>")
                .AppendLine("<h5>Adress(Line): " + shippingDetail.AdressLine + "</h5><br/>")
                .AppendLine(shippingDetail.TakeMyself ? "Take Myself" : "Deliver to Adress")
                .AppendLine("<hr/>");

            return (body);
        }
    }
}
