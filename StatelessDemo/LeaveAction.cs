namespace StatelessDemo;

public enum LeaveAction
{
    [Description("拒绝")]
    Reject = -1,
    [Description("保存")]
    Save = 0,
    [Description("提交")]
    Submit = 1,
    [Description("审批通过")]
    Pass = 2,
}