using SushiStore.Models;
using SushiStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiStore.Interfaces
{
    public interface IOrder
    {
        StringBuilder ProcessOrder(List<CartProduct> cart, ShippingDetail shippingDetail);
    }
}
