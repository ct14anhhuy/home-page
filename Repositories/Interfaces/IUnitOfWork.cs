using Data;

namespace Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<HeaderCategory> HeaderCategoryRepository { get; }
        IGenericRepository<HeaderDetail> HeaderDetailRepository { get; }
        IGenericRepository<UserLogin> UserLoginRepository { get; }
        IGenericRepository<Role> RoleRepository { get; }
        IGenericRepository<Document> DocumentRepository { get; }
        IGenericRepository<Benefit> BenefitRepository { get; }
        IGenericRepository<Candidate> CandidateRepository { get; }
        IGenericRepository<JobSkill> JobSkillRepository { get; }
        IGenericRepository<Recruitment> RecruitmentRepository { get; }
        IGenericRepository<Image> ImageRepository { get; }

        void Commit();
    }
}