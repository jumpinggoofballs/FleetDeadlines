using FleetDeadlines.Models;
using Newtonsoft.Json;
using System.Net;

namespace FleetDeadlines.Utils
{
    public class DvlaGet
    {
        public static Vehicle withReg(string vrn, string apiTarget = "REAL")
        {
            DotNetEnv.Env.TraversePath().Load();

            string api = DotNetEnv.Env.GetString(apiTarget + "_API");
            string key = DotNetEnv.Env.GetString(apiTarget + "_KEY");

            ///////////////////
            ///
            /// For whatever reason neither HttpClient nor RestSharp manage to successfully pass the x-api-key header to the server, so had to use HttpWebRequest
            /// TODO?: This may need to be revisited in the future
            /// 
            ///////////////////

            var httpRequest = (HttpWebRequest)WebRequest.Create(api);
            httpRequest.Method = "POST";

            httpRequest.Headers["x-api-key"] = key;
            httpRequest.ContentType = "application/json";

            var data = $"{{\"registrationNumber\": \"{vrn}\"}}";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            var result = "";
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            var newVehicle = JsonConvert.DeserializeObject<Vehicle>(result);

            return newVehicle;
        }
    }
}
