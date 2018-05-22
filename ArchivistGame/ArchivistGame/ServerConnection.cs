using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using ArchivistGame.models;
using Newtonsoft.Json;

namespace ArchivistGame
{

   public class ServerConnection
    {
        private static ServerConnection instance;

        public List<Bike> Topics { get; set; }

        public List<Question> Questions { get; set; }

        public string url = "http://100.72.68.190" + ":3000";
        public ServerConnection()
        {
            Topics = GetTopics();

        }

        public static ServerConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServerConnection();
                }
                return instance;
            }
        }


        public List<Bike> GetTopics()
        {
            // Create a New HttpClient object.
            WebClient client = new WebClient();

            Stream stream = client.OpenRead(url + "/bikes");
            StreamReader reader = new StreamReader(stream);

            string json = reader.ReadToEnd();

            // Call asynchronous network methods in a try/catch block to handle exceptions
            try
            {

                List<Bike> listofBikes = new List<Bike>();
                //HttpResponseMessage response = await client.GetAsync("http://100.72.15.51:3000/bikes");
                ////response.EnsureSuccessStatusCode();
                //string json_result = await response.Content.ReadAsStringAsync();
                dynamic bikes = JsonConvert.DeserializeObject<dynamic>(json);
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
                Console.WriteLine(listofBikes);
                stream.Close();
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

        public List<Question> GetQuestions(string Topic_Name)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(url + "/questions");
            StreamReader reader = new StreamReader(stream);
            string json = reader.ReadToEnd();

            List<Question> ListOfQuestions = new List<Question>();

            dynamic questions = JsonConvert.DeserializeObject<dynamic>(json);
            foreach (var item in questions)
            {
                if (item.topic == Topic_Name)
                {
                    ListOfQuestions.Add(new Question
                    {
                        Question_name = item.question,
                        Image_path = item.image_path,
                    });
                }
               
            }
            stream.Close();
            return ListOfQuestions;



        }



    }
}
