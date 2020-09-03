using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MauroTemplate.MauroAPI
{
    class clsMauroConnection
    {
        private static readonly HttpClient client = new HttpClient();

        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string Endpoint { get; set; } = "https://modelcatalogue.cs.ox.ac.uk/nhsd";
        public static bool LoginStatus { get; set; } = false;

        // Set up basic strings for the API
        private const string LoginAPI = "/api/authentication/login";
        private const string LogoutAPI = "/api/authentication/logout";
        private const string ModelAPI = "/api/dataModels";
        private const string JSONMime = "application/json";

        public static LoginResponse LoginDetails { get; set; } = null;
        public static Models MauroModels { get; set; }

        public static async Task<LoginResponse> Login()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JSONMime));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Mauro Template Serialiser");
            var MauroLogin = new LoginRequest() { username = Username, password = Password };
            string strBody = JsonSerializer.Serialize(MauroLogin);
            var Body = new StringContent(strBody, Encoding.UTF8, "application/json");
            var PostResult = await client.PostAsync(Endpoint + LoginAPI, Body);
            var JSONResult = await PostResult.Content.ReadAsStreamAsync();
            LoginDetails = await JsonSerializer.DeserializeAsync<LoginResponse>(JSONResult);
            LoginStatus = true;
            return LoginDetails;
        }

        public static async Task<Models> GetModels()
        {
            string JSONString = await GetMauroJSON(ModelAPI);
            MauroModels = JsonSerializer.Deserialize<Models>(JSONString);
            return MauroModels;
        }

        public static async Task<Model> GetModel(Guid ID)
        {
            string JSONString = await GetMauroJSON(ModelAPI + "/" + ID.ToString());
            var MauroModel = JsonSerializer.Deserialize<Model>(JSONString);
            return MauroModel;
        }

        private static async Task<string> GetMauroJSON(string API)
        {
            if (LoginStatus == false)
            {
                await Login();
            }
            // Async retrieval of Mauro API JSON
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JSONMime));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Mauro Template Serialiser");

            // Retrieve the JSON from the Mauro endpoint
            var GetResult = await client.GetAsync(Endpoint + API);
            var JSONResult = await GetResult.Content.ReadAsStreamAsync();
            var reader = new StreamReader(JSONResult);
            string JSONstring = reader.ReadToEnd();
            return JSONstring;
        }

        public static async Task Logout()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JSONMime));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Mauro Template Serialiser");
            var PostResult = await client.GetAsync(Endpoint + LogoutAPI);
            string ResultContent = await PostResult.Content.ReadAsStringAsync();
            Console.WriteLine(ResultContent);
        }
    }

    public class LoginResponse
    {
        [JsonPropertyName("id")]
        public Guid id { get; set; }
        [JsonPropertyName("emailAddress")]
        public string emailAddress { get; set; }
        [JsonPropertyName("firstName")]
        public string firstName { get; set; }
        [JsonPropertyName("lastName")]
        public string lastName { get; set; }
        [JsonPropertyName("userRole")]
        public string userRole { get; set; }
        [JsonPropertyName("disabled")]
        public bool disabled { get; set; }
    }
    /// <summary>
    /// Mauro dataModels data structure
    /// count of models as integer
    /// list of Mauro model data structures
    /// </summary>
    public class Models
    {
        [JsonPropertyName("count")]
        public int count { get; set; }
        [JsonPropertyName("items")]
        public List<Model> items { get; set; }
    }
    /// <summary>
    /// Mauro dataModel datastructure
    /// </summary>
    public class Model
    {
        [JsonPropertyName("id")]
        public Guid id { get; set; }
        [JsonPropertyName("domainType")]
        public string domainType { get; set; }
        [JsonPropertyName("label")]
        public string label { get; set; }
        [JsonPropertyName("aliases")]
        public object aliases { get; set; } // List(Of String)
        [JsonPropertyName("description")]
        public string description { get; set; }
        [JsonPropertyName("author")]
        public string author { get; set; }
        [JsonPropertyName("organisation")]
        public string organisation { get; set; }
        [JsonPropertyName("editable")]
        public bool editable { get; set; }
        [JsonPropertyName("documentationVersion")]
        public string documentationVersion { get; set; }
        [JsonPropertyName("lastUpdated")]
        public DateTime lastUpdated { get; set; }
        [JsonPropertyName("classifiers")]
        public List<Classifier> classifiers { get; set; }
        [JsonPropertyName("type")]
        public string type { get; set; }
        [JsonPropertyName("finalised")]
        public bool finalised { get; set; }
        public List<Metadata> metadata { get; set; }
    }

    public class Classifier
    {
        [JsonPropertyName("id")]
        public Guid id { get; set; }
        [JsonPropertyName("label")]
        public string label { get; set; }
        [JsonPropertyName("lastUpdated")]
        public DateTime lastUpdated { get; set; }
    }

    public class Metadata
    {
        // {
        // "id": "c9a36d30-2c6a-4dd0-a792-a337a2eca9c8",
        // "namespace": "ox.softeng.metadatacatalogue.dataloaders.hdf",
        // "key": "Volumes",
        // "value": "Varies annually: in 2013/14, 18.2m finished consultant episodes (FCEs) and 15.5m Finished Admission Episodes (FAEs)",
        // "lastUpdated": "2019-10-03T09:15:12.082Z"
        // }

        [JsonPropertyName("id")]
        public Guid id { get; set; }
        [JsonPropertyName("namespace")]
        public string mauroNamespace { get; set; }
        [JsonPropertyName("key")]
        public string key { get; set; }
        [JsonPropertyName("value")]
        public string value { get; set; }
        [JsonPropertyName("lastUpdated")]
        public DateTime lastUpdated { get; set; }
    }

    public class LoginRequest
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}