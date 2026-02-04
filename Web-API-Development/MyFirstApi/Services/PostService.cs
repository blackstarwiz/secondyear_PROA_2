using System.IO.Pipes;
using MyFirstApi.Models;
namespace MyFirstApi.Services;
public class PostService
{
    private static readonly List<Post> AllPost = new();
    public Task CreatPost(Post item)
    {
        AllPost.Add(item);
        return Task.CompletedTask;
    }

    //Post aanpassen op basis van Id waarbij dat nieuw object Post die vervangt
    public Task<Post?> UpdatePost(int id, Post item)
    {
        var post = AllPost.FirstOrDefault(x => x.Id == id);

        if (post != null)
        {
            post.Title = item.Title;
            post.Body = item.Body;
            post.UserId = item.UserId;
        }
        return Task.FromResult(post);
    }

    //Ophalen van bepaalde Post op basis van x.Id
    public Task<Post?> Getpost(int id)
    {
        return Task.FromResult(AllPost.FirstOrDefault(x => x.Id == id));
    }

    //Ophalen van All Posts
    public Task<List<Post>>  GetAllPost()
    {
        return Task.FromResult(AllPost);
    }


    //Verwijderen van bepaalde post
    public Task DeletePost(int id)
    {
        var post = AllPost.FirstOrDefault(x => x.Id == id);

        if(post != null)
        {
            AllPost.Remove(post);
        }
        return Task.CompletedTask;
    }
}