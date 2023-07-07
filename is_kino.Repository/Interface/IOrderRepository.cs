﻿using is_kino.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace is_kino.Repository.Interface
{
    public interface IOrderRepository
    {

        public List<Order> getAllOrders();
        public Order getOrderDetails(BaseEntity model);

    }
}
