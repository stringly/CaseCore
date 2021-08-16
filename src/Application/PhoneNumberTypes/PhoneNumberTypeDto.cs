using CaseCore.Application.Common.Mappings;
using CaseCore.Domain.Types;

namespace CaseCore.Application.PhoneNumberTypes
{
    /// <summary>
    /// Data Transfer class used for the <see cref="PhoneNumberType"/> entity.
    /// </summary>
    public class PhoneNumberTypeDto : IMapFrom<PhoneNumberType>
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
        /// Abbreviation for the AddressType
        /// </summary>
        public string Abbreviation { get; set; }
        /// <summary>
        /// Creates a mapping between a <see cref="PhoneNumberType"/> and <see cref="PhoneNumberTypeDto"/>
        /// </summary>
        /// <param name="profile">A <see cref="MappingProfile"/></param>
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<PhoneNumberType, PhoneNumberTypeDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Abbreviation, opt => opt.MapFrom(s => s.Abbreviation));
        }
    }
}
