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
    public class OutdoorDuty : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            var outdoor = FormDialog.FromForm(OutdoorDutyFormFlow.OutdoorDutyForm, FormOptions.PromptInStart);
            context.Call(outdoor, OutdoorDutyApproval);
           
        }

        private async Task OutdoorDutyApproval(IDialogContext context, IAwaitable<OutdoorDutyFormFlow> result)
        {
            await context.PostAsync("Your request is sent for approval");
            context.Done<object>(null);
        }

        
    }
}