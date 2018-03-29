using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Bot_Attendance_Payroll.Dialogs
{
    [Serializable]
    public class Pf_number : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
           await context.PostAsync("enter anything");
            context.Wait(this.abc);
        }

        private async Task abc(IDialogContext context, IAwaitable<object> result)
        {
            var message = await result;
            await context.PostAsync("pf123");
            context.Done(message);
        }
    }
}