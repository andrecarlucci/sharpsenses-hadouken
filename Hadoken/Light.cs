using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hadoken {
    public static class Light {
        private static HttpClient _client = new HttpClient();

        public static async Task Blink() {
            await _client.GetAsync("http://192.168.10.253/cgi-bin/relay.cgi?on");
            Console.WriteLine("On");
            await Task.Delay(3000);
            await _client.GetAsync("http://192.168.10.253/cgi-bin/relay.cgi?off");
            Console.WriteLine("Off");
        }
    }
}