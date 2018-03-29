using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bot_Attendance_Payroll.Dialogs
{
    [Serializable]
    public class Misspunch : IDialog<string>
    {

        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Misspunch Details<br>");

            context.Done(true);

        }
    }
}