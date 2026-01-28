using System;
using System.Collections.Generic;
using System.Text;

namespace TPfinal_ApplicationConsole.Models;

public class Article
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    List<Comment> comments { get; set; } = new List<Comment>();
    public Article(string title, string content, DateTime createdAt, DateTime? updatedAt, List<Comment> comments)
    {
        Title = title;
        Content = content;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        this.comments = comments;
    }
    public Article(string title, string content, DateTime createdAt)
    {
        Title = title;
        Content = content;
        CreatedAt = createdAt;
    }

    public Article(int id, string title, string content, DateTime createdAt, DateTime? updatedAt) : this(title, content, createdAt)
    {
        Id = id;
        UpdatedAt = updatedAt;
    }


    public override string ToString()
    {
        return $"Article ID : {this.Id}, le titre : {this.Title}, le content : {this.Content}, Creé à : {this.CreatedAt}, mis à jour à : {this.UpdatedAt}";
    }
}
