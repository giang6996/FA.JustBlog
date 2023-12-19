using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public class PostService : IPostService
    {
        public IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public Post Find(int id)
        {
            return _unitOfWork.PostRepository.Find(id);
        }

        public void Add(Post post)
        {
            _unitOfWork.PostRepository.Add(post);
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _unitOfWork.PostRepository.Update(post);
            _unitOfWork.Commit();
        }

        public void Delete(Post post)
        {
            _unitOfWork.PostRepository.Delete(post);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _unitOfWork.PostRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public IList<Post> GetAll()
        {
            return _unitOfWork.PostRepository.GetAll();
        }


        public IList<Post> GetPublisedPosts()
        {
            return _unitOfWork.PostRepository.GetPublisedPosts();
        
        }

        public Post FindPost(int year, int month, string urlSlug)
        {
            return _unitOfWork.PostRepository.FindPost(year, month, urlSlug);
            
        }

        public IList<Post> GetUnpublisedPosts()
        {
            return _unitOfWork.PostRepository.GetUnpublisedPosts();
          
        }

        public IList<Post> GetLatestPost(int size)
        {
            return _unitOfWork.PostRepository.GetLatestPost(size);
            
        }

        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            return _unitOfWork.PostRepository.GetPostsByMonth(monthYear);
            
        }

        public int CountPostsForCategory(string category)
        {
            return _unitOfWork.PostRepository.CountPostsForCategory(category);
            
        }


        public IList<Post> GetPostsByCategory(string category)
        {
            return _unitOfWork.PostRepository.GetPostsByCategory(category);
           
        }

        public IList<Post> GetPostsByCategory(int id)
        {
            return _unitOfWork.PostRepository.GetPostsByCategory(id);

        }

        public int CountPostsForTag(string tag)
        {
            return _unitOfWork.PostRepository.CountPostsForTag(tag);
           
        }

        public IList<Post> GetPostsByTag(string tag)
        {
            return _unitOfWork.PostRepository.GetPostsByTag(tag);
            
        }

        public IList<Post> GetMostViewedPost(int size)
        {
            return _unitOfWork.PostRepository.GetMostViewedPost(size);
        }

        public IList<Post> GetHighestPosts(int size)
        {
            return _unitOfWork.PostRepository.GetHighestPosts(size);
        }

        public IList<Post> GetLatestPost()
        {
            return _unitOfWork.PostRepository.GetLatestPost();
        }
    }
}
