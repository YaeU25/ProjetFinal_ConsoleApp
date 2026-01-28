using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Text;
using TPfinal_ApplicationConsole.Models;
using TPfinal_ApplicationConsole.Services;

namespace TPfinal_ApplicationConsole.UI;

public class ConsoleHelper
{
    public static void GetAll()
    {
        ArticleService articleService = new ArticleService();
        foreach (var article in articleService.GetAll())
        {
            Console.WriteLine(article);
        }
    }

    public static void CreateArticle()
    {
        Article article = RequestArticleCreate();

        ArticleService articleService = new ArticleService();

        try
        {
            articleService.Create(article);
            Console.WriteLine($"{article.Title} enregistré(e)");
        }
        catch (Exception)
        {
            Console.WriteLine("Une erreur s'est produite lors de l'enregistrement");
        }

    }

    public static Article RequestArticleCreate()
    {
        Console.WriteLine("Saisir un titre: ");
        string title = Console.ReadLine() ?? "";

        Console.WriteLine("Saisir un content: ");
        string content = Console.ReadLine() ?? "";

        DateTime createdAt = DateTime.Now;

        return new Article(title, content, createdAt);
    }
    public static Article RequestArticleUpdate()
    {
        Console.WriteLine("Saisir un titre: ");
        string title = Console.ReadLine() ?? "";

        Console.WriteLine("Saisir un content: ");
        string content = Console.ReadLine() ?? "";

        DateTime updatedAt = DateTime.Now;

        return new Article(title, content, updatedAt);
    }

    public static void UpdateArticle()
    {
        Console.Write("Saisir l'ID d'un article: ");
        int.TryParse(Console.ReadLine(), out int id);

        ArticleService articleService = new ArticleService();

        if(articleService.GetById(id) is null)
        {
            Console.WriteLine($"Aucun article trouvé avec l'id {id}");
            return;
        }

        Article article = RequestArticleUpdate();
        article.Id = id;

        try
        {
            articleService.Update(article);
            Console.WriteLine($"Article mis à jour");
        }
        catch (Exception)
        {
            Console.WriteLine("Une erreur s'est produite lors de l'enregistrement");
        } 
    }
    public static void DeleteArticle()
    {
        Console.Write("Saisir l'ID d'un article: ");
        int.TryParse(Console.ReadLine(), out int id);

        ArticleService articleService = new ArticleService();

        Article? article = articleService.GetById(id);

        if(article is null)
        {
            Console.WriteLine($"Aucun article trouvé avec l'id {id}");
            return;
        }

        try
        {
            articleService.Delete(article);
            Console.WriteLine($"Article supprimé");
        }
        catch (Exception)
        {
            Console.WriteLine("Une erreur s'est produite lors de l'enregistrement");
        } 
    }

    public static void GetArticleDetailById()
    {
        Console.Write("Saisir l'ID d'un article: ");
        int.TryParse(Console.ReadLine(), out int id);

        ArticleService articleService = new ArticleService();

        Article? article = articleService.GetById(id);

        if (article is null)
        {
            Console.WriteLine($"Aucun article trouvé avec l'id {id}");
            return;
        }

        Console.WriteLine(article.ToString());
        article.Comments.ForEach(c => Console.WriteLine($"\t{c}"));
    }
}
