using Data;
using System;

namespace Repositories
{
    public class UnitOfWork : IDisposable
    {
        public GenericRepository<HeaderCategory> HeaderCategoryRepository { get; private set; }
        public GenericRepository<HeaderDetail> HeaderDetailRepository { get; private set; }
        public GenericRepository<UserLogin> UserLoginRepository { get; private set; }
        public GenericRepository<Role> RoleRepository { get; private set; }
        public GenericRepository<Document> DocumentRepository { get; private set; }
        public GenericRepository<Benefit> BenefitRepository { get; private set; }
        public GenericRepository<Candidate> CandidateRepository { get; private set; }
        public GenericRepository<JobSkill> JobSkillRepository { get; private set; }
        public GenericRepository<Recruitment> RecruitmentRepository { get; private set; }

        private HomePageVSTEntities _dbContext;
        private bool disposed;

        public UnitOfWork()
        {
            _dbContext = new HomePageVSTEntities();

            HeaderCategoryRepository = new GenericRepository<HeaderCategory>(_dbContext);
            HeaderDetailRepository = new GenericRepository<HeaderDetail>(_dbContext);
            UserLoginRepository = new GenericRepository<UserLogin>(_dbContext);
            RoleRepository = new GenericRepository<Role>(_dbContext);
            DocumentRepository = new GenericRepository<Document>(_dbContext);
            BenefitRepository = new GenericRepository<Benefit>(_dbContext);
            CandidateRepository = new GenericRepository<Candidate>(_dbContext);
            JobSkillRepository = new GenericRepository<JobSkill>(_dbContext);
            RecruitmentRepository = new GenericRepository<Recruitment>(_dbContext);
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        ~UnitOfWork()
        {
            Dispose();
        }
    }
}