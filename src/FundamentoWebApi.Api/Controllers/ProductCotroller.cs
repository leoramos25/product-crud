using FundamentoWebApi.Api.Data;
using FundamentoWebApi.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FundamentoWebApi.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly ApiDbContext _context;

    public ProductController(ApiDbContext dbContext)
    {
        _context = dbContext;
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        if (_context.Products == null) return NotFound();

        return await _context.Products.ToListAsync();
    }

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<Product>> GetProduct(Guid id)
    {
        if (_context.Products == null) return NotFound();

        var product = await _context.Products.FindAsync(id);

        if (product == null) return NotFound();

        return product;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        if (_context.Products == null) return Problem("Erro ao criar um produto, contate o suporte!");

        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> UpdateProduct(Guid id, Product product)
    {
        if (id != product.Id) return BadRequest();

        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        _context.Entry(product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        if (_context.Products == null) return NotFound();

        var product = await _context.Products.FindAsync(id);

        if (product == null) return NotFound();

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductExists(Guid id)
    {
        return (_context.Products?.Any(product => product.Id == id)).GetValueOrDefault();
    }
}
