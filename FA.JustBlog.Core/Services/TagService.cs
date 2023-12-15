using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public class TagService : ITagService
    {
        public IUnitOfWork _unitOfWork;
        public TagService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public Tag Find(int id)
        {
            return _unitOfWork.TagRepository.Find(id);
        }

        public void Add(Tag tag)
        {
            _unitOfWork.TagRepository.Add(tag);
            _unitOfWork.Commit();
        }

        public void Update(Tag tag)
        {
            _unitOfWork.TagRepository.Update(tag);
            _unitOfWork.Commit();
        }

        public void Delete(Tag tag)
        {
            _unitOfWork.TagRepository.Delete(tag);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _unitOfWork.TagRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public IList<Tag> GetAll()
        {
            return _unitOfWork.TagRepository.GetAll();
        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return _unitOfWork.TagRepository.GetTagByUrlSlug(urlSlug);
        }
    }
}
