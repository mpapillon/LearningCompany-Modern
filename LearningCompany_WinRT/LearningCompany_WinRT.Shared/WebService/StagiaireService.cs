using LearningCompany_WinRT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage.Streams;
using Windows.Web.Http;
using System.IO;

namespace LearningCompany_WinRT.WebService
{
    public class StagiaireService
    {
        public readonly string _serviceUrl = "http://localhost:24609/api/Formateurs";
        private readonly HttpClient _client = new HttpClient();

        public StagiaireService(string apiurl = null)
        {
            if (!String.IsNullOrEmpty(apiurl))
                _serviceUrl = apiurl + "/Stagiaires";

            var headers = _client.DefaultRequestHeaders;
            headers.Accept.ParseAdd("application/xml");
        }

        public async Task<IEnumerable<Stagiaire>> GetAll()
        {
            HttpResponseMessage response = await _client.GetAsync(new Uri(_serviceUrl));
            IInputStream _stream = await response.Content.ReadAsInputStreamAsync();
            XmlSerializer serializer = new XmlSerializer(typeof(Stagiaire[]));
            return serializer.Deserialize(_stream.AsStreamForRead()) as Stagiaire[];
        }
    }
}
