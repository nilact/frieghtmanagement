﻿namespace FrieghtManagment.Models
{
    internal class Order
    {
        public int Priority { get; set; }
        public string Ordernumber { get; set; }
        public string Destination { get; set; }
        public Schedule Schedule { get; set; }

        public bool IsNotLoaded()
        {
            return Schedule == null;
        }
    }
}
