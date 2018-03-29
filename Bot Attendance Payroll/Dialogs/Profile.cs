using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bot_Attendance_Payroll.Dialogs
{
    [Serializable]
    public class Profile : IDialog
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("What is your Profile Details<br> join date, exp , pf number");
         
        }

    }
}