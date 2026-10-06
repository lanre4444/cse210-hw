using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video v1 = new Video("Unboxing the Trail Pack 40", "OutdoorOwen", 480);
        v1.AddComment(new Comment("Sam", "Great review, very thorough!"));
        v1.AddComment(new Comment("Priya", "Where can I buy this pack?"));
        v1.AddComment(new Comment("Jake", "Love the color options."));

        Video v2 = new Video("5-Minute Healthy Breakfast", "KitchenKara", 312);
        v2.AddComment(new Comment("Maria", "Made this today, so good."));
        v2.AddComment(new Comment("Tom", "Can I swap the oats?"));
        v2.AddComment(new Comment("Lena", "Subscribed!"));
        v2.AddComment(new Comment("Ravi", "Quick and easy."));

        Video v3 = new Video("Budget Gaming Setup Tour", "PixelPete", 905);
        v3.AddComment(new Comment("Chris", "That monitor is a steal."));
        v3.AddComment(new Comment("Ana", "What mouse is that?"));
        v3.AddComment(new Comment("Dev", "Clean desk, nice work."));

        List<Video> videos = new List<Video> { v1, v2, v3 };

        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}