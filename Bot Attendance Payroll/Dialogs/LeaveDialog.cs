using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bot_Attendance_Payroll.Dialogs
{
    [Serializable]
     public class LeaveDialog : IDialog<object>
    {
       protected int bal { get; set; }
        

        public async Task StartAsync(IDialogContext context)
        {

            var leaveform = FormDialog.FromForm(LeaveFormFlow.LeaveEncashmentForm, FormOptions.PromptInStart);
            context.Call(leaveform, FormSelection);

                        
        }
        private async Task FormSelection(IDialogContext context, IAwaitable<LeaveFormFlow> result)
        {
            var token = await result;
            if (token.leaveTypes.ToString().Equals("sl"))
            {
                await context.PostAsync("what is your sl leave balance?");
                context.Wait(CheckBalance);
                
            }
            if (token.leaveTypes.ToString().Equals("cl"))
            {
                await context.PostAsync("Waht is your cl leave balance");
                context.Wait(CheckBalance);
                
            }

            if (token.leaveTypes.ToString().Equals("pl"))
            {
                await context.PostAsync("what is your pl leave balance");
                context.Wait(CheckBalance);
                
            }

        }

            public async Task CheckBalance(IDialogContext context, IAwaitable<object> activity)
        {
            var msg = await activity as Activity;
            var balance = await activity as Activity;
            bal = int.Parse(msg.Text);
            await context.PostAsync("Checking your eligibility");
            if (bal>12)
            {
                await context.PostAsync("Yes, you have enough balance to get leave encashed");
            }

            else
            {
                await context.PostAsync("Sorry you don't have enough balance to get leave encashed");
            }
            context.Done(true);
        }
       
    }
}