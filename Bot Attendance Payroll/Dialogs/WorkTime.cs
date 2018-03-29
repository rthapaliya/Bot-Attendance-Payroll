using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services.Description;

namespace Bot_Attendance_Payroll.Dialogs
{
    [Serializable]
    public class WorkTime : IDialog<object>
    {

        public async Task StartAsync(IDialogContext context)
        {
            var formFLow = FormDialog.FromForm(WorkTimeFormFlow.WorkTimeForm, FormOptions.PromptInStart);
            context.Call(formFLow, WorkTimeFormLoaded);


        }
        
        public async Task WorkTimeFormLoaded(IDialogContext context, IAwaitable<object> result)
        {

            var msg = await result as Activity;
           await context.PostAsync("Please Type your selection");
            context.Wait(TypeSelection);

           
        }

        private async Task TypeSelection(IDialogContext context, IAwaitable<object> result)
        {
            var msg = await result as Activity;
            if (msg.Text.Equals("Gross Hrs", StringComparison.InvariantCultureIgnoreCase))
            {
                context.Wait(GrossTimeMethod);
            }

            else if(msg.Text.Equals("Net Hrs",StringComparison.InvariantCultureIgnoreCase))
            {
                context.Wait(NetHrsMethod);
            }
            else if(msg.Text.Equals("RequiredNetHrs",StringComparison.InvariantCultureIgnoreCase))
            {
                context.Wait(RequiredNetHrs);
            }
            else if(msg.Text.Equals(" HalfdayMinNetHrs",StringComparison.InvariantCultureIgnoreCase))
            {
                context.Wait(HalfDay);
            }
            else if(msg.Text.Equals("GraceTime",StringComparison.InvariantCultureIgnoreCase))
            {
                context.Wait(GraceTime);
            }
            else if(msg.Text.Equals("BreakTime",StringComparison.InvariantCultureIgnoreCase))
            {
                context.Wait(BreakTime);
            }
          

        }

        private async Task BreakTime(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("You can get 20 min breaks");
        }

        private async Task GraceTime(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("You can get 30 min grace time");
        }

        private async Task HalfDay(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("You need to work 4 hrs 30 min on half day");
        }

        private async Task RequiredNetHrs(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("You need to work 4 hrs more to complete net hrs");
        }

        private async Task NetHrsMethod(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync(" Your Net hrsare 8 hrs");
        }


        private async Task GrossTimeMethod(IDialogContext context, IAwaitable<object> result)
        {
            var msg = await result as Activity;
            await context.PostAsync("Which GrossTime Detail you want?");
            await context.PostAsync("1.daily<br>" + "2.monthly<br>" + "3.Quatrly<br>" + "4.yearly<br>");
            await context.PostAsync("PLease Type your selection");
            context.Wait(TimeSelection);
        }
        

        private async Task TimeSelection(IDialogContext context, IAwaitable<object> result)
        {
        var msg = await result as Activity;

            if (msg.Text.Equals("daily", StringComparison.InvariantCultureIgnoreCase))
            {
                await context.PostAsync("Your daily gross time is 8:30 hrs");
            }

            else if (msg.Text.Equals("monthly", StringComparison.InvariantCultureIgnoreCase))
            {

                await context.PostAsync("Download your montly gross tome report");
                var message = context.MakeMessage();
                var selectedCard = await result;

                var attachment = GetAttachment(selectedCard);
                message.Attachments.Add(attachment);

                await context.PostAsync(message);

                context.Wait(this.TimeSelection);

            }
            context.Done<object>(result);


        }

        private static Attachment GetAttachment(object selectedCard)
        {
            
            return new Attachment
            {
                  
            ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                ContentUrl = "C:/Users/Vrushali/source/repos/Bot Attendance Payroll/Bot Attendance Payroll/File/Holiday.docx",
                Name = "monthly repot",
            };
           
        }


}
    }
