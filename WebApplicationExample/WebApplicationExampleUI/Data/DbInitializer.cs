using System.Runtime.InteropServices;
using WebApplicationExampleUI.Models;

namespace WebApplicationExampleUI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MyContext context)
        {
            context.Database.EnsureCreated();

            //Passengers passenger = new Passengers();
            //passenger.Userlogin = "123";
            //passenger.password = "123";
            //passenger.UserType = "user";
            //passenger.Name = "Никита";
            //passenger.Surname = "Краснокутский";
            //passenger.Patronymic = "Андреевич";
            //Airports airport = new Airports();
            //airport.AirportName = "Домодедово";
            //Aircrafts aircraft = new Aircrafts();
            //aircraft.PlaneType = "эконом";
            //aircraft.NumberOfSeats = 30;
            //Flights flights = new Flights();
            //flights.AircraftID = 1;
            //flights.AirportID = 1;
            //flights.Date = "15.10.2023";
            //flights.Arrival_Time = "15:00:00";
            //flights.Departure_Time = "13:00:00";
            //flights.Destination = "Москва";
            //context.Passengers.Add(passenger);
            //context.SaveChanges();
            //context.Airports.Add(airport);
            //context.SaveChanges();
            //context.Aircrafts.Add(aircraft);
            //context.SaveChanges();
            //context.Flights.Add(flights);
            //context.SaveChanges();
        }
    }
}
