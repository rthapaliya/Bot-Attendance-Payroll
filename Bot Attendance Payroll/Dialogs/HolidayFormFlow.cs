using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Attendance_Payroll.Dialogs
{
    [Serializable]
    public class HolidayFormFlow
    {
        public HolidayType holidayType;

        public static IForm<HolidayFormFlow> HolidayForm()
        {
            return new FormBuilder<HolidayFormFlow>()
                 .Field(nameof(holidayType))



                     .OnCompletion(async (context, profileForm) =>
                     {
                         // Tell the user that the form is complete  
                        // await context.PostAsync("Thanks.");
                     })
                    .Build();
        }
        [Serializable]
        public enum HolidayType
        {
           Optional=1,
            Mandatory=2,
            All=3

        }
    }
}