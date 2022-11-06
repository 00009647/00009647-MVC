using _9647_seminar4_to_my_laptop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace _9647_seminar4_to_my_laptop.Controllers
{
    public class ProductController : Controller
    {
        // async Because we are connecting to API
        // Task<ActionsResults>
        // GET: Product
        public async Task<ActionResult> Index()
        {
            //Hosted web API REST Service base url
            string Baseurl = "https://localhost:44379";
            List<Product> ProdInfo = new List<Product>();
            //we are using http package
            using (var client = new HttpClient())
            {
                //Passing service base url
                string apiUrl = Baseurl + "/api/Product";
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();

                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource using HttpClient
                HttpResponseMessage Res = await client.GetAsync(apiUrl);

                //Checking the response is successful or not which is sent HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var PrResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing the Product list
                    ProdInfo = JsonConvert.DeserializeObject<List<Product>>(PrResponse);
                }
                //returning the Product list to view
                return View(ProdInfo);
            }
        }

        // GET: Product/5
        public async Task<ActionResult> Details(int id)
        {
            //Hosted web API REST Service base url
            string Baseurl = "https://localhost:44379";
            Product ProdInfo = new Product();
            using (var client = new HttpClient())
            {
                //Passing service base url
                string apiUrl = Baseurl + "/api/Product/" + id;
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();

                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource using HttpClient
                HttpResponseMessage Res = await client.GetAsync(apiUrl);

                //Checking the response is successful or not which is sent HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var PrResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing the Product list
                    ProdInfo = JsonConvert.DeserializeObject<Product>(PrResponse);
                }
                //returning the Product list to view
                return View(ProdInfo);
            }
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            //using try and catch
            try
            {
                using (var client = new HttpClient())
                {
                    string Baseurl = "https://localhost:44379/api/Product";

                    // passing service base url
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();

                    // define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // sending a request
                    var productJson = JsonConvert.SerializeObject(product);
                    var productRequest = new StringContent(productJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(Baseurl, productRequest);
                }

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }


        // Edit: Product/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            //Hosted web API REST Service base url
            string Baseurl = "https://localhost:44379";
            Product ProdInfo = new Product();
            using (var client = new HttpClient())
            {
                //Passing service base url
                string apiUrl = Baseurl + "/api/Product/" + id;
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();

                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource using HttpClient
                HttpResponseMessage Res = await client.GetAsync(apiUrl);

                //Checking the response is successful or not which is sent HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var PrResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing the Product list
                    ProdInfo = JsonConvert.DeserializeObject<Product>(PrResponse);
                }
                //returning the Product list to view
                return View(ProdInfo);
            }
        }

        // PUT: Product/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Product product)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string Baseurl = "https://localhost:44379/api/Product/" + id;

                    // passing service base url
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();

                    // define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // sending a request
                    var productJson = JsonConvert.SerializeObject(product);
                    var productRequest = new StringContent(productJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync(Baseurl, productRequest);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // Delete: Product/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            //Hosted web API REST Service base url
            string Baseurl = "https://localhost:44379";
            Product ProdInfo = new Product();
            using (var client = new HttpClient())
            {
                //Passing service base url
                string apiUrl = Baseurl + "/api/Product/" + id;
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();

                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource using HttpClient
                HttpResponseMessage Res = await client.GetAsync(apiUrl);

                //Checking the response is successful or not which is sent HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var PrResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing the Product list
                    ProdInfo = JsonConvert.DeserializeObject<Product>(PrResponse);
                }
                //returning the Product list to view
                return View(ProdInfo);
            }
        }

        // DELETE: api/Product/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string Baseurl = "https://localhost:44379/";

                    // passing service base url
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();

                    // define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // sending a request
                    HttpResponseMessage response = await client.DeleteAsync("api/Product/" + id);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
