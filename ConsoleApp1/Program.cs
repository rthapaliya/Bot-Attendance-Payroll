using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Formatting;

namespace ConsoleApp1
{
  public  class Program
    {
        static void Main(string[] args)
        {
            HttpClient cons = new HttpClient();
            cons.BaseAddress = new Uri("http://localhost:57144/");
            cons.DefaultRequestHeaders.Accept.Clear();
            cons.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            MyAPIPost(cons).Wait();

        }
        static async Task MyAPIPost(HttpClient cons)
        {
            using (cons)
            {
                var tag = new AuthenticationRequest { UserName = "test", Password = "test", AuthenticationType = "form" };

                string req = JsonConvert.SerializeObject(tag);
                HttpContent content = new StringContent(tag.ToString(), Encoding.UTF8, "application/json");
                HttpResponseMessage res = cons.PostAsync("api/Authentication/UserLogin", new StringContent(@"{""RequestJSON"":" + req + "}", Encoding.Default, "application/json")).Result;

                var data = await res.Content.ReadAsAsync<ServiceResponse>();
                Console.WriteLine(data.ResponseJSON.AuthorizationToken);


                if (res.IsSuccessStatusCode)
                {
                    if (res.StatusCode == HttpStatusCode.OK)
                    {
                        var test = res.Content.ReadAsAsync<AuthenticationResponse>(new[] { new JsonMediaTypeFormatter() });

                    }

                    Console.WriteLine("\n");
                    Console.WriteLine("\n");

                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine("------------------Calling Post Operation--------------------");
                    Console.WriteLine("------------------Created Successfully--------------------");
                    Console.ReadLine();
                }

            }
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
}

