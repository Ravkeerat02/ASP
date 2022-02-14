using Lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Lab5.Controllers
{
    public class HomeController : Controller
    {
        public FaqsContext context { get; set; }

        public  HomeController(FaqsContext ctx)
            {
                context= ctx;
            }
        
        public IActionResult Index(string topic , string category)
        {
            ViewBag.Topic = context.Topics.OrderBy(t => t.Name).ToList(); 

            ViewBag.Category = context.Categories.OrderBy(c => c.Name).ToList();
            ViewBag.SelectedTopic = topic; 

            IQueryable<FAQ> faqs = context.FAQs
                .Include(f => f.Topic)
                .Include(f => f.Category)
                .Include(f => f.Question);

            if(!string.IsNullOrEmpty(topic))
            {
                faqs = faqs.Where(f => f.TopicID == topic);
            }

            if (!string.IsNullOrEmpty(category))
            {
                faqs = faqs.Where(f => f.CategoryID == topic);
            }


            return View(faqs.ToList());
        }

        }
    }

