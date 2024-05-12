using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private static readonly string key = "e1b2222b203f4e819dee150311a7f1e6"; // Use your actual subscription key
    private static readonly string endpoint = "https://api.cognitive.microsofttranslator.com";
    private static readonly string location = "germanywestcentral"; // Your resource location/region

    static async Task Main(string[] args)
    {
        // Translating to English
        string route = "/translate?api-version=3.0&to=en";
        // Text you want to translate
        string textToTranslate = "Geh ganz in der Musik auf, im Augenblick\r\nDu hast die Kontrolle und lässt sie besser nie mehr los\r\nDu hast nur einen Versuch, verpasS nicht deine Chance, es allen zu\r\nzeigen\r\nSo eine Gelegenheit kommt nur einmal im Leben\r\nSeine Seele entflieht durch das klaffende Loch\r\nDie Welt wartet nur darauf, dass ich sie mir nehme\r\nMacht mich zum König, während wir uns auf eine neue Weltordnung\r\nzubewegen\r\nEin gewöhnliches Leben ist langweilig, aber das Leben eines Superstars\r\nimmer einen Augenblick davon entfernt, wieder vorüber zu sein 2\r\nAlles wird nur schwerer, wird nur heißer\r\nEr zeigt es all diesen Speichelleckern, die an ihm hängen\r\nHat Auftritte von Küste zu Küste, man nennt ihn den Weltenbummler\r\nAuf einsamen Straßen, und nur Gott weiß\r\nWie er sich von seiner Heimat entfremdet ist, ist kein Vater mehr\r\nKommt nach Hause und erkennt seine Tochter kaum noch\r\nDoch rümpft die Nase nicht zu früh, denn hier kommt die Ernüchterung:\r\nSeine Plattenfuzzis wollen ihn jetzt nicht mehr, er ist nur noch ein\r\nLadenhüter\r\nMittlerweile ist der nächste Tuppes ein Star mit seinem Flow\r\nEr hingegen ist abgestürzt und hat nichts mehr verkauft\r\nSo läuft diese Seifenoper und entwickelt sich weiter\r\nIst vielleicht 'n alter Spruch, aber das Leben geht weiter\r\nDa da dum da dum da da"; // Update with your text
        object[] body = new object[] { new { Text = textToTranslate } };
        var requestBody = JsonConvert.SerializeObject(body);

        using (var client = new HttpClient())
        using (var request = new HttpRequestMessage())
        {
            // Build the request
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(endpoint + route);
            request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            request.Headers.Add("Ocp-Apim-Subscription-Key", key);
            request.Headers.Add("Ocp-Apim-Subscription-Region", location);

            // Send the request and get the response
            HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
            // Read the response as a string
            string result = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Translated Text:");
            Console.WriteLine(result);
        }
    }
}
