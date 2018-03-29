using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Attendance_Payroll.Dialogs
{
    [Serializable]
    public class AllowancesFormFlow
    {
        public AllowancesType allowancesType;

        public static IForm<AllowancesFormFlow> AllowancesForm()
        {
            return new FormBuilder<AllowancesFormFlow>()
                 .Field(nameof(allowancesType))



                     .OnCompletion(async (context, profileForm) =>
                     {
                         // Tell the user that the form is complete  
                         // await context.PostAsync("Thanks.");
                     })
                    .Build();
        }
        [Serializable]
        public enum AllowancesType
        {
            Medical_allowances = 1,
            Houserent_allowances = 2,
            Lta_allowances=3,
            Dearness_allowances=4,
            All = 5

        }
    }
}