using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Attendance_Payroll.Dialogs
{
    [Serializable]
    public class OutdoorDutyFormFlow
    {
        public Outdoordutytypes outdoorTypes;
        public IsApply isApply;




        [Prompt("ok, so you will be working from which city ?")]
        public String City { get; set; }

        
        [Prompt("Till when you haveout door duty")]
        public DateTime? outdoorend { get; set; }
        public static IForm<OutdoorDutyFormFlow> OutdoorDutyForm()
        {
            return new FormBuilder<OutdoorDutyFormFlow>()
                .Message("Can I have your outdoor duty details")//printing msg to bot
               
                .Field(nameof(City))//calling fileds with priority              
                .Message("Shall I proceed?, to apply")
                .Field(nameof(isApply))
                


                     .OnCompletion(async (context, profileForm) =>
                     {
                         // Tell the user that the form is complete  
                         await context.PostAsync("Thanks.");

                     })
                    .Build();


        }

        
        [Serializable]
        public enum Outdoordutytypes
        {
            OnShore = 1,
            OffShore = 2

        }

        [Serializable]
        public enum IsApply
        {
            Yes = 1,
            No = 2

        }


    }
}