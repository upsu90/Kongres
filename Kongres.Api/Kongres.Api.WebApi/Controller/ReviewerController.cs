﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Threading.Tasks;
using Kongres.Api.Application.Commands.Users.Reviewer;
using Kongres.Api.Domain.DTOs;
using Kongres.Api.Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;

namespace Kongres.Api.WebApi.Controller
{
    public class ReviewerController : ApiControllerBase
    {
        private readonly IMemoryCache _cache;
        public ReviewerController(IMediator mediator, IMemoryCache cache) : base(mediator)
        {
            _cache = cache;
        }

        // api/Reviewer/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] CreateReviewerCommand command)
        {
            await CommandAsync(command);
            return Ok();
        }

        // api/Reviewer/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginReviewerCommand command)
        {
            command.TokenId = Guid.NewGuid();
            try
            {
                await CommandAsync(command);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

            var token = _cache.GetJwt(command.TokenId);
            return Ok(token);
        }

        // api/Reviewer/MyReviews
        [Authorize]
        [HttpGet("MyReviews")]
        public async Task<IActionResult> GetListOfWorks([FromQuery] GetListOfWorksCommand command)
        {
            command.ReviewerId = HttpContext.User.Identity.Name;
            IEnumerable<ScientificWorkWithStatusDto> scientificWorks;
            try
            {
                scientificWorks = await CommandAsync(command);
            }
            catch (AuthenticationException)
            {
                return Unauthorized();
            }

            return Ok(scientificWorks);
        }
    }
}
