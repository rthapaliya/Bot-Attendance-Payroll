using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bot_Attendance_Payroll.Dialogs
{
    [Serializable]
    public class FormFlowTour
    {

        public TypeOfTour tourTypes;


        public IsApply isApply;
        

        

        [Prompt("Which city are you planning for tour")]
        public String City { get; set; }

        [Prompt("On Which date are you planning to go?")]
        public DateTime?tourstart{ get; set; }

        [Prompt("Till which date on tour?")]
        public DateTime? tourend { get; set; }
        public static IForm<FormFlowTour> TourForm()
        {
            return new FormBuilder<FormFlowTour>()
                .Message("Can I have your tour details")//printing msg to bot
                .Field(nameof(tourTypes))
                .Field(nameof(City))//calling fileds with priority              
                .Field(nameof(tourstart))
                .Field(nameof(tourend))
                .Message("Do you want to apply for accomadation on tour?")
                .Field(nameof(isApply))
                .Message("Shall I proceed with your selection")
                .Field(nameof(isApply))
                


                     .OnCompletion(async (context, profileForm) =>
                     {
                         // Tell the user that the form is complete  
                         await context.PostAsync("Thanks.");
                         
                     })
                    .Build();


        }

        public static async Task ResumeAfterCallingTour(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("Request forwared");
        }

        [Serializable]
        public enum IsApply
        {
            Yes = 1,
            No = 2
        }

        [Serializable]

        public enum TypeOfTour
        {
            OnShore = 1,
            OffShore = 2
        }
    }
}