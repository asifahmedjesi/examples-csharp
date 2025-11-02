using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

[TaskDescriptor(Name = "The task's name", Description = "Some descriptions for the task", NeedsManager = true, DeveloperCount = 5)]
public class MyTasks
{
    [ManagerTask(Priority = Priorities.Medium, NeedsReport = true)]
    [DeveloperTask(Priorities.Low)]
    public void ScheduleMeeting()
    {

    }

    [ManagerTask(Priority = Priorities.Medium, NeedsReport = true)]
    [DeveloperTask(Priorities.Low)]
    [DeveloperTask(Priorities.High, Description = "High level description")]
    public virtual void ScheduleInterview()
    {

    }
}


public class YourTasks : MyTasks
{
    [DeveloperTask(Priorities.Medium, Description = "Mid level description")]
    public override void ScheduleInterview()
    {

    }
}