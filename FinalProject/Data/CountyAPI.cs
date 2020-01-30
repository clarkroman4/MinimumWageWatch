using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using FinalProject.Models;

namespace FinalProject.Data
{
    /// <summary>
    /// Client for making calls into YAddress Web API.
    /// </summary>
    public class CountyAPI : IDisposable
    {
        /// <summary>
        /// Stores a processed address, parsed into fields.
        /// </summary>
        

        /// Private variables
        HttpClient _http = null;

        /// Constructor
        public CountyAPI()
        {
        }

        /// Implementation if IDisposable
        public void Dispose()
        {
            _http?.Dispose();
        }

        /// <summary>
        /// Calls YAddress Web API to process a postal address.
        /// </summary>
        /// <param name="AddressLine1">First line of the address, i.e., street address.</param>
        /// <param name="AddressLine2">Second line of the address, i.e., city, state, zip.</param>
        /// <param name="UserKey">Your YAddress Web API user key. Use null if you do not have a YAddress account.</param>
        public async Task<CountyLookup> ProcessAddressAsync(string AddressLine1, string AddressLine2, string UserKey = null)
        {
            // Instantiate Http client if not yet
            if (_http == null)
            {
                _http = new HttpClient();
                _http.BaseAddress = new Uri("https://www.yaddress.net/api/");
                _http.DefaultRequestHeaders.Clear();
                _http.DefaultRequestHeaders.Add("Accept", "application/json");
            }

            // Call Web API
            HttpResponseMessage res = await _http.GetAsync(
                $"Address?AddressLine1={AddressLine1}&AddressLine2={AddressLine2}&UserKey={UserKey}");
            Stream st = await res.Content.ReadAsStreamAsync();

            // Deserialize JSON
            var serializer = new DataContractJsonSerializer(typeof(CountyLookup));
            CountyLookup adr;
            try
            {
                adr = (CountyLookup)serializer.ReadObject(st);
            }
            catch (Exception ex)
            {
                throw new Exception("Error parsing response from server", ex);
            }
            st.Close();

            return adr;
        }

        /// <summary>
        /// Calls YAddress Web API to process a postal address.
        /// </summary>
        /// <param name="AddressLine1">First line of the address, i.e., street address.</param>
        /// <param name="AddressLine2">Second line of the address, i.e., city, state, zip.</param>
        /// <param name="UserKey">Your YAddress Web API user key. Use null if you do not have a YAddress account.</param>
        public string GetCounty(string AddressLine1, string AddressLine2, string UserKey = null)
        {
            Task<CountyLookup> tsk = ProcessAddressAsync(AddressLine1, AddressLine2, UserKey);
            tsk.Wait();
            return tsk.Result.County;
        }




    }
}
