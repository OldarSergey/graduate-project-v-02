using GraduateProjectAPI.DTO.KnowledgeBase;

namespace GraduateProjectAPI.Service.Interface
{
    public interface IKnowledgeBase
    {
        public List<GroupDto> GettingTreeGroups ();
        public List<ArticleDto> GettingArticlesGroup(int idGroup);
        public List<PaperDto> GetContentPaper(int KeyItems);
    }
}
