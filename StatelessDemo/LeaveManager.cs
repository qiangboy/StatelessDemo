namespace StatelessDemo;

public class LeaveManager
{
    private readonly Leave _leave;

    private readonly StateMachine<LeaveStatus, LeaveAction> _machine;
    //StateMachine<LeaveStatus, LeaveAction>.TriggerWithParameters<string> _triggerWithPara;

    public LeaveManager(Leave leave)
    {
        _leave = leave;
        _machine = new StateMachine<LeaveStatus, LeaveAction>(() => leave.Status, s => leave.Status = s);
        _machine.OnUnhandledTrigger((status, action) => throw new FriendlyException($"请假的状态为{status.GetDescription()}，不可以执行{action.GetDescription()}")); //重写抛异常的方法
        Configure();
    }

    public void Execute(LeaveAction action)
    {
        _machine.Fire(action);
    }

    private void Configure()
    {
        _machine.Configure(LeaveStatus.Draft)
            .OnEntry(OnSaveEntry)
            .OnExit(OnSaveExit)
            .PermitReentry(LeaveAction.Save)
            .Permit(LeaveAction.Submit, LeaveStatus.UnderApprove);
        //.Ignore(LeaveAction.Save);
        _machine.Configure(LeaveStatus.UnderApprove)
            .OnEntry(OnSubmitEntry)
            .OnExit(OnSubmitExit)
            .PermitReentry(LeaveAction.Submit)
            .Permit(LeaveAction.Save, LeaveStatus.Draft)
            .Permit(LeaveAction.Pass, LeaveStatus.Approved)
            .Permit(LeaveAction.Reject, LeaveStatus.Rejected);
    }

    private void OnSaveExit(StateMachine<LeaveStatus, LeaveAction>.Transition obj)
    {

    }

    private void OnSaveEntry(StateMachine<LeaveStatus, LeaveAction>.Transition obj)
    {
        _leave.FirSaveTime ??= DateTime.Now;
    }

    private void OnSubmitExit(StateMachine<LeaveStatus, LeaveAction>.Transition obj)
    {

    }

    private void OnSubmitEntry(StateMachine<LeaveStatus, LeaveAction>.Transition obj)
    {
        _leave.SubmitTime ??= DateTime.Now;
    }
}