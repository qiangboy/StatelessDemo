using StatelessDemo;

var leave = new Leave { Id = 1, Status = LeaveStatus.Draft };
new LeaveManager(leave).Execute(LeaveAction.Submit);

Console.ReadKey();
