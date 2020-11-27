using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kirigiri
{
    class Sauce
    {
        public static Sauce FromJson(string sauceJson){
            return JsonSerializer.Deserialize<Sauce>(sauceJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        [JsonPropertyName("header")]
        public SauceHeader Information { get; set; }
        public Result[] Results { get; set; }
    }

    class SauceHeader
    {
        [JsonPropertyName("short_remaining")]
        public int ShortRemaining { get; set; }
        [JsonPropertyName("long_remaining")]
        public int LongRemaining { get; set; }
    }   

    class Result
    {
        [JsonPropertyName("header")]
        public ResultHeader Information { get; set; }
        [JsonPropertyName("data")]
        public ResultData Contents { get; set; }
        
        public string Similarity { get {
            return this.Information.Similarity;
        }}

        public string Title { get {
            return this.Contents.Title;
        }}

        public string[] URLs { get {
            return this.Contents.URLs;
        }}
    }

    public class ResultHeader
    {
        public string Similarity { get; set; }
    }

    public class ResultData 
    {
        public string Title { get; set; }
        [JsonPropertyName("ext_urls")]
        public string[] URLs { get; set; } 
    }
}