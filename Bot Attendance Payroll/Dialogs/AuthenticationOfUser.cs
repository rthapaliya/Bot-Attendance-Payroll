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
    public class AuthenticationOfUser:IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            var selectedCard = await result;

            var message = context.MakeMessage();

            var attachment = GetSelectedCard(selectedCard);
            message.Attachments.Add(attachment);

            await context.PostAsync(message);
            

            context.Wait(this.MessageReceivedAsync);
        }

        public Attachment GetSelectedCard(object selectedCard)
        {


            var signinCard = new SigninCard()
            {
                Text = "Authorization Needed",

                Buttons = new List<CardAction>
                {
                    new CardAction()
                    {
                        Value="https://login.microsoftonline.com/",
                        Type="signin",
                        Title="Microsoft OAuth",
                        Image="file:///C:/Users/Vrushali/Downloads/if_72-windows8_104431.svg"

                    },
                    new CardAction()
                    {
                        Value="https://accounts.google.com/signin",
                        Type="signin",
                        Title="Google",
                        Image="http://images.dailytech.com/nimage/G_is_For_Google_New_Logo_Thumb.png"

                    }
                }
            };
            return signinCard.ToAttachment();

        }
    }
}