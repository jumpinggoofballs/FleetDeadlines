using FleetDeadlines.Models;
using Newtonsoft.Json;
using System.Net;

namespace FleetDeadlines.Utils
{
    public class DvlaGet
    {
        // TODO: This would ideally be async, and with either HttpClient or RestSharp 
        public static Vehicle withReg(string vrn, string api, string key)
        {
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
