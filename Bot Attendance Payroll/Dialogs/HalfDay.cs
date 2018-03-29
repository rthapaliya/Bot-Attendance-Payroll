using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Threading.Tasks;

namespace Bot_Attendance_Payroll.Dialogs
{
    [Serializable]
    public class HalfDay : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Your halfday for last month");
            var halfdayd = FormDialog.FromForm(HalfDayFormFlow.HalfdayForm, FormOptions.PromptInStart);
            context.Call(halfdayd, DisplayDetails);


        }


        private async Task DisplayDetails(IDialogContext context, IAwaitable<HalfDayFormFlow> result)
        {
            var token = await result;
            if (token.detailsTypes.ToString().Equals("weekly"))
            {
                await context.PostAsync("weekly report generated");
                context.Done(true);
            }
            if (token.detailsTypes.ToString().Equals("monthly"))
            {
                await context.PostAsync("monthly report generated");
                context.Done(true);
            }
            if (token.detailsTypes.ToString().Equals("yearly"))
            {
                await context.PostAsync("yearly report generated");
                context.Done(true);
            }

        }
    }
}