using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Attendance_Payroll.Dialogs
{
    [Serializable]
    public class LeaveFormFlow
    {

        public LeaveTypes leaveTypes;


        
        public DateTime? ForLeaveEncashmnet;


        [Prompt("What is your employee id")]
        public String EmployeeId { get; set; }


        public static IForm<LeaveFormFlow> LeaveEncashmentForm()
        {
            return new FormBuilder<LeaveFormFlow>()
                .Message(" Do You want to encash your remaining leaves???.")//printing msg to bot
                .Message("Can I know your EmployeedID???")
                .Field(nameof(EmployeeId))//calling fileds with priority
                .Message("Ok so your EmpId is {EmployeeId}")
                .Field(nameof(EmployeeId))
                .Message("Select the type of leave you want to encash")
                .Field(nameof(leaveTypes))
             
                                           .Build();


        }


        [Serializable]

        public enum LeaveTypes
        {
            sl = 1,
            pl = 2,
            cl = 3

        }

        //    [Serializable]
        //    public enum IsApply
        //    {
        //        Yes = 1,
        //        No = 2
        //    }
        //}

    }
}
