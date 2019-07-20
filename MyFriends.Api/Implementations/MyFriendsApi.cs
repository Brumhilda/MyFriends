using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using MyFriends.Api.DTOs;
using Newtonsoft.Json;

namespace MyFriends.Api.Implementations
{
    public class MyFriendsApi : IMyFriendsApi
    {
        public async Task<List<UserDTO>> GetUsers()
        {
            var handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            var client = new HttpClient(handler);
            try
            {
                var response = await client.GetAsync("https://dl.dropboxusercontent.com/s/s8g63b149tnbg8x/users.json?dl=0");
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var settings = new JsonSerializerSettings();
                settings.DateFormatString = "HH':'mm' 'dd'.'MM'.'yy";
                var data = await Task.Run(() => JsonConvert.DeserializeObject<List<UserDTO>>(responseBody, settings));
                return data;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            handler.Dispose();
            client.Dispose();
            return new List<UserDTO>();
        }

        public async Task<UserDTO> GetUserById(string id)
        {
            var users = Task.Run(() => GetUsers()).Result;
            foreach (var user in users)
                if (user.Id == id)
                    return user;
            return null;
        }
    }
}
