using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace Bot_Attendance_Payroll.Dialogs
{
    [Serializable]
    public class Tour:IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            var tourform = FormDialog.FromForm(FormFlowTour.TourForm, FormOptions.PromptInStart);
            context.Call(tourform,MessageReceivedAsync);
          

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            var selectedCard = await result;

            var message = context.MakeMessage();

            var attachment = GetSelectedCard(selectedCard);
            message.Attachments.Add(attachment);

            await context.PostAsync(message);

            context.Wait(this.MessageReceivedAsync);
            context.Done<object>(null);
        }
   

        private Attachment GetSelectedCard(object selectedCard)
        {
            var heroCard = new HeroCard
            {
                Title = "I Can Help you to book a Ticket",
                Subtitle = "Lets book ticket for you",
                Text = "You can check flight and train booking from here only ....!!",
                Images = new List<CardImage>
                {
                    new CardImage("C:/Users/Vrushali/source/repos/Bot Attendance Payroll/Bot Attendance Payroll/Images/ticket.jpg")
                },
                Buttons = new List<CardAction> {
                    new CardAction(ActionTypes.OpenUrl, "Book a Flight", value: "https://www.google.co.in/flights/#search"),
                    new CardAction(ActionTypes.OpenUrl, "Book a Train", value: "https://www.irctc.co.in/eticketing/loginHome.jsf"),
                    
                }
            };

            return heroCard.ToAttachment();


        }
        

    }
    
}