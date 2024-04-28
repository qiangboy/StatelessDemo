namespace StatelessDemo;

public enum LeaveStatus
{
    [Description("拒绝")]
    Rejected = -1,
    [Description("草稿")]
    Draft = 0,
    [Description("审批中")]
    UnderApprove = 1,
    [Description("审批通过")]
    Approved = 2
}