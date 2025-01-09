using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LuckySpin.Controllers
{
    public class SpinnerController : Controller
    {
        private int luck;

        public IActionResult Index(int luck)
        {
            // Set the private variable
            this.luck = luck;

            // Build HTML content
            System.Text.StringBuilder htmlToShow = new System.Text.StringBuilder($"<body><h1>Lucky {this.luck}</h1>");
            htmlToShow.Append("<button onclick='window.location.reload()'>Spin</button>");

            // Generate spin results
            Random random = new Random();
            int[] spin = new int[3];
            for (int i = 0; i < spin.Length; i++)
            {
                spin[i] = random.Next(1, 10); // Random number between 1-9
                htmlToShow.Append($"<div>{spin[i]}</div>");
            }

            // Check if luck matches any spin result
            if (spin.Contains(this.luck))
            {
                htmlToShow.Append("<img src='http://studentfolders.cascadia.edu/itweb285/LuckySpinCoins.jpg'/>");
            }
            htmlToShow.Append("</body>");

            // Return the generated content
            return new ContentResult
            {
                Content = htmlToShow.ToString(),
                ContentType = "text/html"
            };
        }
    }
}