using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Zest_Client;

namespace Bot_Attendance_Payroll.Dialogs
{
    [Serializable]
    public class Holidays : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            var Type = FormDialog.FromForm(HolidayFormFlow.HolidayForm, FormOptions.PromptInStart);
            context.Call(Type, DisplayHoliday);
        }

        private async Task DisplayHoliday(IDialogContext context, IAwaitable<object> result)
        {
            Class1 c = new Class1();
            string s = c.Getdata().Result;
            await context.PostAsync(s);

            context.Done<object>(null);

        }
    }
}