using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public class CommentService : ICommentService
    {
        public IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Comment comment)
        {
            _unitOfWork.CommentRepository.Add(comment);
            _unitOfWork.Commit();
        }

        public void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            _unitOfWork.CommentRepository.AddComment(postId, commentName, commentEmail, commentTitle, commentBody);
            _unitOfWork.Commit();
        }

        public void Delete(Comment comment)
        {
            _unitOfWork.CommentRepository.Delete(comment);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _unitOfWork.CommentRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public Comment Find(int id)
        {
            return _unitOfWork.CommentRepository.Find(id);
        }

        public IList<Comment> GetAll()
        {
            return _unitOfWork.CommentRepository.GetAll();
        }

        public IList<Comment> GetCommentsForPost(int postId)
        {
            return _unitOfWork.CommentRepository.GetCommentsForPost(postId);
        }

        public IList<Comment> GetCommentsForPost(Post post)
        {
            return _unitOfWork.CommentRepository.GetCommentsForPost(post.Id);
        }

        public void Update(Comment comment)
        {
            _unitOfWork.CommentRepository.Update(comment);
            _unitOfWork.Commit();
        }
    }
}
