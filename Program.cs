// Add necessary using statements
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

class Program
{
    static async Task Main(string[] args)
    {
        string subscriptionKey = "800157e6cf96432a8958603d45173bed";
        string endpoint = "https://new333.cognitiveservices.azure.com/";

        var client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(subscriptionKey))
        {
            Endpoint = endpoint
        };

        string localImagePath = @"C:\Users\samde\Downloads\20240327_170557.jpg";

        using (var imageStream = File.OpenRead(localImagePath))
        {
            var result = await client.RecognizePrintedTextInStreamAsync(true, imageStream);

            foreach (var region in result.Regions)
            {
                foreach (var line in region.Lines)
                {
                    foreach (var word in line.Words)
                    {
                        Console.Write(word.Text + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}

