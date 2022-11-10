using Aircompany.Models;
using Aircompany.Planes;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> _planes;
        public Airport(IEnumerable<Plane> planes)
        {
            _planes = planes.ToList();
        }
        public IEnumerable<PassengerPlane> GetPassengersPlanes()
        {
            return _planes.Where(t => t.GetType() == typeof(PassengerPlane)).Cast<PassengerPlane>().ToList();
        }
        public IEnumerable<MilitaryPlane> GetMilitaryPlanes()
        {
            return _planes.Where(p => p.GetType() == typeof(MilitaryPlane)).Cast<MilitaryPlane>().ToList();
        }
        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            var passengerPlanes = GetPassengersPlanes();
            return passengerPlanes.Aggregate((w, x) => w.PassengersCapacityIs() > x.PassengersCapacityIs() ? w : x);             
        }
        public IEnumerable<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            var militaryPlanes = GetMilitaryPlanes();
            return militaryPlanes.Where(plane => plane.GetPlaneType() == MilitaryType.Transport).ToList();
        }
        public Airport SortByMaxDistance()
        {
            return new Airport(_planes.OrderBy(w => w.MAXFlightDistance()));
        }
        public Airport SortByMaxSpeed()
        {
            return new Airport(_planes.OrderBy(w => w.GetMaxSpeed()));
        }
        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(_planes.OrderBy(w => w.GetMaxLoadCapacity()));
        }
        public IEnumerable<Plane> GetPlanes()
        {
            return _planes;
        }
        public override string ToString()
        {
            return "Airport{" +"planes=" + string.Join(", ", _planes.Select(x => x.GetModel())) +'}';
        }
    }
}
