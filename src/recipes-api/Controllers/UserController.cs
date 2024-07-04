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
[Route("user")]
public class UserController : ControllerBase
{
    public readonly IUserService _service;

    public UserController(IUserService service)
    {
        this._service = service;
    }

    // GET /user/:email
    [HttpGet("{email}", Name = "GetUser")]
    public IActionResult Get(string email)
    {
        var response = _service.GetUser(email);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    // POST /user
    [HttpPost]
    public IActionResult Create([FromBody] User user)
    {
        _service.AddUser(user);

        return CreatedAtAction("Get", new { email = user.Email }, user);
    }

    // PUT /user
    [HttpPut("{email}")]
    public IActionResult Update(string email, [FromBody] User user)
    {
        bool exists = _service.UserExists(email);

        if (!exists)
        {
            return NotFound();
        }

        if (email.ToLower() != user.Email.ToLower())
        {
            return BadRequest();
        }

        _service.UpdateUser(user);
        return Ok(user);
    }

    // 9 - Sua aplicação deve ter o endpoint DEL /user
    [HttpDelete("{email}")]
    public IActionResult Delete(string email)
    {
        throw new NotImplementedException();
    }
}