using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PhoneStatus.helpers
{
    public static class APIHelper
    {
        public static async Task<T> Get<T>(string Url)
        {
           T item = default(T);
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(Url);
                response.EnsureSuccessStatusCode();
                item = await response.Content.ReadAsAsync<T>();
            }
            return item;
        }

        //POST
        public static async Task<T> CreateAsync<T>(string Url, T item)
        {

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(Url, item);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<T>();
            }
        }

        public static async Task<T> CreateAsync<T>(string Url, params object[] myparams)
        {

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(Url, myparams);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<T>();
            }
        }
        ////DELETE
        //static async Task<HttpStatusCode> DeleteProductAsync(string id)
        //{
        //    HttpResponseMessage response = await client.DeleteAsync($"api/products/{id}");
        //    return response.StatusCode;
        //}
        ////PUT
        //static async Task<Product> UpdateProductAsync(Product product)
        //{
        //    HttpResponseMessage response = await client.PutAsJsonAsync($"api/products/{product.Id}", product);
        //    response.EnsureSuccessStatusCode();

        //    // Deserialize the updated product from the response body.
        //    product = await response.Content.ReadAsAsync<Product>();
        //    return product;
        //}
    }
}