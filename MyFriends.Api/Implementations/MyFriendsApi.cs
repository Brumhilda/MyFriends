using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MyFriends.Api.Implementations
{
    public class MyFriendsApi : IMyFriendsApi
    {
        public async Task<string> GetUsers(CancellationToken token)
        {
            var handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            var client = new HttpClient(handler);
            try
            {
                var response = await client.GetAsync("https://www.dropbox.com/s/s8g63b149tnbg8x/users.json?dl=0");
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            // Need to call dispose on the HttpClient and HttpClientHandler objects 
            // when done using them, so the app doesn't leak resources
            handler.Dispose();
            client.Dispose();
            return "";
        }
    }
}
