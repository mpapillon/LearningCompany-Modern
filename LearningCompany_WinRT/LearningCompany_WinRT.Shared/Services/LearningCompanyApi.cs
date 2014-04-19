using LearningCompany_WinRT.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage.Streams;
using Windows.Web.Http;

namespace LearningCompany_WinRT.Services
{
    public class LearningCompanyApi
    {
        protected HttpClient _httpclient;
        private IInputStream _stream;

        private string _serviceUrl;
        public string ServiceUrl
        {
            get { return _serviceUrl; }
        }
        

        public LearningCompanyApi()
        {
            Initialize();
            _serviceUrl = "http://localhost:24609/api/";
        }

        public LearningCompanyApi(string adress)
        {
            Initialize();
            _serviceUrl = adress;
        }

        private void Initialize()
        {
            _httpclient = new HttpClient();
            var headers = _httpclient.DefaultRequestHeaders;
            headers.Accept.ParseAdd("application/xml");
        }

        public async Task<List<Formateur>> GetFormateurs()
        {
            //await Task.Delay(7000);
            HttpResponseMessage response = await _httpclient.GetAsync(new Uri(ServiceUrl + "Formateurs"));
            _stream = await response.Content.ReadAsInputStreamAsync();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Formateur>));
            return serializer.Deserialize(_stream.AsStreamForRead()) as List<Formateur>;
        }

        public async Task<Formateur> GetFormateurById(int id)
        {
            var response = await _httpclient.GetAsync(new Uri(ServiceUrl + "Formateurs/" + id));
            _stream = await response.Content.ReadAsInputStreamAsync();
            XmlSerializer serializer = new XmlSerializer(typeof(Formateur));
            return serializer.Deserialize(_stream.AsStreamForRead()) as Formateur;
        }

    }
}
