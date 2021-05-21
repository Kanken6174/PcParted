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

                HttpResponseMessage response = await Client.GetAsync(uri);
                
                Stream responseBody = await response.Content.ReadAsStreamAsync();
                return responseBody;

        }
    }
}