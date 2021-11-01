using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IriaBridge.Domain;
using Newtonsoft.Json;
using WPFLocalization;

namespace IriaBridge.DataAccess
{
    public class Repository<T> where T : Entity
    {
        static HttpClient Client = new HttpClient { BaseAddress = new Uri("https://solutiontriangle.com/ibackend/ajax/") };
        protected virtual String Path { get; }
        protected virtual String Parameters { get {
                //string _language = LocalizationManager.UICulture.ToString();
                //var lang = _language.Split('-')[0];
                //return "?lang=" + lang;
                return "?";
            } }
        

        public ICollection<T> Entities { 
        get {
                var task = Task.Run(async () => await GetRepository());
                var result = task.Result;
                return result;
            }
        }

        protected virtual async Task<ICollection<T>> GetRepository()
        {
            try
            {

                HttpResponseMessage response = await Client.GetAsync(Path + Parameters);
                response.EnsureSuccessStatusCode();
                string responseBody =   await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ICollection<T>>(responseBody);
                return result;
             }
              catch(HttpRequestException e)
              {
                 Console.WriteLine("\nException Caught!");	
                 Console.WriteLine("Message :{0} ",e.Message);
              }
                return null;
        }

        public virtual T UpdateEntity(T entity)
        {
            return entity;
            
        }

    }
}
