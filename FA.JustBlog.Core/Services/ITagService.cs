namespace FA.JustBlog.Core
{
    public interface ITagService
    {
        IList<Tag> GetAll();

        Tag Find(int id);

        void Add(Tag tag);

        void Update(Tag tag);

        void Delete(Tag tag);

        void Delete(int id);

        Tag GetTagByUrlSlug(string urlSlug);

        IList<Tag> GetTopTags();
    }
}
