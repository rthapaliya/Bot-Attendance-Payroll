using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bot_Attendance_Payroll.Dialogs
{
    [Serializable]
    public class House_rent_allowance : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("enter anything");
            context.Wait(this.abc);
        }

        private async Task abc(IDialogContext context, IAwaitable<object> result)
        {
            var message = await result;
            await context.PostAsync("House_rent_allowance ");
            context.Done(message);
        }
    }
}