using EventsWebApiCore.Models;
using Newtonsoft.Json;

namespace EventsWebApiCore.HelperMethods
{
    public class GetUserListFromApi
    {
        public async Task<UserModel> GetUserListFromApiMethod()
        {
            UserModel userModel = new UserModel();

            string apiUrl = "https://jsonplaceholder.typicode.com/users/1";

            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                // Deserialize the JSON response to UserModel
                userModel = JsonConvert.DeserializeObject<UserModel>(responseData);
            }
            else
            {
                //Return temp data ** Just for testing purpose in case the url is down **

                string json = @"
        {
          ""id"": 1,
          ""name"": ""Leanne Graham"",
          ""username"": ""Bret"",
          ""email"": ""Sincere@april.biz"",
          ""address"": {
            ""street"": ""Kulas Light"",
            ""suite"": ""Apt. 556"",
            ""city"": ""Gwenborough"",
            ""zipcode"": ""92998-3874"",
            ""geo"": {
              ""lat"": ""-37.3159"",
              ""lng"": ""81.1496""
            }
          },
          ""phone"": ""1-770-736-8031 x56442"",
          ""website"": ""hildegard.org"",
          ""company"": {
            ""name"": ""Romaguera-Crona"",
            ""catchPhrase"": ""Multi-layered client-server neural-net"",
            ""bs"": ""harness real-time e-markets""
          }
        }";

                userModel = JsonConvert.DeserializeObject<UserModel>(json); // or JsonSerializer.Deserialize<UserModel>(json);

            }

            return userModel;
        }
    }
}
