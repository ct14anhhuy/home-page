using Data;
using Repositories.Interfaces;
using System;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IGenericRepository<HeaderCategory> HeaderCategoryRepository { get; private set; }
        public IGenericRepository<HeaderDetail> HeaderDetailRepository { get; private set; }
        public IGenericRepository<UserLogin> UserLoginRepository { get; private set; }
        public IGenericRepository<Role> RoleRepository { get; private set; }
        public IGenericRepository<Document> DocumentRepository { get; private set; }
        public IGenericRepository<Benefit> BenefitRepository { get; private set; }
        public IGenericRepository<Candidate> CandidateRepository { get; private set; }
        public IGenericRepository<JobSkill> JobSkillRepository { get; private set; }
        public IGenericRepository<Recruitment> RecruitmentRepository { get; private set; }
        public IGenericRepository<Image> ImageRepository { get; private set; }

        private HomePageVSTEntities _dbContext;
        private bool disposed;

        public UnitOfWork(HomePageVSTEntities dbContext)
        {
            _dbContext = dbContext;

            HeaderCategoryRepository = new GenericRepository<HeaderCategory>(_dbContext);
            HeaderDetailRepository = new GenericRepository<HeaderDetail>(_dbContext);
            UserLoginRepository = new GenericRepository<UserLogin>(_dbContext);
            RoleRepository = new GenericRepository<Role>(_dbContext);
            DocumentRepository = new GenericRepository<Document>(_dbContext);
            BenefitRepository = new GenericRepository<Benefit>(_dbContext);
            CandidateRepository = new GenericRepository<Candidate>(_dbContext);
            JobSkillRepository = new GenericRepository<JobSkill>(_dbContext);
            RecruitmentRepository = new GenericRepository<Recruitment>(_dbContext);
            ImageRepository = new GenericRepository<Image>(_dbContext);
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

        protected virtual void Dispose(bool disposing)
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