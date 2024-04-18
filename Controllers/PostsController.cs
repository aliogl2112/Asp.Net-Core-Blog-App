using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EFCore;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers
{
    public class PostsController:Controller
    {
        private IPostRepository _postRepository;
        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(
                new PostViewModel{
                    Posts=await _postRepository.Posts.ToListAsync()
                }
            );
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string? url)
        {
            if(url == null)
                return NotFound();
            
            var post =await _postRepository.Posts.FirstOrDefaultAsync(p=>p.URL==url);

            if(post == null)
                return NotFound();
            
            return View(post);
        }
    }
}
