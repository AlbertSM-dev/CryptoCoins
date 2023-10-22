using DataCollector.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataCollector.Collector
{
    public class Collector
    {
        public Collector() {
            List<Coin> Items = new List<Coin>();
        }

        public static async Task<Coin> GetCoinsAsync()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("https://api.coincap.io/v2/assets");

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    Coins obj = (Coins)JsonConvert.DeserializeObject<Coins>(data);
                }
                return null;
            }
            //if (response.IsSuccessStatusCode)
            //{
            //    IEnumerable<Coin> categories = await response.Content.ReadAsAsync<IEnumerable<Coin>>();
            //    var ItemData = new Items
            //    (
            //    // Use this category list to initialize your Items
            //    );
            //    items.Add(ItemData);
            //}
        }
    }
}
