using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;

namespace Bot_Attendance_Payroll.Dialogs
{
    [Serializable]
    public class No_of_LeaveEncashed : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
         //   await context.PostAsync("enter anything");
            context.Wait(LeaveNumber);
        }

        private async Task LeaveNumber(IDialogContext context, IAwaitable<object> result)
        {
           // var message = await result;
            await context.PostAsync("Your 12 leaves will get encash");
            context.Done(true);
        }
    }

}