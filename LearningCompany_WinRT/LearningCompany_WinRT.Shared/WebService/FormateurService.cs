using LearningCompany_WinRT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Web.Http;
using System.IO;
using Windows.Storage.Streams;

namespace LearningCompany_WinRT.WebService
{
    public interface IFormateurService
    {
        Task<IEnumerable<Formateur>> GetAll();
        //Task GetById(int id);
        //Task Add(Formateur formateur);
        //Task Delete(int id);
        //Task Update(Formateur formateur);
    }

    public class FormateurService : IFormateurService
    {
        public readonly string _serviceUrl = "http://localhost:24609/api/Formateurs";
        private readonly HttpClient _client = new HttpClient();

        public FormateurService(string apiurl = null)
        {
            if (!String.IsNullOrEmpty(apiurl))
                _serviceUrl = apiurl + "/Formateurs";

            var headers = _client.DefaultRequestHeaders;
            headers.Accept.ParseAdd("application/xml");
        }

        public string GetBaseUrl()
        {
            var split = _serviceUrl.Split('/');
            return split[0] + "//" + split[2] + "/";
        }

        public async Task<IEnumerable<Formateur>> GetAll()
        {
            HttpResponseMessage response = await _client.GetAsync(new Uri(_serviceUrl));
            IInputStream _stream = await response.Content.ReadAsInputStreamAsync();
            XmlSerializer serializer = new XmlSerializer(typeof(Formateur[]));
            return serializer.Deserialize(_stream.AsStreamForRead()) as Formateur[];
        }
    }
}
