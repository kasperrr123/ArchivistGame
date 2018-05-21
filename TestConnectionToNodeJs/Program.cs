using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestConnectionToNodeJs.models;

namespace TestConnectionToNodeJs
{
    class Program
    {

        Bike bike;
        static void Main(string[] args)
        {
            GetRequest().Wait();


        }

        async static Task GetRequest()
        {
            // Create a New HttpClient object.
            HttpClient client = new HttpClient();

            // Call asynchronous network methods in a try/catch block to handle exceptions
            try
            {
                List<Bike> listofBikes = new List<Bike>();
                HttpResponseMessage response = await client.GetAsync("http://100.72.15.51:3000/bikes");
                response.EnsureSuccessStatusCode();
                string json_result = await response.Content.ReadAsStringAsync();
                dynamic bikes = JsonConvert.DeserializeObject<dynamic>(json_result);
                foreach (var item in bikes)
                {
                    Console.WriteLine(item);
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            // Need to call dispose on the HttpClient object
            // when done using it, so the app doesn't leak resources
            client.Dispose();


        }

     

    }
}
