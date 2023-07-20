using FleetDeadlines.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Protocol;
using RestSharp;
using System.Net;
using System.Security.Policy;
using System.Text;

namespace FleetDeadlines.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LocalDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<LocalDbContext>>()))
            {
                context.Database.EnsureCreated();

                if (context == null || context.Vehicles == null)
                {
                    throw new ArgumentNullException("Null LocalDbContext");
                }

                if (context.Vehicles.Any())
                {
                    return;   // DB has been seeded
                }

                List<string> testVRNs = new List<string>
                    { "AA19AAA", "AA19EEE", "AA19PPP", "L2WPS", "AA19SRN", "AA19DSL", "AA19MOT", "AA19AMP"};

                DotNetEnv.Env.TraversePath().Load();

                string api = DotNetEnv.Env.GetString("TEST_API");
                string key = DotNetEnv.Env.GetString("TEST_KEY");

                context.Vehicles.Add(new Vehicle { RegistrationNumber = api });
                context.Vehicles.Add(new Vehicle { RegistrationNumber = key });

                //HttpClient webClient = new HttpClient();
                //webClient.DefaultRequestHeaders.Add("x-api-key", key);
                //webClient.DefaultRequestHeaders.Add("ContentType", "application/json");
                //webClient.DefaultRequestHeaders.Add("Accept", "application/json");

                //var client = new RestClient(api);
                //var request = new RestRequest(Method.Post.ToString());

                //request.AddHeader("x-api-key", key);
                //request.AddHeader("Content-Type", "application/json");


////////////////// WORKING ////////////////////
                //var httpRequest = (HttpWebRequest)WebRequest.Create(api);
                //httpRequest.Method = "POST";

                //httpRequest.Headers["x-api-key"] = key;
                //httpRequest.ContentType = "application/json";

                //var data = "{\"registrationNumber\": \"AA19AAA\"}";

                //using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                //{
                //    streamWriter.Write(data);
                //}

                //var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                //{
                //    var result = streamReader.ReadToEnd();
                //    Console.WriteLine(result);
                //}
///////////////////

                foreach (var item in testVRNs)
                {
                    //request.AddParameter("application/json", "{\n\t\"registrationNumber\":\"AA19AAA\"\n}", ParameterType.RequestBody);

                    //RestResponse response = client.Execute(request);
                    //Console.WriteLine(response.Content);

                    //var jsonPayload = $"{{\"registrationNumber\":\"{key}\"}}";
                    //var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                    //var response = webClient.PostAsync(api, content).Result;

                    // Parse the response into Vehicle
                    //var responseString = response.Content.ReadAsStringAsync().Result;
                    //var newVehicle = JsonConvert.DeserializeObject<Vehicle>(responseString);

                    //Console.WriteLine(webClient.DefaultRequestHeaders);
                    //Console.WriteLine(responseString);

                    //if (responseString != null)
                    //{
                    //    context.Vehicles.Add(new Vehicle{ RegistrationNumber = responseString });
                    //}
                }

                context.SaveChanges();
            }
        }
    }
}
