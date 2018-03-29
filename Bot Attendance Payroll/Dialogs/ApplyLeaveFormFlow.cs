using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;

namespace Bot_Attendance_Payroll.Dialogs
{
    [Serializable]
    public class ApplyLeaveFormFlow
    {

        public LeaveTypes leaveTypes;

            
       
            public static IForm<ApplyLeaveFormFlow> ApplyLeaveForm()
            {
                return new FormBuilder<ApplyLeaveFormFlow>()
                    .Message("Please select your leave category from here..")
                    .Field(nameof(leaveTypes))
                    .Build();


            }


        


        [Serializable]

        public enum LeaveTypes
        {
           Apply_for_Sick_Leave_sl = 1,
           Apply_for_Paid_Leave_pl = 2,   
           Apply_for_Vacation_Days_VD= 3,
           Apply_for_Maternity_Leave_MTL=4,
           Apply_for_Paternity_Leave_PTL=5,
           Apply_for_Study_Leave_STL=6

            }
        

    }
}