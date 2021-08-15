using CaseCore.Application.Common.Mappings;
using CaseCore.Domain.Types;

namespace CaseCore.Application.CaseAssignmentTypes
{
    /// <summary>
    /// Data Transfer class used for the <see cref="CaseAssignmentType"/> entity.
    /// </summary>
    public class CaseAssignmentTypeDto : IMapFrom<CaseAssignmentType>
    {
        /// <summary>
        /// Integer Id for the AddressType
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of the AddressType
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Creates a mapping between a <see cref="CaseAssignmentType"/> and a <see cref="CaseAssignmentTypeDto"/>
        /// </summary>
        /// <param name="profile">A <see cref="MappingProfile"/></param>
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<CaseAssignmentType, CaseAssignmentTypeDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
        }
    }
}
