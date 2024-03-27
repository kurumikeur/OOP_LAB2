using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1
{
    public class Calls
    {
        static HttpClient client = new HttpClient();
        private Task[] tasks = new Task[3];

        public static async Task Sendrequest(string destination)
        {
            Stopwatch timer = Stopwatch.StartNew();
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, destination);
            using HttpResponseMessage response = await client.SendAsync(request);
            timer.Stop();
            Console.WriteLine(response.StatusCode.ToString());
            Console.WriteLine("Got response in: {0} ms", timer.Elapsed.Milliseconds);
        }

    }
}
