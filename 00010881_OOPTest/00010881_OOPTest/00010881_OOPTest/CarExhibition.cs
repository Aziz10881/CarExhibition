using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00010881_OOPTest
{
    /// <summary>
    /// requirement number 7
    /// Consider having a class CarExhibition containing the list of stored objects. 
    /// This class can have only one instance in the application.
    /// </summary>
    public class CarExhibition
    {
        public List<Customer> Customers { get; set; }

        public List<Car> Cars { get; set; }

        public List<Booking> Bookings { get; set; }

        public List<Rent> Rents { get; set; }

        //Constructor that creates the instances of the CarExhibition class
        private CarExhibition()
        {
            Customers = new List<Customer>();
            Cars = new List<Car>();
            Bookings = new List<Booking>();
            Rents = new List<Rent>();
        }

        //Singleton
        private static CarExhibition ourCarExhibition;

        public static  CarExhibition GetCarExhibition()
        {
            if (ourCarExhibition == null)
            {
                ourCarExhibition = new CarExhibition();
            }
            return ourCarExhibition;
        }


        //Returns the renting history of the customer
        /// <summary>
        /// Requirement number 3
        /// Display overall renting history of each customer should be possible in the system.
        /// </summary>
        /// <param name="usr"></param>
        /// <returns></returns>
         public Customer CustomerHistory(int Id)
        {
            foreach (Customer cstr in Customers)
            {
                if (cstr.Id.Equals(Id))
                {
                    DisplayCustomerHistory(cstr);
                    return cstr;
                }
            }
            return null;

        }

        public List<Rent> DisplayCustomerHistory(Customer usr)
        {
            List<Rent> history = new List<Rent>();

            foreach (Rent rnt in Rents)
            {
                if (rnt.Renter.Id.Equals(usr.Id))
                {
                    history.Add(rnt);
                }
            }
            return history;
        }



        //Calculates the price of the car with discount 
        /// <summary>
        /// Requirement number 4
        /// The system should allow calculation of the cars` sale prices through their
        /// fixed prices in case of 50% discount across all cars.
        /// </summary>
        /// <returns>Price with 50% discount</returns>
        public Car DisplayPriceWithDiscount(double DiscountedPrice)
        {
            foreach(Car cr in Cars)
            {
                if(cr.HasDiscount == true)
                {
                    CalculatePrice(DiscountedPrice);
                    return cr;
                }
            }
            return null;
        }
        
        public List<Car> CalculatePrice(double PriceWithDiscount)
        {
            List<Car> CarsWithDiscount = new List<Car>();

            foreach (Car cr in Cars)
            {
                if (cr.HasDiscount == true)
                {
                    PriceWithDiscount = cr.FixedPrice * 0.5;
                 CarsWithDiscount.Add(cr);
                }
            }
            return CarsWithDiscount;
        }

        //Returns customers who have rented a car before
        /// <summary>
        /// Requirement number 5
        /// Customers who have rented from WestCars before are given 15% discount for Classic cars only
        /// it's only for classic cars due to GetClassicDiscount() abstract method in Car class
        /// </summary>
        /// <returns></returns>
        public Customer SecondUseDiscount()
        {
            foreach(Customer cstr in Customers)
            {
                if(cstr.HasRentedBefore == true)
                {
                    GetDiscount();
                }
            }
            return null;
        }
        
        public List<Customer> GetDiscount()
        {
            List<Customer> CustumersWithDiscount = new List<Customer>();

            foreach (Customer csmr in Customers)
            {
                if (csmr.HasRentedBefore == true)
                {
                    CustumersWithDiscount.Add(csmr);
                }
            }
            return CustumersWithDiscount;
        }


        //books a car
        /// <summary>
        /// requirement number 6
        /// The system should allow booking cars for interested buyers/customers
        /// </summary>
        /// <param name="usr"></param>
        /// <param name="reservedCarModelNumber"></param>
        /// <returns></returns>
        public bool BookCar(Customer usr, string reservedCarModelNumber)
        {
            if (FindAllBookedCarsForCMN(reservedCarModelNumber) == null)
            {
                Booking bk = new Booking(usr, reservedCarModelNumber);
                Bookings.Add(bk);
                return true;
            }
            return false;
        }

        //Returns all available cars with CarModelNumber that were searched
        public Car FindAvailableCarByCMN(string CarModelNumber)
        {
            foreach (Car cr in Cars)
            {
                if (cr.CarModelNumber.Equals(CarModelNumber) && cr.Status == CarStatus.Available)
                {
                    return cr;
                }
            }
            return null;
        }

        public void ReturnRentedCar(Car cr)
        {
            foreach(Rent rentedcar in Rents)
            {
                if (!rentedcar.IsReturned)
                {
                    if(cr.Id == rentedcar.Id && cr.CarModelNumber.Equals(rentedcar.RentedCar.CarModelNumber))
                    {
                        rentedcar.ReturnCar();

                        List<Booking> allbk = FindAllBookingsForCarNumber(cr.CarModelNumber); 
                        int bookeddListLength = allbk.Count;
                        List<Car> allbkCar = FindAllBookedCarsForCMN(cr.CarModelNumber); 
                        int bookedCarListLength = allbkCar.Count;
                        if (bookeddListLength > bookedCarListLength) 
                        {
                            cr.Status = CarStatus.Reserved;
                        }
                    }
                }
            }
        }


        //This method returns all bokings for a certian car
        public List<Booking> FindAllBookingsForCarNumber(string CarModelNumber)
        {
            List<Booking> allBkForCarNumber = new List<Booking>();
            foreach(Booking bk in Bookings)
            {
                if (bk.IsActive() && bk.ReservedCarModelNumber.Equals(CarModelNumber))
                {
                    allBkForCarNumber.Add(bk);
                }
            }
            return allBkForCarNumber;
        }

        //this method returns all cars with carmodelnumber that were booked
        public List<Car> FindAllBookedCarsForCMN(string CarModelNumber)
        {
            List<Car> allBookingsForCMN = new List<Car>();
            foreach (Car cr in Cars)
            {
                if (cr.Status == CarStatus.Reserved && cr.CarModelNumber.Equals(CarModelNumber)) 
                    allBookingsForCMN.Add(cr); 
            }
            return allBookingsForCMN;
        }


    }
}
