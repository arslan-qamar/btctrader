using System;
using System.Collections.Generic;
using System.Text;

namespace BTCTrader.Entities.Order
{
    public class OrderStatus
    {
        public const string Accepted = "Accepted";
        public const string Placed = "Placed";
        public const string Partially_Matched = "Partially Matched";
        public const string Fully_Matched = "Fully Matched";
        public const string Cancelled = "Cancelled";
        public const string Partially_Cancelled = "Partially_Cancelled";
        public const string Failed = "Failed";
    }
}
