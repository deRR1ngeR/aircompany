using System;

namespace Aircompany.Planes
{
    public class PassengerPlane : Plane
    {
        public readonly int _passengersCapacity; //readonly

        public PassengerPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, int passengersCapacity)
            :base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            _passengersCapacity = passengersCapacity;
        }

        public override bool Equals(object obj)
        {
            return obj is PassengerPlane plane && //as =>is
                   base.Equals(obj) &&
                   _passengersCapacity == plane._passengersCapacity;
        }

        public override int GetHashCode()
        {
            var hashCode = 751774561;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + _passengersCapacity.GetHashCode();
            return hashCode;
        }

        public int PassengersCapacityIs()
        {
            return _passengersCapacity;
        }

       
        public override string ToString()
        {
            return base.ToString().Replace("}",", passengersCapacity=" + _passengersCapacity +'}');
        }       
        
    }
}
