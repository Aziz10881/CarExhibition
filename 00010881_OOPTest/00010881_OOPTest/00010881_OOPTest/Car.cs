using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00010881_OOPTest
{
    public abstract class Car
    {
        /// <summary>
        /// Requirement number 2
        /// All the cars should have id, name, fixed price, production year and other important characteristics.
        /// </summary>
        public int Id { get; set; }

        public string CarName { get; set; }

        public double FixedPrice { get; set; }

        public int ProductionYear { get; set; }

        public bool HasDiscount { get; set; }

        public string CarModelNumber { get; set; }

        public string Manufacturer { get; set; }

        public string Color { get; set; }

        public CarStatus Status { get; set; }


        
    }

    public enum CarStatus
    {
        Available,
        Reserved,
        Rented
    }
}
