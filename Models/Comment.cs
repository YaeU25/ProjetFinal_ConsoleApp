using System;
using System.Collections.Generic;
using System.Text;

namespace TPfinal_ApplicationConsole.Models;

public class Comment
{
    public int Id { get; set; }
    public int? ArticleId { get; set; }
    public string Author { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public Comment(int? articleId, string author, string content, DateTime createdAt)
    {
        ArticleId = articleId;
        Author = author;
        Content = content;
        CreatedAt = createdAt;
    }
    public override string ToString()
    {
        return $"Comment : {this.Content} par {this.Author}, Date({this.CreatedAt})";
    }
}
