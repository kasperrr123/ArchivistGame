using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ArchivistGame.models;
using Newtonsoft.Json;

namespace ArchivistGame
{

    class ServerConnection
    {
        public List<Bike> Bikes { get; set; }

        public ServerConnection()
        {
            Bikes = new List<Bike>();
            GetRequestBike();
        }
       
        public async Task GetRequestBike()
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
                    listofBikes.Add(new Bike
                    {
                        id = item.id,
                        type = item.type,
                        model = item.model,
                        price = item.price,
                        stelid = item.stelid,
                        gender = item.gender,
                        available = item.available
                    });
                }

                ForwardList(listofBikes);

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


        private void ForwardList(List<Bike> listofBikes)
        {
            Bikes = listofBikes;
        }
    }
}
