using DTO;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IRecruitmentService
    {
        IEnumerable<RecruitmentDTO> GetAll();

        RecruitmentDTO GetDetailByID(int id);

        IEnumerable<RecruitmentDTO> GetActivedRecruitment();

        RecruitmentDTO Add(RecruitmentDTO recruitmentDTO);

        void Edit(RecruitmentDTO recruitmentDTO);

        RecruitmentDTO Delete(int id);
    }
}