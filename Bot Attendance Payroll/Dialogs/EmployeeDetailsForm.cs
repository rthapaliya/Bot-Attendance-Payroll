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
    public class EmployeeDetailsForm
    {
      
            
            public RequestTypes requestTypes;
            //public LeaveTypes leaveTypes;
            //public IsApply isApply;
            //public DateTime? DateOfLeave;
        //[Numeric(1, 5)]// will take numeric value between 1-5
        //public int? NumberOfLeaves;

        [Prompt("What's your full name?")]
        public string Name { get; set; }

        [Prompt("What is your employee id")]
        public String EmployeeId { get; set; }


        [Prompt("Can you share your mail id")]
        [Pattern(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]// email vaildation
        public string Email { get; set; }

        
       



        public static IForm<EmployeeDetailsForm> BuildForm()
            {

            return new FormBuilder<EmployeeDetailsForm>()
                .Message("Welcome to Attendance BOT.")//printing msg to bot
                .Message("can I have your details please.......")
                .Field(nameof(Name))//calling fileds with priority
                .Message("hello , {Name}")
                .Field(nameof(EmployeeId))
                .Field(nameof(Email))
                .Message("how can I help you, {Name}????")
                .AddRemainingFields()
                    // .OnCompletion(async (context, profileForm) =>
                    // {
                    //     // Tell the user that the form is complete  
                    //     await context.PostAsync("Thanks.");
                    // })
                    .Build();
        }

        
        [Serializable]
           public enum RequestTypes
        {
            LeaveEncashment=1,
            Tour=2,
            OutdoorDuty=3,
            WorkFromHome=4,
            Compoff=5,
            Mispunch=6,
            ApplyForLeave=7,
            Working_Hrs=8,
            Holidays=9,
            Payroll=10,
            Profile=11

        }
        
    }

   
    
}