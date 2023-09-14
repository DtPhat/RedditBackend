using Blueddit.Data;
using Blueddit.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blueddit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly DataContext _context;
        public CommentController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("{postId}")]
        public async Task<ActionResult<List<Comment>>> GetComments(int postId)
        {
            var CommentList = await _context.Comments.Where(c => c.PostId == postId).ToListAsync();
            return Ok(CommentList);
        }
        [HttpGet("{postId}/totalItem")]
        public int GetCommentNumber (int postId)
        {
            var CommentCount = _context.Comments.Count(c =>  c.PostId == postId);
            return CommentCount;
        }
        [HttpPost("{postId}")]
        public async Task<ActionResult<Comment>> AddComment(int postId, CommentCreateDto request) 
        {
            var NewComment = new Comment
            {
                Content = request.Content,
                UserId = request.UserId,
                PostId = postId,
            };
            _context.Comments.Add(NewComment);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
