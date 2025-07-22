using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopListBackend.Data;

namespace ShopListBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ShopListDbContext _context;

    public ProductsController(ShopListDbContext context)
    {
        _context = context;
    }

    [HttpGet("{categoryId}")]
    public async Task<ActionResult<IEnumerable<string>>> GetProductsByCategory(int categoryId)
    {
        var products = await _context.Products
            .Where(p => p.CategoryId == categoryId)
            .Select(p => p.Name)
            .ToListAsync();
        return Ok(products);
    }
}