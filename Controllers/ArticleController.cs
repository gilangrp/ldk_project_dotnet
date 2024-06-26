﻿using LDKProject.Constants;
using LDKProject.Exceptions;
using System.Net;
using LDKProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LDKProject.Models.DTO;
using Azure.Core;
using LDKProject.Models;
using AutoMapper;

namespace LDKProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ArticleController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        public ArticleController(ILogger<WeatherForecastController> logger,
            IMapper mapper, IArticleService articleService)
        {
            _logger = logger;
            _articleService = articleService;
            _mapper = mapper;

        }

        [HttpGet]
        [Route("GetAllCategoryArticle")]
        [Authorize]
        public async Task<IActionResult> GetAllCategoryArticle()
        {
            try
            {
                var article = await _articleService.GetAllCategoryArticle();
                return Ok(Utils.Utils.NewSuccessResponse(article, null, null));
            }
            catch (NotFoundException e)
            {
                return NotFound(Utils.Utils.NewErrorResponse(null, e.Message, Status.NotFoundErr, (int)HttpStatusCode.NotFound));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Terjadi kesalahan pada sistem");
            }
        }

        [HttpPost]
        [Route("CreateCategory")]
        [Authorize]

        public async Task<IActionResult> SaveCategoryArticle([FromBody] CreateCategoryArticleRequest request)
        {
            try
            {
                CategoryArticle payload = _mapper.Map<CategoryArticle>(request);
                if (payload == null)
                {
                    return BadRequest();
                }
                var result = await _articleService.SaveCategoryArticle(payload);
                return Ok(Utils.Utils.NewSuccessResponse(result, null, null));


            }
            catch (ConflictException e)
            {
                return NotFound(Utils.Utils.NewErrorResponse(null, e.Message, Status.Conflict, (int)HttpStatusCode.Conflict));
            }
            catch (BadRequestException e)
            {
                return BadRequest(Utils.Utils.NewErrorResponse(null, e.Message, Status.BadRequestErr, (int)HttpStatusCode.BadRequest));
            }
            catch (Exception ex)
            {
                var isDuplicate = Utils.Errors.IsDuplicateError(ex);
                if (isDuplicate)
                {
                    return Conflict(Utils.Utils.NewErrorResponse(null, null, Status.Conflict, (int)HttpStatusCode.Conflict));
                }
                return StatusCode((int)HttpStatusCode.InternalServerError, "Terjadi kesalahan pada sistem");
            }
        }

        [HttpGet]
        [Route("GetAllArticle")]
        [Authorize]
        public async Task<IActionResult> GetAllArticle()
        {
            try
            {
                var response = await _articleService.GetAllArticle();
                return Ok(Utils.Utils.NewSuccessResponse(response, null, null));
            }
            catch (NotFoundException e)
            {
                return NotFound(Utils.Utils.NewErrorResponse(null, e.Message, Status.NotFoundErr, (int)HttpStatusCode.NotFound));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Terjadi kesalahan pada sistem");
            }
        }

        [HttpPost]
        [Route("CreateArticle")]
        [Authorize]
        public async Task<IActionResult> SaveArticle([FromBody] CreateArticleRequest request)
        {
            try
            {
                Article payload = _mapper.Map<Article>(request);
                if (payload == null)
                {
                    return BadRequest();
                }
                var result = await _articleService.SaveArticle(payload);
                return Ok(Utils.Utils.NewSuccessResponse(result, null, null));


            }
            catch (ConflictException e)
            {
                return NotFound(Utils.Utils.NewErrorResponse(null, e.Message, Status.Conflict, (int)HttpStatusCode.Conflict));
            }
            catch (BadRequestException e)
            {
                return BadRequest(Utils.Utils.NewErrorResponse(null, e.Message, Status.BadRequestErr, (int)HttpStatusCode.BadRequest));
            }
            catch (Exception ex)
            {
                var isDuplicate = Utils.Errors.IsDuplicateError(ex);
                if (isDuplicate)
                {
                    return Conflict(Utils.Utils.NewErrorResponse(null, null, Status.Conflict, (int)HttpStatusCode.Conflict));
                }
                return StatusCode((int)HttpStatusCode.InternalServerError, "Terjadi kesalahan pada sistem");
            }
        }

        [HttpGet]
        [Route("GetAllAuthor")]
        [Authorize]
        public async Task<IActionResult> GetAllAuthor()
        {
            try
            {
                var response = await _articleService.GetAllAuthor();
                return Ok(Utils.Utils.NewSuccessResponse(response, null, null));
            }
            catch (NotFoundException e)
            {
                return NotFound(Utils.Utils.NewErrorResponse(null, e.Message, Status.NotFoundErr, (int)HttpStatusCode.NotFound));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Terjadi kesalahan pada sistem");
            }
        }

        [HttpPost]
        [Route("CreateAuthor")]
        [Authorize]
        public async Task<IActionResult> SaveAuthor([FromBody] CreateAuthorRequest request)
        {
            try
            {
                Author payload = _mapper.Map<Author>(request);
                if (payload == null)
                {
                    return BadRequest();
                }
                var result = await _articleService.SaveAuthor(payload);
                return Ok(Utils.Utils.NewSuccessResponse(result, null, null));


            }
            catch (ConflictException e)
            {
                return NotFound(Utils.Utils.NewErrorResponse(null, e.Message, Status.Conflict, (int)HttpStatusCode.Conflict));
            }
            catch (BadRequestException e)
            {
                return BadRequest(Utils.Utils.NewErrorResponse(null, e.Message, Status.BadRequestErr, (int)HttpStatusCode.BadRequest));
            }
            catch (Exception ex)
            {
                var isDuplicate = Utils.Errors.IsDuplicateError(ex);
                if (isDuplicate)
                {
                    return Conflict(Utils.Utils.NewErrorResponse(null, null, Status.Conflict, (int)HttpStatusCode.Conflict));
                }
                return StatusCode((int)HttpStatusCode.InternalServerError, "Terjadi kesalahan pada sistem");
            }
        }
    }
}
