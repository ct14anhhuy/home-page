using Data;
using System;

namespace Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
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

        void Commit();
        void Dispose(bool disposing);
    }
}