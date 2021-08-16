using CaseCore.Application.Common.Mappings;
using CaseCore.Domain.Types;

namespace CaseCore.Application.PersonTypes
{
    /// <summary>
    /// Data Transfer class used for the <see cref="PersonType"/> entity.
    /// </summary>
    public class PersonTypeDto : IMapFrom<PersonType>
    {
        /// <summary>
        /// Integer Id for the PersonType
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of the PersonType
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Abbreviaton of the PersonType
        /// </summary>
        public string Abbreviation { get;set;}
        /// <summary>
        /// Creates a mapping between a <see cref="PersonType"/> and a <see cref="PersonTypeDto"/>
        /// </summary>
        /// <param name="profile">A <see cref="MappingProfile"/></param>
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<PersonType, PersonTypeDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Abbreviation, opt => opt.MapFrom(s => s.Abbreviation));
        }
    }
}
