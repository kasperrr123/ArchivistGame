using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestConnectionToNodeJs
{
    class Program
    {
        static void Main(string[] args)
        {
            GetRequest();


        }

        async static void GetRequest()
        {
            // Create a New HttpClient object.
            HttpClient client = new HttpClient();

            // Call asynchronous network methods in a try/catch block to handle exceptions
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://www.google.dk/");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            // Need to call dispose on the HttpClient object
            // when done using it, so the app doesn't leak resources
            client.Dispose();


            //using (HttpClient client = new HttpClient())
            //{
            //    var json = await client.GetStringAsync("http://google.dk");
            //    Console.WriteLine(json.ToString());
            //}
        }

     

    }
}
