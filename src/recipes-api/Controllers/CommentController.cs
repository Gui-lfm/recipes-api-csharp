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
[Route("comment")]
public class CommentController : ControllerBase
{
    public readonly ICommentService _service;

    public CommentController(ICommentService service)
    {
        this._service = service;
    }

    // POST /comment
    [HttpPost]
    public IActionResult Create([FromBody] Comment comment)
    {
        _service.AddComment(comment);

        return StatusCode(201, comment);
    }

    // GET /comment/:recipeName
    [HttpGet("{name}", Name = "GetComment")]
    public IActionResult Get(string name)
    {
        var response = _service.GetComments(name);

        return Ok(response);
    }
}