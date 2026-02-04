using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Models;
using MyFirstApi.Services;
namespace MyFirstApi.Controllers;

[Route("api/posts")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly PostService _postsService;
    public PostController()
    {
        _postsService = new PostService();
    }

    [HttpGet]
    public ActionResult<List<Post>> GetPosts()
    {

        return new List<Post>
        {
            //posts
            new()
            {
                Id = 1,
                UserId = 1,
                Title = "Post1",
                Body = "The first post."
            },
            //posts
             new()
            {
                Id = 2,
                UserId = 2,
                Title = "Post2",
                Body = "The second post."
            },
            //posts
             new()
            {
                Id = 3,
                UserId = 3,
                Title = "Post3",
                Body = "The third post."
            }
        };
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> GetPost(int id)
    {
        var post = await _postsService.Getpost(id);

        if (post == null)
        {
            return NotFound();
        }

        return Ok(post);
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost(Post post)
    {
        await _postsService.CreatPost(post);
        return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
    }   
}