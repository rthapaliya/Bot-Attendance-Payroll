using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Attendance_Payroll.Dialogs
{
    [Serializable]
    public class FormFlowGenralDetails
    {
        public RequestTypes requestTypes;

        public static IForm<FormFlowGenralDetails> BuildForm()
        {
            return new FormBuilder<FormFlowGenralDetails>()
                    .Message("Check for other request")
                    .Field(nameof(requestTypes))
                    .Build();
        }



        [Serializable]
       
        public enum RequestTypes
        {
            LeaveEncashment = 1,
            Tour = 2,
            OutdoorDuty = 3,
            WorkFromHome = 4,
            CompOff = 5,
            Misspunch = 6,
            SandwichLeave = 7,
            WorkTime = 8,
            Holidays = 9,
            Payroll = 10,
            Profile = 11

        }

    }
}