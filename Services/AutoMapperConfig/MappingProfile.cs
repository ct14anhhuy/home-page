using Data;
using DTO;

namespace Services.AutoMapperConfig
{
    using AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Benefit, BenefitDTO>().ReverseMap();
            CreateMap<Candidate, CandidateDTO>().ReverseMap();
            CreateMap<Document, DocumentDTO>().ReverseMap();
            CreateMap<HeaderCategory, HeaderCategoryDTO>().ReverseMap();
            CreateMap<HeaderDetail, HeaderDetailDTO>().ReverseMap();
            CreateMap<Image, ImageDTO>().ReverseMap();
            CreateMap<JobSkill, JobSkillDTO>().ReverseMap();
            CreateMap<Recruitment, RecruitmentDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<UserLogin, UserLoginDTO>().ReverseMap();
            CreateMap<CoporateCitizenCategory, CoporateCitizenCategoryDTO>().ReverseMap();
            CreateMap<CoporateCitizenContent, CoporateCitizenContentDTO>().ReverseMap();
        }
    }
}