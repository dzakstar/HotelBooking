using AutoMapper;
using Core.Services;
using DAL.Abstractions;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace Core.Tests.Services
{
    [TestClass]
    public class BookingServiceTests
    {
        [TestClass]
        public class CheckAvailabilityAsync
        {
            private readonly IMapper _mapper = A.Fake<IMapper>();
            private readonly IBookingRepository _bookingRepository = A.Fake<IBookingRepository>();
            private readonly IRoomsRepository _roomsRepository = A.Fake<IRoomsRepository>();

            private readonly AvailabilityRequest _availabilityRequest = new()
            {
                    HotelId = A.Dummy<int>(),
                    NumberOfGuests = A.Dummy<int>(),
                    DepartureDate = A.Dummy<DateOnly>(),
                    ArrivalDate = A.Dummy<DateOnly>()
                };

            private BookingService _sut;

            [TestInitialize]
            public void Setup()
            {
                _sut = new BookingService(_bookingRepository, _mapper, _roomsRepository);
            }
            
            [TestMethod]
            public async Task WhenHotelIdIsNotProvided_ShouldThrowArgumentException()
            {
                // Arrange
                _availabilityRequest.HotelId = null;
                Func<Task> act = async () => await _sut.CheckAvailabilityAsync(_availabilityRequest);

                // Assert
                await act.Should().ThrowExactlyAsync<ArgumentException>().WithParameterName("availabilityRequest");
            }

            [TestMethod]
            public async Task WhenNumberOfGuestsIsNotProvided_ShouldThrowArgumentException()
            {
                // Arrange
                _availabilityRequest.NumberOfGuests = null;
                Func<Task> act = async () => await _sut.CheckAvailabilityAsync(_availabilityRequest);

                // Assert
                await act.Should().ThrowExactlyAsync<ArgumentException>().WithParameterName("availabilityRequest");
            }

            [TestMethod]
            public async Task WhenDepartureDateIsNotProvided_ShouldThrowArgumentException()
            {
                // Arrange
                _availabilityRequest.DepartureDate = null;
                Func<Task> act = async () => await _sut.CheckAvailabilityAsync(_availabilityRequest);

                // Assert
                await act.Should().ThrowExactlyAsync<ArgumentException>().WithParameterName("availabilityRequest");
            }

            [TestMethod]
            public async Task WhenArrivalDateIsNotProvided_ShouldThrowArgumentException()
            {
                // Arrange
                _availabilityRequest.ArrivalDate = null;
                Func<Task> act = async () => await _sut.CheckAvailabilityAsync(_availabilityRequest);

                // Assert
                await act.Should().ThrowExactlyAsync<ArgumentException>().WithParameterName("availabilityRequest");
            }
        }
    }
}
