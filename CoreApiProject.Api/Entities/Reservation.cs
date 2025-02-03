namespace CoreApiProject.Api.Entities;
public class Reservation
{
    public int ReservationId { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime ReservationDate { get; set; }
    public string ReservationTime { get; set; }
    public int CountofPeople { get; set; }
    public string Message { get; set; }
    public string ReservationStatus { get; set; }
}