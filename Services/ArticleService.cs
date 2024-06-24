using AutoMapper;
using LDKProject.Exceptions;
using LDKProject.Models;
using LDKProject.Models.DTO;
using LDKProject.Models.Response;
using LDKProject.Repositories;

namespace LDKProject.Services;

public class ArticleService : IArticleService
{
    private readonly IMapper mapper;
    private readonly ILogger<WeatherForecast> _logger;
    private readonly IArticleRepository _categoryArticleRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ArticleService(ILogger<WeatherForecast> logger, IArticleRepository categoryArticleRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper)
    {
        this.mapper = mapper;
        _logger = logger;
        _categoryArticleRepository = categoryArticleRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<CategoryArticle> SaveCategoryArticle(CategoryArticle categoryArticle)
    {
        var payload = new CategoryArticle
        {
            Id = Guid.NewGuid().ToString(),
            CategoryName = categoryArticle.CategoryName,
            CreatedAt = DateTime.Now,
        };
        return await _categoryArticleRepository.SaveCategoryArticle(payload);

    }

    public async Task<Article> SaveArticle(Article article)
    {
        var payload = new Article
        {
            Id = Guid.NewGuid().ToString(),
            Title = article.Title,
            Content = article.Content,
            AuthorId = article.AuthorId,
            CategoryId = article.CategoryId,
            CreatedAt = DateTime.Now,
        };
        return await _categoryArticleRepository.SaveArticle(payload);

    }

}

