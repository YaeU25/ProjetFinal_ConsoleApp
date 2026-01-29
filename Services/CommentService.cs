using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Text;
using TPfinal_ApplicationConsole.Data;
using TPfinal_ApplicationConsole.Models;

namespace TPfinal_ApplicationConsole.Services;

public class CommentService
{
    private string request = "";

    public Comment Create(Comment comment)
    {
        string request = "INSERT INTO comment (articleId, author, content, createdAt) VALUES (@articleId, @author, @content, @createdAt)";

        using MySqlConnection connection = DataConnection.GetConnection();
        using MySqlCommand command = new MySqlCommand(request, connection);

        command.Parameters.AddWithValue("@articleId", comment.ArticleId);
        command.Parameters.AddWithValue("@author", comment.Author);
        command.Parameters.AddWithValue("@content", comment.Content);
        command.Parameters.AddWithValue("@createdAt", comment.CreatedAt);

        connection.Open();
        command.ExecuteNonQuery();

        comment.Id = (int)command.LastInsertedId;

        return comment;
    }
    public Comment? GetById(int id)
    {
        Comment? comment = null;
        request = "SELECT * FROM comment WHERE id=@id;";

        using MySqlConnection connection = DataConnection.GetConnection();
        using MySqlCommand command = new MySqlCommand(request, connection);

        command.Parameters.AddWithValue("@id", id);

        connection.Open();

        using MySqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            comment = new Comment(
                reader.GetInt32("id"),
                reader.GetInt32("articleId"),
                reader.GetString("content"),
                reader.GetString("author"),
                reader.GetDateTime("createdAt")
                );
        }

        return comment;
    }
    public bool Delete(Comment comment)
    {
        request = "DELETE FROM comment WHERE id=@id";

        using MySqlConnection connection = DataConnection.GetConnection();
        using MySqlCommand command = new MySqlCommand(request, connection);

        command.Parameters.AddWithValue("@id", comment.Id);

        connection.Open();

        int rowsAffected = command.ExecuteNonQuery();

        return rowsAffected > 0;
    }

    public List<Comment> GetAllCommentsByArticle(Article article)
    {
        List<Comment> comments = new();

        request = "SELECT id, articleId, author, content, createdAt FROM comment WHERE articleId=@articleId;";

        using MySqlConnection connection = DataConnection.GetConnection();
        using MySqlCommand command = new MySqlCommand(request, connection);

        command.Parameters.AddWithValue("@articleId", article.Id);

        connection.Open();

        using MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            comments.Add(new Comment(
                reader.GetInt32("id"),
                reader.GetInt32("articleId"),
                reader.GetString("author"),
                reader.GetString("content"),
                reader.GetDateTime("createdAt")
                ));
        }

        return comments;
    }

    public void DeleteAllCommentsByArticle(Article article)
    {
        request = "DELETE FROM comment WHERE articleId=@articleId";

        using MySqlConnection connection = DataConnection.GetConnection();
        using MySqlCommand command = new MySqlCommand(request, connection);

        command.Parameters.AddWithValue("@articleId", article.Id);

        connection.Open();

        command.ExecuteNonQuery();
    }
}
