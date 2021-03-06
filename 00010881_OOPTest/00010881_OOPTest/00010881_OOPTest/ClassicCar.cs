﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00010881_OOPTest
{
    /// <summary>
    /// Requirement number 1
    /// There are two types of Cars: Classic Car and Sports Car.
    /// </summary>
    public class ClassicCar : Car
    {
        public string ManufacturedCountry { get; set; }

        public double GetClassicDiscount()
        {
            FixedPrice = (int)(FixedPrice * 0.15);
            return FixedPrice;
        }
    }
}
