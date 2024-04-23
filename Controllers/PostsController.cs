using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EFCore;
using BlogApp.Entity;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers
{
    public class PostsController:Controller
    {
        private IPostRepository _postRepository;
        private ICommentRepository _commentRepository;
        public PostsController(IPostRepository postRepository, ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string tag)
        {
            var posts = _postRepository.Posts;
            if(!string.IsNullOrEmpty(tag)) {
                return View(new PostViewModel{Posts=await posts.Where(p=>p.Tags.Any(t=>t.URL==tag)).ToListAsync()});
            }

            return View(new PostViewModel{Posts=await posts.ToListAsync()});
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string? url)
        {
            if(url == null)
                return NotFound();
            
            var post =await _postRepository.Posts
            .Include(x=>x.Tags)
            .Include(x=>x.Comments)
            .ThenInclude(x=>x.User)
            .FirstOrDefaultAsync(p=>p.URL==url);

            if(post == null)
                return NotFound();
            
            return View(post);
        }

        [HttpPost]
        public IActionResult AddComment(int PostID, string userName, string Text, string URL){
            var entity = new Comment{
                Text=Text,
                PublishedOn = DateTime.Now,
                PostID = PostID,
                User = new User{
                    Name=userName,
                    Image="avatar.jpg"
                }
            };
            _commentRepository.CreateComment(entity);
            return Redirect("/posts/details/"+URL);
            // return RedirectToRoute("post-details",new{url=URL});
        }
    }
}
