using LDKProject.Data;
using LDKProject.Models;
using LDKProject.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace LDKProject.Repositories;

public class ArticleRepository : IArticleRepository
{
    private readonly IConfiguration configuration;
    private readonly AppDBContext _appDbContext;

    public ArticleRepository(IConfiguration configuration, AppDBContext appDbContext)
    {
        this.configuration = configuration;
        _appDbContext = appDbContext;
    }

    public async Task<CategoryArticle> SaveCategoryArticle(CategoryArticle categoryArticle)
    {
        _appDbContext.CategoryArticle.Add(categoryArticle);
        await _appDbContext.SaveChangesAsync();

        return categoryArticle;
    }

    public async Task<Article> SaveArticle(Article article)
    {
        _appDbContext.Article.Add(article);
        await _appDbContext.SaveChangesAsync();

        return article;
    }
}

