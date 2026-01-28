CREATE DATABASE BlogConsole;

USE BlogConsole;

CREATE TABLE article (
    id INT AUTO_INCREMENT,
    title VARCHAR(100),
    content LONGTEXT,
    createdAt datetime DEFAULT CURRENT_TIMESTAMP,
    updatedAt datetime DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (id)
);

CREATE TABLE comment (
    id INT AUTO_INCREMENT,
    articleId int,
    author VARCHAR(100),
    content LONGTEXT,
    createdAt datetime DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (id),
    CONSTRAINT fk_article_comment FOREIGN KEY (articleId) REFERENCES article(id)
);