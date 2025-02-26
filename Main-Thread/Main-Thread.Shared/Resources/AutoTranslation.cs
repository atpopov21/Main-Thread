using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Main_Thread.Shared.Resources
{
    public class AutoTranslation
    {
        private const string baseUrl = "http://api.mymemory.translated.net";
        private HttpClient client;

        public AutoTranslation()
        {
            client = new HttpClient();
        }

        public async Task<string> TranslateAsync(string text, string sourceLang, string targetLang)
        {
            string url = $"{baseUrl}/get?q={Uri.EscapeDataString(text)}&langpair={sourceLang}|{targetLang}";

            HttpResponseMessage respone = await client.GetAsync(url);
            respone.EnsureSuccessStatusCode();

            string responseJson = await respone.Content.ReadAsStringAsync();
            var translatedResult = JsonConvert.DeserializeObject<TranslationResponse>(responseJson);

            if (translatedResult.ResponseStatus == 200)
            {
                return translatedResult.TranslatedText;
            }

            return string.Empty;
        }

        public class TranslationResponse()
        {
            [JsonProperty("responseStatus")]
            public int ResponseStatus { get; set; }

            [JsonProperty("responseData")]
            public TranslationData ResponseData { get; set; }

            public string TranslatedText => ResponseData?.TranslatedText;
        }

        public class TranslationData()
        {
            [JsonProperty("translatedText")]
            public string TranslatedText { get; set; }
        }
    }
}
