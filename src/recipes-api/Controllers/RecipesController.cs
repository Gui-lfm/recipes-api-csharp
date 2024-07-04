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

    // 3 - Sua aplicação deve ter o endpoint POST /recipe
    [HttpPost]
    public IActionResult Create([FromBody] Recipe recipe)
    {
        throw new NotImplementedException();
    }

    // 4 - Sua aplicação deve ter o endpoint PUT /recipe
    [HttpPut("{name}")]
    public IActionResult Update(string name, [FromBody] Recipe recipe)
    {
        throw new NotImplementedException();
    }

    // 5 - Sua aplicação deve ter o endpoint DEL /recipe
    [HttpDelete("{name}")]
    public IActionResult Delete(string name)
    {
        throw new NotImplementedException();
    }
}
