using CaseCore.Application.Common.Mappings;
using CaseCore.Domain.Types;

namespace CaseCore.Application.AddressTypes
{
    /// <summary>
    /// Data Transfer class used for the <see cref="AddressType"/> entity.
    /// </summary>
    public class AddressTypeDto : IMapFrom<AddressType>
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
        /// Creates a mapping between a <see cref="AddressType"/> and <see cref="AddressTypeDto"/>
        /// </summary>
        /// <param name="profile">A <see cref="MappingProfile"/></param>
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<AddressType, AddressTypeDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Abbreviation, opt => opt.MapFrom(s => s.Abbreviation));
        }
    }
}
