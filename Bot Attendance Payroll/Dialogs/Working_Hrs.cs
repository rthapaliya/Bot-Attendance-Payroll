using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Threading.Tasks;

namespace Bot_Attendance_Payroll.Dialogs
{

    [Serializable]
    public class Working_Hrs : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            var worktime = FormDialog.FromForm(WorkTimeFormFlow.WorkTimeForm, FormOptions.PromptInStart);
            context.Call(worktime, WorkTimeSelection);
        }

        private async Task WorkTimeSelection(IDialogContext context, IAwaitable<WorkTimeFormFlow> result)
        {
            var token = await result;
            if (token.worktimeTypes.ToString().Equals("GrossHrs"))
            {
                await context.PostAsync("Report: <br>"+"**GrossHrs:** must be 8hrs 30 min");
                context.Done(true);
            }
            if (token.worktimeTypes.ToString().Equals("NetHrs"))
            {
                await context.PostAsync("**NetHrs:** must be 8hrs");
                context.Done(true);
            }

            if (token.worktimeTypes.ToString().Equals("AvgHrs"))
            {
                await context.PostAsync("**AvgHrs:** must be 6hrs");
                context.Done(true);
            }

        }


    }
}