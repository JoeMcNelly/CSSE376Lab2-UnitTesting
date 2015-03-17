using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        private readonly DateTime leaveDate = new DateTime(2013, 10, 6);
        
        [Test()]
        public void TestThatFlightInitializes()
        {
            DateTime secondDate = new DateTime(2013, 10, 7);
            var target = new Flight(leaveDate, secondDate, 500);
            Assert.IsNotNull(target);
        }
        [Test()]
        public void TestOneDayFlightCost()
        {
            DateTime secondDate = new DateTime(2013, 10, 7);
            var target = new Flight(leaveDate, secondDate, 500);
            Assert.AreEqual(220, target.getBasePrice());
        }
        [Test()]
        public void TestTwoDayFlightCost()
        {
            DateTime secondDate = new DateTime(2013, 10, 8);
            var target = new Flight(leaveDate, secondDate, 500);
            Assert.AreEqual(240, target.getBasePrice());
        }
        [Test()]
        public void TestTenDayFlightCost()
        {
            DateTime secondDate = new DateTime(2013, 10, 16);
            var target = new Flight(leaveDate, secondDate, 500);
            Assert.AreEqual(400, target.getBasePrice());
        }
        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightHandlesNegativeMiles()
        {
            DateTime secondDate = new DateTime(2013, 10, 7);
            new Flight(leaveDate, secondDate, -100);
        }
        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightHandlesBadDates()
        {
            DateTime secondDate = new DateTime(2013, 9, 7);
            new Flight(leaveDate, secondDate, 100);
        }
	}
}
