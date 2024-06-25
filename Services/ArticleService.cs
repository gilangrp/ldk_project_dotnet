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
    private readonly IArticleRepository _articleRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ArticleService(ILogger<WeatherForecast> logger, IArticleRepository articleRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper)
    {
        this.mapper = mapper;
        _logger = logger;
        _articleRepository = articleRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IList<CategoryArticle>> GetAllCategoryArticle()
    {
        return await _articleRepository.GetAllCategoryArticle();
    }

   
    public async Task<CategoryArticle> SaveCategoryArticle(CategoryArticle categoryArticle)
    {
        var payload = new CategoryArticle
        {
            Id = Guid.NewGuid().ToString(),
            CategoryName = categoryArticle.CategoryName,
            CreatedAt = DateTime.Now,
        };
        return await _articleRepository.SaveCategoryArticle(payload);

    }

    public async Task<IList<Article>> GetAllArticle()
    {
        return await _articleRepository.GetAllArticle();
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
        return await _articleRepository.SaveArticle(payload);

    }

    public async Task<IList<Author>> GetAllAuthor()
    {
        return await _articleRepository.GetAllAuthor();
    }

    public async Task<Author> SaveAuthor(Author author)
    {
        var payload = new Author
        {
            UserId = Guid.NewGuid().ToString(),
            Name = author.Name,
            Biography = author.Biography,
            DateOfBirth = author.DateOfBirth,
            InstagramAccount = author.InstagramAccount,
            CreatedAt = DateTime.Now,
        };
        return await _articleRepository.SaveAuthor(payload);
    }

  
}

