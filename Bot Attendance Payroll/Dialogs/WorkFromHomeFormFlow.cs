using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Attendance_Payroll.Dialogs
{

    [Serializable]
    public class WorkFromHomeFormFlow
    {

        public IsApply isApply;


        
        public DateTime? WorkFromHomeDate;


        [Prompt("Do you want to apply for work from home??")]
        public String EmployeeId { get; set; }


        public static IForm<WorkFromHomeFormFlow> WorkFromHomeForm()
        {
            return new FormBuilder<WorkFromHomeFormFlow>()
                .Message(" Do You want to apply for Work From Home? .")//printing msg to bot
                .Field(nameof(isApply))
                .Message("On which Date do you want to apply for work from home?")
                .Field(nameof(WorkFromHomeDate))
                .Build();


        }


       
        [Serializable]
        public enum IsApply
        {
            Yes = 1,
            No = 2
        }
    }

}




