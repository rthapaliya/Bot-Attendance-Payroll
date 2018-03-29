using Chronic;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services.Description;

namespace Bot_Attendance_Payroll.Dialogs
{
    [Serializable]
    public class Esi_tax : IDialog<object>
    {
        protected string UserName { get; set; }
        protected string Password { get; set; }
        protected string AuthenticationType { get; set; }

        public async Task StartAsync(IDialogContext context)
        {

            context.PostAsync("enter user name" );
            context.Wait(abc);

            // return Task.CompletedTask;
        }

        private async Task abc(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            
            // User message
            string userMessage = activity.Text;
            
            try
            {

                using (HttpClient client = new HttpClient())
                {

                    HttpClient cons = new HttpClient();
                    cons.BaseAddress = new Uri("http://localhost:57144/");
                    cons.DefaultRequestHeaders.Accept.Clear();
                    cons.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    //    await context.PostAsync("please enter your username");
                    //  var activity = await result as Activity;



                    var tag = new AuthenticationRequest { UserName = userMessage, Password = userMessage , AuthenticationType = "form" };

                    string req = JsonConvert.SerializeObject(tag);
                    HttpContent content = new StringContent(tag.ToString(), Encoding.UTF8, "application/json");
                    HttpResponseMessage res = cons.PostAsync("http://localhost:57144/api/Authentication/UserLogin", new StringContent(@"{""RequestJSON"":" + req + "}", Encoding.Default, "application/json")).Result;


                    var data = await res.Content.ReadAsAsync<ServiceResponse>();
                    var token = data.ResponseJSON.AuthorizationToken;

                    //StateClient stateClient = activity.GetStateClient();
                    //BotData userData = await stateClient.BotState.GetUserDataAsync(activity.ChannelId, activity.From.Id);
                    //await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);
                    context.UserData.SetValue("ses",token);
                    await context.PostAsync(data.ToString());
                    await context.PostAsync(token);



                    // await context.PostAsync($"Response is {token}");
                    if (res.IsSuccessStatusCode)
                    {
                        cons.DefaultRequestHeaders.Add("Authorization", token);
                        var id = new TestRequest { id = 2 };
                        string proreq = JsonConvert.SerializeObject(id);
                        HttpContent procontent = new StringContent(id.ToString(), Encoding.UTF8, "application/json");
                        HttpResponseMessage prores = cons.PostAsync("http://localhost:57144/api/Products/GetProduct", new StringContent(@"{""RequestJSON"":" + proreq + "}", Encoding.Default, "application/json")).Result;

                        var prodata = await prores.Content.ReadAsAsync<Product>();
                        var d = prodata.ResponseJSON.Name;
                        await context.PostAsync(d);





                        if (res.StatusCode == HttpStatusCode.OK)
                        {
                            var test = res.Content.ReadAsAsync<AuthenticationResponse>(new[] { new JsonMediaTypeFormatter() });
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            context.Done(true);
        }
    }
    public class AuthenticationResponse
    {
        public int EmpID { get; set; }
        public string AuthorizationToken { get; set; }
    }
    public class ServiceResponse
    {
        public string Status { get; set; }
        public string ServerDateTime { get; set; }
        public string ErrorList { get; set; }
        public AuthenticationResponse ResponseJSON { get; set; }
    }
    public class AuthenticationRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AuthenticationType { get; set; }
    }
    public class TestRequest
    {
        public int id { get; set; }
    }

    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public Product ResponseJSON { get; set; }
    }
}
