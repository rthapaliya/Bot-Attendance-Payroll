using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Internals.Fibers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Attendance_Payroll.Model
{
    [Serializable]
    public class EmployeeDetails
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public RequestTypes requestTypes;
        public LeaveTypes leaveTypes;
        public IsApply isApply;
        public DateTime? LeaveDate;
        [Numeric(1, 10)]
        public int? NumberOfLeaveDays;

    }

    public static IForm<EmployeeDetails> BuildFrom()
    {
        return new FormBuilder<EmployeeDetails>()
            .Message("Welcome to Attendance Bot")
            .OnCompletion(async (context, profileForm) =>
            {
                await context.PostAsync("Thankyou");
            })
            .Build();
    }
}
    
    [Serializable]
    public enum RequestTypes
    {
        LeaveEncashment=1,
        Tour=2,
        OutdoorDuty=3,
        WorkFromHome=4,
        Compoff=5,
        MissPunch=6,
        SandwichLeave=7,
        LeaveAssignmentCycle=8
    }
    [Serializable]
    public enum LeaveTypes
    {
        SickLeave_SL=1,
        CasualLeave_CL=2,
        PaidLeave_PL=3,
        
    }
    [Serializable]
    public enum IsApply
    {
        Yes=1,
        No =2

    }

