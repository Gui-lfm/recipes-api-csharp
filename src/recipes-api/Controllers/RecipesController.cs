using Microsoft.AspNetCore.Mvc;
using recipes_api.Services;
using recipes_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace recipes_api.Controllers;

[ApiController]
[Route("recipe")]
public class RecipesController : ControllerBase
{
    public readonly IRecipeService _service;

    public RecipesController(IRecipeService service)
    {
        this._service = service;
    }

    //Read
    [HttpGet]
    public IActionResult Get()
    {
        var response = _service.GetRecipes();

        return Ok(response);
    }

    //Read
    [HttpGet("{name}", Name = "GetRecipe")]
    public IActionResult Get(string name)
    {
        var response = _service.GetRecipe(name);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    // POST /recipe
    [HttpPost]
    public IActionResult Create([FromBody] Recipe recipe)
    {
        _service.AddRecipe(recipe);

        return CreatedAtAction("Get", new { name = recipe.Name }, recipe);
    }

    // PUT /recipe/{name}
    [HttpPut("{name}")]
    public IActionResult Update(string name, [FromBody] Recipe recipe)
    {
        bool exists = _service.RecipeExists(name);
        if (!exists)
        {
            return BadRequest();
        }

        if (recipe.Name.ToLower() != name.ToLower())
        {
            return BadRequest();
        }

        _service.UpdateRecipe(recipe);

        return NoContent();
    }

    // 5 - Sua aplicação deve ter o endpoint DEL /recipe
    [HttpDelete("{name}")]
    public IActionResult Delete(string name)
    {
        throw new NotImplementedException();
    }
}
