using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMSapplication.Models;
using CMSapplication.Areas.Admin.ViewModel;

namespace CMSapplication.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [RoutePrefix("Post")]
    public class PostController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Post
        
        public ActionResult Index()
        {
            var posts = db.posts.ToList();
            return View(posts);
        }
        //admin/post/create
        [HttpGet]
        public ActionResult create()
        {
            var PostsOfCust = new post();
            return View(PostsOfCust);
        }
        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult create(post PostsOfCust)
        {
            db.posts.Add(PostsOfCust);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        //admin/post/edit/id
        [HttpGet]
        [Route("edit/{id}")]
    
        public ActionResult edit(string id)
        {
            var postt = db.posts.SingleOrDefault(c => c.Id == id);
            if (postt == null)
            {
                return HttpNotFound();
            }
           
            return View("edit");
        }
        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult edit(post model)
        {
            //update model in the database
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            return RedirectToAction("index");
        }
        public ActionResult Details(string id)
        {
            var details = db.posts.SingleOrDefault(x => x.Id == id);
               if(details==null)
            {
                HttpNotFound();

            }
            return View(details);
        }
        
    }
}