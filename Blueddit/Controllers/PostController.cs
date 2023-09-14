using Blueddit.Data;
using Blueddit.DTOs;
using Blueddit.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blueddit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly DataContext _context;
        public PostController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("getAllPost")]
        public async Task<ActionResult<List<Post>>> GetAllPost()
        {
            var PostList = _context.Posts.ToList();
            return Ok(PostList);
        }

        [HttpPost()]
        public async Task<ActionResult<List<Post>>> CreatePost(PostCreateDto request)
        {
            var NewPost = new Post
            {
                Title = request.Title,
                Content = request.Content,
                Author = request.Author,
                Type = request.Type,
                UserId = 1,
            };
            _context.Posts.Add(NewPost);
            await _context.SaveChangesAsync();
            return Ok(await _context.Posts.Include(c => c.User).ToListAsync());
        }
        [HttpGet("{postId}")]
        public async Task<ActionResult<Post>> GetPost(int postId)
        {
            var Post = await _context.Posts.FindAsync(postId); 
            if(Post == null) return NotFound(new { Message = "Post not found!" });
            return Ok(Post);
        }
        [HttpPut("{postId}")]
        public async Task<ActionResult<Post>> UpdatePost(int postId, PostUpdateDto request)
        {
            var UpdatedPost = await _context.Posts.FindAsync(postId);
            if(UpdatedPost == null) return BadRequest(new { Message = "Post not found" });
            UpdatedPost.Title = request.Title;
            UpdatedPost.Content = request.Content;
            _context.Update(UpdatedPost);
            await _context.SaveChangesAsync();
            return Ok("Post updated");
        }
        [HttpDelete("{postId}")]
        public async Task<ActionResult<Post>> DeletePost(int postId)
        {
            var UpdatedPost = await _context.Posts.FindAsync(postId);
            if (UpdatedPost == null) return BadRequest(new { Message = "Post not found" });
            _context.Posts.Remove(UpdatedPost);
            await _context.SaveChangesAsync();
            return Ok("Post deleted");
        }

    }
}
