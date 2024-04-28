namespace StatelessDemo;

public class Leave
{
    public long Id { get; set; }
    public LeaveStatus Status { get; set; }
    public DateTime? FirSaveTime { get; set; }
    public DateTime? SubmitTime { get; set; }
    public DateTime? PassTime { get; set; }
    public DateTime? RejectTime { get; set; }
}