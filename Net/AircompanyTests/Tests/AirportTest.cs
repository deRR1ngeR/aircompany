using Aircompany;
using Aircompany.Models;
using Aircompany.Planes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AircompanyTests.Tests
{
    [TestFixture]
    public class AirportTest
    {
        private readonly List<Plane> _planes = new List<Plane>(Runner.planes);
        private readonly PassengerPlane _planeWithMaxPassengerCapacity = new PassengerPlane("Boeing-747", 980, 16100, 70500, 242);
        private readonly List<Plane> _planesOrderedByMaxLoadCapacity = Runner.planes.OrderBy(x => x.GetMaxLoadCapacity()).ToList();

        [Test]
        public void MilitaryPlanesTransportIsExists()
        {
            Airport airport = new Airport(_planes);
            var militaryPlanesTransport = airport.GetTransportMilitaryPlanes().ToList();
            Assert.IsTrue(militaryPlanesTransport.Count !=0);
        }

        [Test]
        public void PlaneWithMaxPassengersCapacityIsExists()
        {
            Airport airport = new Airport(_planes);
            PassengerPlane expectedPlaneWithMaxPassengersCapacity = airport.GetPassengerPlaneWithMaxPassengersCapacity();           
            Assert.IsTrue(expectedPlaneWithMaxPassengersCapacity.Equals(_planeWithMaxPassengerCapacity));

        }

        [Test]
        public void PlanesMaxLoadCapacitySorting()
        {
            var airport = new Airport(_planes);
            var expectedPlanesSortedByMaxLoadCapacity = airport.SortByMaxLoadCapacity().GetPlanes().ToList();
            Assert.IsTrue(expectedPlanesSortedByMaxLoadCapacity.SequenceEqual(_planesOrderedByMaxLoadCapacity));

        }
    }
}
