using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00010881_OOPTest
{
   public class Booking
    {
        //properties
        public int Id { get; set; }

        public DateTime BookingDate { get; set; }

        public Customer User { get; set; }

        public string ReservedCarModelNumber { get; set; }

        public BookingStatus Status { get; set; }


        //constructor
        public Booking(Customer usr, string reservedCarModelNumber)
        {
            BookingDate = DateTime.Now;
            this.User = usr;
            ReservedCarModelNumber = reservedCarModelNumber;
            
        }


        // Mwthods
        public bool IsActive()
        {
            if (this.Status == BookingStatus.Active)
            {
                return true;
            }
            else
                return false;
        }

        public void Cancel()
        {
            Status = BookingStatus.Cancelled;
        }

        public void Fulfill()
        {
            Status = BookingStatus.Fulfilled;
        }
    }


    public enum BookingStatus
    {
        Active,
        Cancelled,
        Fulfilled
    }
}
