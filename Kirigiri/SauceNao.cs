using System.Net.Http;
using System.IO;
using System;

namespace Kirigiri
{
    class SauceNao
    {
        private const string SAUCENAO_URL = "https://saucenao.com/search.php";

        private HttpClient Client { get; set; } = new HttpClient();

        public Sauce Search(string filename){
            using(var stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read)){
                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(stream), "file", "file");
                content.Add(new StringContent("2"), "output_type");
                var res = Client.PostAsync(SAUCENAO_URL, content);
                if(res.Result.IsSuccessStatusCode)
                {
                    return Sauce.FromJson(res.Result.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    Console.WriteLine("Encountered an error with the request");
                    Console.WriteLine(res.Result.Content.ReadAsStringAsync().Result);
                    return null;
                }
            }
        }
    }
}