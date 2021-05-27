using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;

namespace logicPC.Downloaders
{
    public static class PictureDownloader
    {
        static readonly HttpClient Client= new HttpClient();

        public static async Task<Stream> GetPicture(Uri uri)
        {
            try
            {
                HttpResponseMessage response = await Client.GetAsync(uri);

                Stream responseBody = new MemoryStream();
                responseBody.Position = 0;
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