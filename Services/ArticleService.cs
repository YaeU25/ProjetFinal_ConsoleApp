using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using TPfinal_ApplicationConsole.Data;
using TPfinal_ApplicationConsole.Models;

namespace TPfinal_ApplicationConsole.Services;

public class ArticleService
{
    private string request = "";

    public Article Create(Article article)
    {
        string request = "INSERT INTO article (title, content, createdAt) VALUES (@title, @content, @createdAt)";
        
        using MySqlConnection connection = DataConnection.GetConnection();
        using MySqlCommand command = new MySqlCommand(request, connection);

        command.Parameters.AddWithValue("@title", article.Title);
        command.Parameters.AddWithValue("@content", article.Content);
        command.Parameters.AddWithValue("@createdAt", article.CreatedAt);

        connection.Open();
        command.ExecuteNonQuery();

        article.Id = (int)command.LastInsertedId;

        return article;
    }

    public Article Update(Article article)
    {
        request = "UPDATE article SET title=@title, content=@content, updatedAt=@updatedAt WHERE id=@id";

        using MySqlConnection connection = DataConnection.GetConnection();
        using MySqlCommand command = new MySqlCommand(request, connection);

        command.Parameters.AddWithValue("@title", article.Title);
        command.Parameters.AddWithValue("@content", article.Content);
        command.Parameters.AddWithValue("@updatedAt", article.UpdatedAt);
        command.Parameters.AddWithValue("@id", article.Id);

        connection.Open(); 
        command.ExecuteNonQuery();

        return article;

    }
    public bool Delete(Article article)
    {
        //ComentService commentService = new ComentService();
        //ComentService.DeleteAllCommandsOfAClient(article);

        request = "DELETE FROM article WHERE id=@id";

        using MySqlConnection connection = DataConnection.GetConnection();
        using MySqlCommand command = new MySqlCommand(request, connection);

        command.Parameters.AddWithValue("@id", article.Id);

        connection.Open();

        int rowsAffected = command.ExecuteNonQuery();

        return rowsAffected > 0;

    }
    public Article? GetById(int id) { 
        Article? article = null;
        request = "SELECT id, title, content, createdAt, updatedAt FROM article WHERE id=@id;";

        using MySqlConnection connection = DataConnection.GetConnection();
        using MySqlCommand command = new MySqlCommand(request, connection);

        command.Parameters.AddWithValue("@id", id);

        connection.Open();

        using MySqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            article = new Article(
                reader.GetInt32("id"),
                reader.GetString("title"),
                reader.GetString("content"),
                reader.GetDateTime("createdAt"),
                reader.GetDateTime("updatedAt")
                );
        }

        if(article is not null)
        {
            //ComentService commentService = new ComentService();
            //ComentService.GetAllCommandsOfAClient(article);
        }

        return article;

    }

    public List<Article> GetAll()
    {
        List<Article> articles = new();

        request = "SELECT * FROM article;";

        using MySqlConnection connection = DataConnection.GetConnection();
        using MySqlCommand command = new MySqlCommand(request, connection);

        connection.Open();

        using MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read()) {
            articles.Add(
                new Article(
                    reader.GetInt32("id"),
                    reader.GetString("title"),
                    reader.GetString("content"),
                    reader.GetDateTime("createdAt"),
                    reader.GetDateTime("updatedAt")
                    ));
        }

        return articles;
    }
}
