using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TPfinal_ApplicationConsole.Models;

public class Article
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public List<Comment> Comments { get; set; } = new List<Comment>();

    public Article(string title, string content, DateTime createdAt)
    {
        Title = title;
        Content = content;
        CreatedAt = createdAt;
    }
    public Article(string title, string content, DateTime createdAt, DateTime? updatedAt)
    {
        Title = title;
        Content = content;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
    public Article(int id, string title, string content, DateTime createdAt, DateTime? updatedAt) : this(title, content, createdAt, updatedAt)  
    {
        Id = id;
    }

    public override string ToString()
    {
        return $"Article ID : {this.Id}, le titre : {this.Title}, le content : {this.Content}, Creé à : {CreatedAt?.ToString("dd/MM/yyyy HH:mm")} , mis à jour à : {UpdatedAt?.ToString("dd/MM/yyyy HH:mm")}";
    }
}
