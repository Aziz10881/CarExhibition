using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00010881_OOPTest
{
   public class Customer
    {
        private int _id;

        public int Id 
        { 
            get { return _id;}
            set {_id = value;} 
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DoB { get; set; }

        public string PhoneNumber { get; set; }

        public bool HasRentedBefore { get; set; }

        public List<Car> CarsCurrentlyRented { get; set; }
    }
}
