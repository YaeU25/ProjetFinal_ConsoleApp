using System;
using System.Collections.Generic;
using System.Text;

namespace TPfinal_ApplicationConsole.UI;

public class ConsoleMenu
{
    public void Menu()
    {
        Console.WriteLine("\n1. Lister les articles");
        Console.WriteLine("2. Creer un article");
        Console.WriteLine("3. Voir un article");
        Console.WriteLine("4. Modifier un article");
        Console.WriteLine("5. Supprimer un article");
        Console.WriteLine("6. Ajouter un commentaire");
        Console.WriteLine("7. Supprimer un commentaire");
        Console.WriteLine("0. Quitter");
    }

    public void Start()
    {
        while (true)
        {
            Menu();
            Console.Write("\nChoix: ");
            string choix = Console.ReadLine() ?? "";

            switch (choix)
            {
                case "1":
                    Console.WriteLine("\n=== LISTE DES ARTICLES ===");
                    ConsoleHelper.GetAll();
                    break;
                case "2":
                    Console.WriteLine("\n=== CREATION ARTICLE ===");
                    ConsoleHelper.CreateArticle();
                    break;
                case "3":
                    Console.WriteLine("\n=== DETAIL CLIENT ===");
                    
                    break;
                case "4":
                    Console.WriteLine("\n=== MODIFICATION ARTICLE ===");
                    
                    break;
                case "5":
                    Console.WriteLine("\n=== SUPPRESSION ARTICLE ===");
                    
                    break;
                case "6":
                    Console.WriteLine("\n=== CREATION COMMENT ===");
                    
                    break;
                case "7":
                    Console.WriteLine("\n=== SUPPRESSION COMMENT ===");
                    
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Choix introuvable");
                    break;
            }
        }
    }
}
