using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Inspecco.Controllers
{
    public class PageController : Controller
    {
        private Uri _url;
        private string _html;
        private string[] Titles = new string[5];
        private string[] Links = new string[5];
        private string[] Paragraphs = new string[5];
        public void TitleGet(string Url, string xPath, int i)
        {
            _url = new Uri(Url);
            WebClient client = new WebClient();
            _html = client.DownloadString(_url);
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(_html);
            Titles[i] = document.DocumentNode.SelectSingleNode(xPath).InnerText;
            ViewBag.Titles = Titles;
            //h2[contains(text(),'This Is How Twitter’s Edit Button Can Actually Wor')]
        }
        public void LinkGet(string Url, string xPath, string tag, int i)
        {
            _url = new Uri(Url);
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            _html = client.DownloadString(_url);
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(_html);
            Links[i] = document.DocumentNode.SelectSingleNode(xPath).Attributes[tag].Value;
            ViewBag.Links = Links;
        }
        public void ContentGet(string Url, string xPath, int i)
        {
            _url = new Uri(Url);
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            _html = client.DownloadString(_url);
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(_html);
            HtmlNode htmlNode = document.DocumentNode.SelectSingleNode(xPath);
            if (htmlNode == null)
            {
                htmlNode = document.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[1]/main[1]/article[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/p[1]");
                if (htmlNode != null)
                {
                    Paragraphs[i] = htmlNode.InnerText;
                }
                else
                {
                    Paragraphs[i] = "Like most parents, I try to limit my kid's screen time. But screens are so ubiquitous that it's sometimes hard for me to grasp how thoroughly they have infiltrated my kids.";
                }
                ViewBag.Paragraphs = Paragraphs;
            }

        }

        public IActionResult Index()
        {
            string lnk = "https://www.wired.com";
            for (int i = 0; i < 5; i++)
            {
                TitleGet(lnk, "/html[1]/body[1]/div[1]/div[1]/main[1]/div[1]/div[1]/section[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[" + (i + 1) + "]/div[2]/a[1]/h2[1]", i);//SelectorsHub kullanımı "abs Xpath"
                LinkGet(lnk, "/html[1]/body[1]/div[1]/div[1]/main[1]/div[1]/div[1]/section[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[" + (i + 1) + "]/div[2]/a[1]", "href", i);
            }
            for (int i = 0; i < 5; i++)
            {
                string Link = lnk + Links[i].ToString();
                ContentGet(Link, "/html/body/div[1]/div/main/article/div[2]/div/div[1]/div/div[1]/p[1]", i);
            }
            return View();
        }
    }
}
