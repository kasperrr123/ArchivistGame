using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TestConnectionToNodeJs.models;

using System.Net;

using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace TestConnectionToNodeJs
{

    class DatabaseConnection
    {

        public List<Bike> bikes { get; set; }

        public DatabaseConnection()
        {

        }

        async static Task<List<Bike>> GetBikes()
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
                    listofBikes.Add(item);
                }

                return listofBikes;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            // Need to call dispose on the HttpClient object
            // when done using it, so the app doesn't leak resources
            client.Dispose();

            return null;

        }




    }
}
