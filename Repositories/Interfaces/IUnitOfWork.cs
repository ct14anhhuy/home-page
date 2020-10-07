using Data;

namespace Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<HeaderCategory> HeaderCategoryRepository { get; }
        IGenericRepository<HeaderDetail> HeaderDetailRepository { get; }
        IGenericRepository<UserLogin> UserLoginRepository { get; }
        IGenericRepository<Document> DocumentRepository { get; }
        IGenericRepository<Recruitment> RecruitmentRepository { get; }
        IGenericRepository<Image> ImageRepository { get; }
        IGenericRepository<CoporateCitizenCategory> CoporateCitizenCategoryRepository { get; }
        IGenericRepository<CoporateCitizenContent> CoporateCitizenContentRepository { get; }

        void Commit();
    }
}