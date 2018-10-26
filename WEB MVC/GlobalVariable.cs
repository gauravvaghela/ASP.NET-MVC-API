using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WEB_MVC
{
    public static class GlobalVariable
    {
        public static HttpClient WebApi = new HttpClient();

        static GlobalVariable()
        {
            WebApi.BaseAddress = new Uri("http://localhost:51549/Api/");
            WebApi.DefaultRequestHeaders.Clear();
            WebApi.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}