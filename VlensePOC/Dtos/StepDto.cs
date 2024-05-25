namespace VlensePOC.Dtos;

public class StepDto
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? NationalId { get; set; }
    public bool IsSuccess { get; set; }

    public string? JobName { get; set; }

    public List<string>? Errors { get; set; }

    public DateTime CreateAt { get; set; }
}