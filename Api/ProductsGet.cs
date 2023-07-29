using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Api;

public class ProductsGet
{
    private readonly IProductData productData;

    public ProductsGet(IProductData productData)
    {
        this.productData = productData;
    }

    [Function("ProductsGet")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "products")] HttpRequestData req)
    {
        var products = await productData.GetProducts();
        return new OkObjectResult(products);
    }
}