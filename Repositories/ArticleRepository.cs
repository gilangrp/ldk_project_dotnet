using LDKProject.Data;
using LDKProject.Exceptions;
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
    public async Task<IList<CategoryArticle>> GetAllCategoryArticle()
    {
        var items = await _appDbContext.CategoryArticle.ToListAsync();
        if (items == null || items.Count == 0)
        {
            throw new NotFoundException("Kategori Artikel tidak ditemukan");
        }

        return items;
    }
    public async Task<CategoryArticle> SaveCategoryArticle(CategoryArticle categoryArticle)
    {
        _appDbContext.CategoryArticle.Add(categoryArticle);
        await _appDbContext.SaveChangesAsync();

        return categoryArticle;
    }

    public async Task<IList<Article>> GetAllArticle()
    {
        var items = await _appDbContext.Article.ToListAsync();
        if (items == null || items.Count == 0)
        {
            throw new NotFoundException("Artikel tidak ditemukan");
        }

        return items;
    }
    public async Task<Article> SaveArticle(Article article)
    {
        _appDbContext.Article.Add(article);
        await _appDbContext.SaveChangesAsync();

        return article;
    }

    public async Task<IList<Author>> GetAllAuthor()
    {
        var items = await _appDbContext.Author.ToListAsync();
        if (items == null || items.Count == 0)
        {
            throw new NotFoundException("Author tidak ditemukan");
        }

        return items;
    }

    public async Task<Author> SaveAuthor(Author author)
    {
        _appDbContext.Author.Add(author);
        await _appDbContext.SaveChangesAsync();

        return author;
    }

    
}

