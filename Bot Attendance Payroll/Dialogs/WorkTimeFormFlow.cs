using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Attendance_Payroll.Dialogs
{
    [Serializable]
    public class WorkTimeFormFlow
    {


        public WorkTimeTypes worktimeTypes;
        
        
        
        public static IForm<WorkTimeFormFlow> WorkTimeForm()
        {

            return new FormBuilder<WorkTimeFormFlow>()
                .Message("Want to check your working hrs????")
                .AddRemainingFields()
                    // .OnCompletion(async (context, profileForm) =>
                    // {
                    //     // Tell the user that the form is complete  
                    //     await context.PostAsync("Thanks.");
                    // })
                    .Build();
        }


        [Serializable]
        public enum WorkTimeTypes
        {
            GrossHrs =1,
            NetHrs =2,
            AvgHrs=3
            
        }

        
    }




}