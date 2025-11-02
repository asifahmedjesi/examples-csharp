using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

public enum Priorities
{
    Low,
    Medium,
    High
}


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class TaskDescriptorAttribute : Attribute
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool NeedsManager { get; set; }
    public int DeveloperCount { get; set; }
}


[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class DeveloperTaskAttribute : Attribute
{
    public Priorities Priority { get; set; }
    public string? Description { get; set; }
    public DeveloperTaskAttribute(Priorities priority)
    {
        Priority = priority;
    }
}


[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public class ManagerTaskAttribute : Attribute
{
    public Priorities Priority { get; set; }
    public bool NeedsReport { get; set; }
}