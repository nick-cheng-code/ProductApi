using Microsoft.AspNetCore.Mvc;
using ProductCore.SaveData;
using ProductCore.GetData;
using Store.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("product")]
public class ProductController : ControllerBase
{
    private readonly IProductRetriever _retriever;
    private readonly IProductCreator _creator;

    public ProductController(IProductRetriever productRetriever, IProductCreator productCreator)
    {
        _retriever = productRetriever;
        _creator = productCreator;
    }

    /// <summary>
    /// Endpoints for getting product by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{id:int}")]
    public async virtual Task<IActionResult> Get(int id)
    {
        try
        {
            if (id <= 0) return BadRequest($"Invalid id");
            var model = await _retriever.Get(id);
            if (model == null) return BadRequest();
            return Ok(model);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Endpoints for getting product by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("name/{name}")]
    public async virtual Task<IActionResult> Get(string name)
    {
        try
        {
            if (string.IsNullOrEmpty(name)) return BadRequest($"Invalid product name");
            var model = await _retriever.GetByName(name);
            if (model == null) return BadRequest();
            return Ok(model);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Endpoint for getting all products
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("all")]
    public async virtual Task<IActionResult> GetAll()
    {
        try
        {
            var model = await _retriever.GetAll();
            if (model == null) return BadRequest();
            return Ok(model);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Endpoint for creating new product
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("")]
    public async virtual Task<IActionResult> Add([FromBody] Product product)
    {
        try
        {
            if (string.IsNullOrEmpty(product.Name)) return BadRequest($"Invalid product name");
            var id = await _creator.Add(product.Name, product.Description, product.Price);
            if (id == 0) return BadRequest();

            var model= await _retriever.Get(id);
            return Ok(model);

        }
        catch (Exception)
        {

            return BadRequest();
        }
    }
}
