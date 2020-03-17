using RRMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RRMDesktopUI.Library.Api
{
    public class ProductEndpoint : IProductEndpoint
    {
        private IAPIHelper _apiHelper;

        public ProductEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<ProductModel>> GetAll()
        {
            using (HttpResponseMessage httpResponse = await _apiHelper.ApiClient.GetAsync("api/Product"))
            {
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = await httpResponse.Content.ReadAsAsync<List<ProductModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(httpResponse.ReasonPhrase);
                }
            }
        }
    }
}
