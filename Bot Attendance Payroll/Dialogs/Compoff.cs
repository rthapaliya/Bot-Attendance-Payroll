using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Threading.Tasks;

namespace Bot_Attendance_Payroll.Dialogs
{

    [Serializable]
    public class Compoff : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            var Type = FormDialog.FromForm(CompOffFormFlow.CompoffForm, FormOptions.PromptInStart);
            context.Call(Type, ResumeAfterCompOffFormFlow);
        }

        private async Task ResumeAfterCompOffFormFlow(IDialogContext context, IAwaitable<CompOffFormFlow> result)
        {
            var token = await result;
            if (token.compoffreq.ToString().Equals("Apply_CompOff"))
            {
                await context.PostAsync("You must have worked on holiday or week of to apply <br>" + "Your request is forwarded");
                context.Done(true);
            }
           if (token.compoffreq.ToString().Equals("Compoff_Redeem"))
            {
                await context.PostAsync("You can redeem on any day you want<br>" + "Please specify your Date:?<br> ");
                context.Done(true);
            }
          
        }
        }

        }