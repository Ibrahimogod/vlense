namespace VlensePOC.Modes;

public class Step
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? NationalId { get; set; }
    public StepType StepType { get; set; }
    public bool IsSuccess { get; set; }
    
    public string? JobName { get; set; }
    
    public string? Error { get; set; }
    
    public DateTime CreateAt { get; set; }
    public Guid? ParentStepId { get; set; }
}