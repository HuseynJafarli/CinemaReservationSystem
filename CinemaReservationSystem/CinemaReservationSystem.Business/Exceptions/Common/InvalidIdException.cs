using System.Runtime.Serialization;

namespace CinemaReservationSystem.Business.Exceptions.Common
{
    public class InvalidIdException : Exception
    {
        public int StatusCode { get; set; } = 400;
        public string? PropertyName { get; set; }
        public InvalidIdException()
        {
        }

        public InvalidIdException(string? message) : base(message)
        {
        }

        public InvalidIdException(int statusCode, string propertyName, string? message) : base(message)
        {
            StatusCode = statusCode;
            PropertyName = propertyName;
        }

    }
}
