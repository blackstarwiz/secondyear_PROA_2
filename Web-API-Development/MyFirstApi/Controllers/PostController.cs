using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Models;
namespace MyFirstApi.Controllers;

[Route("api/posts")]
[ApiController]
public class PostController : ControllerBase
{
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
}