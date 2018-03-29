using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Attendance_Payroll.Dialogs
{
    [Serializable]
    public class HalfDayFormFlow
    {
        public DetailsTypes detailsTypes;

        public static IForm<HalfDayFormFlow> HalfdayForm()
        {
            return new FormBuilder<HalfDayFormFlow>()
                 .Field(nameof(detailsTypes))



                     .OnCompletion(async (context, profileForm) =>
                     {
                         // Tell the user that the form is complete  
                         // await context.PostAsync("Thanks.");
                     })
                    .Build();
        }
        [Serializable]
        public enum DetailsTypes
        {
            weekly = 1,
            monthly = 2,
            yearly = 3,

        }

    }
}