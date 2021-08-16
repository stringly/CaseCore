using CaseCore.Application.Common.Mappings;
using CaseCore.Domain.Types;

namespace CaseCore.Application.CaseStatusTypes
{
    /// <summary>
    /// Data Transfer class used for the <see cref="CaseStatusType"/> entity.
    /// </summary>
    public class CaseStatusTypeDto : IMapFrom<CaseStatusType>
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
        /// Creates a mapping between a <see cref="CaseStatusType"/> and a <see cref="CaseStatusTypeDto"/>
        /// </summary>
        /// <param name="profile">A <see cref="MappingProfile"/></param>
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<CaseStatusType, CaseStatusTypeDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
        }
    }
}
