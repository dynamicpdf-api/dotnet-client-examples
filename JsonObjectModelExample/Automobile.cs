
namespace JsonObjectModelExample
{
    public class Vehicle
    {
        public int mileage;
        public string brand;
        public string model;
        public string notes;
        public Tire[] tires;
    }

    public class Automobile : Vehicle
    {
        
    }

    public class Boat : Vehicle 
    {
        public int propellers;
    }

    public class Truck : Vehicle  
    {
        public int bedSize;
    }

    public class Tire
    {
        public string brand;
        public bool isGoodCondition;
    }


}
