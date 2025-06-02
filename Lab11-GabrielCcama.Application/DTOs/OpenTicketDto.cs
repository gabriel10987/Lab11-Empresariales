namespace Lab11_GabrielCcama.Application.DTOs;

public class OpenTicketDto
{
    public int TicketId { get; set; }
    public string Title { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
}