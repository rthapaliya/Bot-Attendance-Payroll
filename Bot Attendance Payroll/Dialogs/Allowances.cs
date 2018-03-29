using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;

namespace Bot_Attendance_Payroll.Dialogs
{
    [Serializable]
    public class Allowances : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            var Type = FormDialog.FromForm(AllowancesFormFlow.AllowancesForm, FormOptions.PromptInStart);
            context.Call(Type, DisplayAllowances);
        }

        private async Task DisplayAllowances(IDialogContext context, IAwaitable<AllowancesFormFlow> result)
        {
            var token = await result;
            if (token.allowancesType.ToString().Equals("Medical_allowances")) 
            {
                await context.PostAsync("Medical called");
                context.Done(true);
            }
            if (token.allowancesType.ToString().Equals("Lta_allowances")) 
            {
                await context.PostAsync("Lta_allowances called");
                context.Done(true);
            }
            if (token.allowancesType.ToString().Equals("Houserent_allowances"))
            {
                await context.PostAsync("Houserent_allowances called");
                context.Done(true);
            }
            if (token.allowancesType.ToString().Equals("Dearness_allowances"))
            {
                await context.PostAsync("Dearness_allowances called");
                context.Done(true);
            }
            if (token.allowancesType.ToString().Equals("All"))
            {
                await context.PostAsync("All called");
                context.Done(true);
            }
            //await context.PostAsync("All Allowances");
            //context.Done<object>(null);


            //context.Wait(MessageReceivedAsync);
        }
    }
}