using AutoMapper;
using SpeiderappAPI.DataTransferObjects;
using SpeiderappAPI.Models;

namespace SpeiderappAPI.Profiles
{
    /**
     * <summary>An AutoMapper-profile for configuring how the AutoMapper should convert between
     * Data Transfer Objects (DTOs) and the data models</summary>
     */
    public class RequirementsProfile : Profile
    {
        public RequirementsProfile()
        {
            // User
            CreateMap<User, UserDto>();

            // Requirement
            CreateMap<Requirement, RequirementDto>();
            CreateMap<Requirement, UserRequirementDto>();

            // Resource
            CreateMap<Resource, ResourceDto>();
            CreateMap<Resource, RequirementResourceDto>();

            // RequirementPrerequisite
            CreateMap<RequirementPrerequisite, RequirementRequiredByDto>()
                .ForMember(dest => dest.Requirer,
                    opt => opt.MapFrom(src => src.RequirerID));
            CreateMap<RequirementPrerequisite, RequirementRequiringDto>()
                .ForMember(dest => dest.Requiree,
                    opt => opt.MapFrom(src => src.RequireeID));

            // Badge
            CreateMap<Badge, BadgeDto>();

            // Tag
            CreateMap<TaggedWith, BadgeTagDto>()
                .ForMember(dest => dest.TagID, opt => opt.MapFrom(src => src.TagID))
                .ForMember(dest => dest.CategoryID, opt => opt.MapFrom(src => src.Tag.CategoryID))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Tag.Value))
                .ForMember(dest => dest.CategoryTitle, opt => opt.MapFrom(src => src.Tag.Category.Title));
        }
    }
}
