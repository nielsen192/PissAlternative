using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiConsoleClient;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Connection apiConnection = new Connection();
            apiConnection.ApiAction();


        }
    }
}