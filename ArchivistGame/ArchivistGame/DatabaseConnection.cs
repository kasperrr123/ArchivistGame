using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TestConnectionToNodeJs.models;

using System.Net;

using System.Net.Http.Headers;


namespace TestConnectionToNodeJs
{
    class DatabaseConnection
    {

        static readonly Uri uri = new Uri("http://100.72.15.51:3000/bikes/6");


        public async Task Getbike()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(uri);
            HttpContent content = response.Content;
            var json = await content.ReadAsStringAsync();

        }

    }
}
