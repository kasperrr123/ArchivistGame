﻿using System;
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
        private readonly WebClient Client;


        public List<Emne> Topics { get; set; }

        public List<Question> Questions { get; set; }

        private string json;

        public string IP { get; set; } = "100.72.24.83";
        public int PORT { get; set; } = 3000;
        public ServerConnection()
        {
            Client = new WebClient();

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


        public List<Emne> GetTopics()
        {

            try
            {
                Stream stream = Client.OpenRead("http://" + IP + ":" + PORT + "/emner");
                Client.Proxy = null;
                StreamReader reader = new StreamReader(stream);
                json = reader.ReadToEnd();
                stream.Close();

            }
            catch (Exception)
            {
                return null;
            }

            List<Emne> listOfEmner = new List<Emne>();
            dynamic emner = JsonConvert.DeserializeObject<dynamic>(json);
            foreach (var item in emner)
            {
                listOfEmner.Add(new Emne
                {
                    Emne_Navn = item.emne,
                    Emne_Beskrivelse = item.beskrivelse,
                    Antal_Brugt = item.antalBrugt,
                    Image_path = item.billede
                });
            }
            return listOfEmner;
        }

        public List<Question> GetQuestions(string Emne_navn)
        {

            try
            {
                Stream stream = Client.OpenRead("http://" + IP + ":" + PORT + "/question");
                StreamReader reader = new StreamReader(stream);
                json = reader.ReadToEnd();
                stream.Close();

            }
            catch (Exception x )
            {
                Console.WriteLine(x.Message);
            }

            List<Question> ListOfQuestions = new List<Question>();

            dynamic questions = JsonConvert.DeserializeObject<dynamic>(json);
            foreach (var question in questions)
            {
                if (question.emne == Emne_navn)
                {
                    ListOfQuestions.Add(new Question
                    {
                        Question_navn = question.question,
                        Emne = question.emne,
                        Image_path = question.billede,
                        Fact = question.fakta,
                    });
                }

            }
            return ListOfQuestions;



        }

        public List<Svar> GetAnswers(string spørgsmål)
        {


            try
            {
                Stream stream = Client.OpenRead("http://" + IP + ":" + PORT + "/svar");
                StreamReader reader = new StreamReader(stream);
                json = reader.ReadToEnd();
                stream.Close();
                
            }
            catch (Exception)
            {
                return null;
            }

            List<Svar> svarMuligheder = new List<Svar>();

            dynamic svar = JsonConvert.DeserializeObject<dynamic>(json);
            foreach (var svar_mulighed in svar)
            {
                if (svar_mulighed.question == spørgsmål)
                {
                    svarMuligheder.Add(new Svar
                    {
                        Rigtig = svar_mulighed.rigtig,
                        Svar_navn = svar_mulighed.svar,
                        Spørgsmål_navn = svar_mulighed.question,
                    });
                }

            }
            return svarMuligheder;



        }

        public string PostToScoreboard (string json)
        {
            Client.Headers[HttpRequestHeader.ContentType] = "application/json";
            return Client.UploadString("http://" + IP + ":" +  PORT + "/scoreboard", json);
        }


    }
}
