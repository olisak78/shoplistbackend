using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopListBackend.Data;

namespace ShopListBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ShopListDbContext _context;

    public CategoriesController(ShopListDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<string>>> GetCategories()
    {
        var categories = await _context.Categories
            .Select(c => c.Name)
            .ToListAsync();
        return Ok(categories);
    }
}