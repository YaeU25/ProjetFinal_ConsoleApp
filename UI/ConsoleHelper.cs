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
        Article article = SaisirArticle();

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

    public static Article SaisirArticle()
    {
        Console.WriteLine("Saisir un titre: ");
        string title = Console.ReadLine() ?? "";

        Console.WriteLine("Saisir un content: ");
        string content = Console.ReadLine() ?? "";

        DateTime createdAt = DateTime.Now;

        return new Article(title, content, createdAt);
    }
}
