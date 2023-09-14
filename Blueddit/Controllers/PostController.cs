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

        [HttpGet("getAll")]
        public async Task<ActionResult<List<Post>>> GetAllPosts()
        {
            var PostList = await _context.Posts.ToListAsync();
            return Ok(PostList);
        }

        [HttpPost()]
        public async Task<ActionResult<List<Post>>> CreatePost(PostCreateDto request)
        {
            var NewPost = new Post
            {
                Title = request.Title,
                Content = request.Content,
                Type = request.Type,
                UserId = request.UserId,
            };
            _context.Posts.Add(NewPost);
            await _context.SaveChangesAsync();
            return Ok("Post added");
        }
        [HttpGet("{postId}")]
        public async Task<ActionResult<Post>> GetPost(int postId)
        {
            var Post = await _context.Posts.FindAsync(postId); 
            if(Post == null) return NotFound(new { Message = "Post not found!" });
            return Ok(await _context.Posts.Where(p => p.Id == postId).FirstOrDefaultAsync()); 
        }
        [HttpPut("{postId}")]
        public async Task<ActionResult<Post>> UpdatePost(int postId, PostUpdateDto request)
        {
            var UpdatedPost = await _context.Posts.FindAsync(postId);
            if(UpdatedPost == null) return BadRequest(new { Message = "Post not found" });
            UpdatedPost.Title = request.Title;
            UpdatedPost.Content = request.Content;
            _context.Posts.Update(UpdatedPost);
            await _context.SaveChangesAsync();
            return Ok("Post updated");
        }
        [HttpDelete("{postId}")]
        public async Task<ActionResult<Post>> DeletePost(int postId)
        {
            var DeletedPost = await _context.Posts.FindAsync(postId);
            if (DeletedPost == null) return BadRequest(new { Message = "Post not found" });
            _context.Posts.Remove(DeletedPost);
            await _context.SaveChangesAsync();
            return Ok("Post deleted");
        }

    }
}
