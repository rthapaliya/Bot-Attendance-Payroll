using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;

namespace Bot_Attendance_Payroll.Dialogs
{

    [Serializable]
    public class In_Out_Time : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {

            await context.PostAsync("**In_Time:**:8:30 am<br>" + "**Out_Time:**:7:30 pm<br>" + "monthly report generated");
            context.Done(true);
        }

        //    public async Task In_Out_Details(IDialogContext context, IAwaitable<object> result)
        //    {
        //        var message = await result;
        //        await context.PostAsync("**In_Time:**:8:30 am<br>"+ "**Out_Time:**:7:30 pm<br>"+"monthly report generated");
        //        context.Done(true);
        //    }
        //}




    }
}
