using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyLoginWhitJWT.Helpers
{
    public static class HttpRequestsDirect
    {
        public async static Task<List<T>> GetAll<T>(string url, string Token) where T : class, new()
        {
            HttpClient client = new();
            try
            {

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                Console.WriteLine(responseBody);
                return JsonConvert.DeserializeObject<List<T>>(responseBody);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\n HTTP  Exception Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
            finally
            {
                client.Dispose();

            }

        }
       
        public async static Task<T> GetById<T>(int id, string url, string Token) where T : class, new()
        {
            HttpClient client = new();
            try
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

                url = (url + "/" + id.ToString()).Trim();
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                Console.WriteLine(responseBody);
                return JsonConvert.DeserializeObject<T>(responseBody);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\n HTTP  Exception Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
            finally
            {
                client.Dispose();

            }

        }
        
        public async static Task<T> GetusuarioByEmail<T>(string Email, string url, string Token) where T : class, new()
        {

            HttpClient client = new();
            try
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

                //url = (url + "/" + id.ToString()).Trim();
                HttpResponseMessage response = await client.PostAsJsonAsync(url, Email);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                Console.WriteLine(responseBody);
                return JsonConvert.DeserializeObject<T>(responseBody);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\n HTTP  Exception Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
            finally
            {
                client.Dispose();

            }

        }

        public async static Task<bool> Delete(int id, string url, string Token)
        {
            HttpClient client = new();
            try
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

                url = url + "/" + id;
                HttpResponseMessage response = await client.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
                return JsonConvert.DeserializeObject<bool>(responseBody);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\n HTTP  Exception Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return false;
            }
            finally
            {
                client.Dispose();

            }

        }

        public async static Task<T> Post<T>(T elemento, string URL, string Token) where T : class, new()
        {
            HttpClient client = new();
            try
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

                HttpResponseMessage response = await client.PostAsJsonAsync(URL, elemento);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                Console.WriteLine(responseBody);
                return JsonConvert.DeserializeObject<T>(responseBody);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\n HTTP  Exception Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
            finally
            {
                client.Dispose();

            }
        }

        public async static Task<T> Put<T>(T elemento, int id, string URL, string Token) where T : class, new()
        {
            HttpClient client = new();
            try
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

                URL = (URL + "/" + id).Trim();
                HttpResponseMessage response = await client.PutAsJsonAsync(URL, elemento);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                Console.WriteLine(responseBody);
                return JsonConvert.DeserializeObject<T>(responseBody);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\n HTTP  Exception Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
            finally
            {
                client.Dispose();

            }
        }

    }
}
