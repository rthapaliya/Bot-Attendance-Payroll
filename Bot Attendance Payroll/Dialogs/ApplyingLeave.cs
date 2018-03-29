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
    public class ApplyingLeave : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            var Type = FormDialog.FromForm(ApplyLeaveFormFlow.ApplyLeaveForm, FormOptions.PromptInStart);
            context.Call(Type, LeaveSelection);
            
        }

        private async Task LeaveSelection(IDialogContext context, IAwaitable<ApplyLeaveFormFlow> result)
        {
            var token = await result;
            if (token.leaveTypes.ToString().Equals("Apply_for_Sick_Leave_sl"))
            {
                await context.PostAsync("You have applied a sick leave");
                context.Done(true);
            }
            else if (token.leaveTypes.ToString().Equals("Apply_for_Paid_Leave_pl"))
            {
                await context.PostAsync("You have applied a pl");
                context.Done(true);
            }
            else if (token.leaveTypes.ToString().Equals("Apply_for_Vacation_Days_VD"))
            {
                await context.PostAsync("You have applied a vacation leave");
                context.Done(true);
            }
            else if (token.leaveTypes.ToString().Equals("Apply_for_Maternity_Leave_MTL"))
            {
                await context.PostAsync("You have applied maternity leave");
                context.Done(true);
            }
            else if (token.leaveTypes.ToString().Equals("Apply_for_Paternity_Leave_PTL"))
            {
                await context.PostAsync("You have applied Paternity leave");
                context.Done(true);
            }
            else if (token.leaveTypes.ToString().Equals("Apply_for_Study_Leave_STL"))
            {
                await context.PostAsync("You have applied Study Leave");
                context.Done(true);
            }
         
        }
    }

        
    
}