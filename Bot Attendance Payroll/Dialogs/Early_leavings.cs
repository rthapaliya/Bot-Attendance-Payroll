using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;

namespace Bot_Attendance_Payroll.Dialogs
{
    [Serializable]
    public class Early_leavings : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {

            await context.PostAsync("Early_leavings report");
            context.Done(true);
        }

    }
}