using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace logicPC.Downloaders
{
    static internal class PictureDownloader
    {
        private static readonly HttpClient Client = new();

        internal static async Task<Stream> GetPicture(Uri uri)
        {
            try
            {
                HttpResponseMessage response = await Client.GetAsync(uri);

                Stream responseBody = new MemoryStream
                {
                    Position = 0
                };
                responseBody = await response.Content.ReadAsStreamAsync();
                return responseBody;
            }
            catch (TaskCanceledException)
            {
                return null;
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }
}