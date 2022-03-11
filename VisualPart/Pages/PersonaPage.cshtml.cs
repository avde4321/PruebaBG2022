using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using VisualPart.Model;

namespace VisualPart.Pages
{
    public class PersonaPageModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public PersonaPageModel(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public void OnGet()
        {
            Get_per_list();
        }

        public async Task<List<PersonaModel>> Get_per_list()
        {
            List<PersonaModel> listper = new();
            try
            {
                //HttpClient client = new HttpClient();
                //var urlApi = _configuration.GetSection("Urls").GetSection("Url_Get_per_list").Value;
                //listper = client.GetStringAsync(urlApi).GetAwaiter().GetResult();

                return listper;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
