using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00010881_OOPTest
{
    public class Rent
    {
        public int Id { get; set; }

        public Customer Renter { get; set; }

        public Car RentedCar { get; set; }

        public DateTime DateTaken { get; set; }

        public int Duration { get; set; }

        public bool IsReturned { get; set; }

        public DateTime? ActualReturnDate { get; set; }

        public DateTime ExpectedReturnDate { get; set; }

        public Rent(Customer usr, Car cr, int duration)
        {
            Renter = usr;
            RentedCar = cr;
            cr.Status = CarStatus.Rented;
            DateTaken = DateTime.Now;
            Duration = duration;
            IsReturned = false;
            Renter.CarsCurrentlyRented.Add(RentedCar);
        }


        public void ReturnCar()
        {
            IsReturned = true;
            RentedCar.Status = CarStatus.Available;
            ActualReturnDate = DateTime.Now;
            Renter.CarsCurrentlyRented.Remove(RentedCar);
    }
    }




   
}
