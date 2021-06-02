using RepositoryLayer.Interface;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RepositoryLayer.Class
{
    /// <summary>
    /// Class HttpClientRepository
    /// </summary>
    public class HttpClientRepository: IHttpClientRepository
    {      
        /// <summary>
        /// Constructor of HttpClientRepository
        /// </summary>
        public HttpClientRepository()
        {
        }

        /// <summary>
        /// Get Async
        /// </summary>
        /// <param name="apiRelativePath">Relative path of the API</param>
        /// <returns>HttpResponseMessage object</returns>
        public async Task<HttpResponseMessage> GetAsync(string baseAddress, string apiRelativePath)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                return await httpClient.GetAsync(new Uri($"{baseAddress}{apiRelativePath}", UriKind.Absolute));
            }
        }
    }
}
