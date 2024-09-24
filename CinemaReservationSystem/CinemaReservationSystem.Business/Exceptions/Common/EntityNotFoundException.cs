namespace CinemaReservationSystem.Business.Exceptions.Common
{
    public class EntityNotFoundException : Exception
    {
        public int StatusCode { get; set; } = 404;
        public string? PropertyName { get; set; }
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string? message) : base(message)
        {
        }
        public EntityNotFoundException(int statusCode, string propertyName, string? message) : base(message)
        {
            StatusCode = statusCode;
            PropertyName = propertyName;
        }
    }
}
