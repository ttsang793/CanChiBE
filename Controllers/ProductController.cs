using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController(ILogger<ProductController> logger, CanChiDbContext dbContext) : ControllerBase
{
    private readonly ILogger<ProductController> _logger = logger;

    private readonly CanChiDbContext _dbContext = dbContext;

    [HttpGet]
    public List<Product> GetProducts()
    {
        return _dbContext.Products.ToList();
    }

    [HttpGet("{id}")]
    public Product? GetProductById(uint id)
    {
        return _dbContext.Products.FirstOrDefault(p => p.Id == id);
    }

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        try
        {
            _dbContext.Add(product);
            return _dbContext.SaveChanges() > 0 ? Ok(new { message = "Success!" }) : BadRequest(new { message = "Fail!" });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e });
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(Product product, uint id)
    {
        try
        {
            _dbContext.Update(product);
            return _dbContext.SaveChanges() > 0 ? Ok(new { message = "Success!" }) : BadRequest(new { message = "Fail!" });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(uint id)
    {
        try
        {
            Product? product = GetProductById(id) ?? throw new Exception();
            _dbContext.Remove(product);
            return _dbContext.SaveChanges() > 0 ? Ok(new { message = "Success!" }) : BadRequest(new { message = "Fail!" });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e });
        }
    }
}
