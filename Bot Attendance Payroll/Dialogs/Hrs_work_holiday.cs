using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bot_Attendance_Payroll.Dialogs
{
   // [SerialC:\Users\Vrushali\source\repos\Bot Attendance Payroll\Bot Attendance Payroll\Dialogs\Hrs_work_holiday.csizable]
    public class Hrs_work_holiday : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("enter anything");
            context.Wait(this.abc);
        }

        private async Task abc(IDialogContext context, IAwaitable<object> result)
        {
            var message = await result;
            await context.PostAsync("Hrs_work_holidays ");
            context.Done(message);
        }
    }
}