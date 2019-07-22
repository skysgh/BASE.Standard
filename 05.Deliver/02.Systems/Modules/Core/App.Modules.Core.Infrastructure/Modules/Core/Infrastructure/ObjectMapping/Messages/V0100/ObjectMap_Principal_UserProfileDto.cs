// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Shared.Models.DTOs;
using App.Modules.Core.Shared.Models.Entities;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    /// <summary>
    ///     Create custom Maps for the Entity and its Dto.
    /// </summary>
    /// <seealso cref="MapUntenantedRecordStatedTimestampedNoIdBase{TEntity,TDto}" />
    public class ObjectMap_Principal_UserProfileDto
        : MapUntenantedRecordStatedTimestampedNoIdBase<Principal, UserProfileDto>
    {
        /// <summary>
        ///     Configures the map from entity to dto.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<Principal, UserProfileDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.FullName, opt => opt.MapFrom(s => s.FullName))
                .ForMember(t => t.DisplayName, opt => opt.MapFrom(s => s.DisplayName))
                ;
            base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        /// <summary>
        ///     Configures the map from dto to entity.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<UserProfileDto, Principal> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled, opt => opt.Ignore())
                .ForMember(t => t.DisplayName, opt => opt.MapFrom(s => s.DisplayName))
                .ForMember(t => t.FullName, opt => opt.MapFrom(s => s.FullName))
                .ForMember(t => t.EnabledBeginningUtcDateTime, opt => opt.Ignore())
                .ForMember(t => t.EnabledEndingUtcDateTime, opt => opt.Ignore())
                .ForMember(t => t.DataClassification, opt => opt.Ignore())
                .ForMember(t => t.DataClassificationFK, opt => opt.Ignore())
                .ForMember(t => t.Category, opt => opt.Ignore())
                .ForMember(t => t.CategoryFK, opt => opt.Ignore())
                ;
            base.ConfigureMapFromDtoToEntity(mappingExpression);
            // and...
            MapCollections(mappingExpression);
        }

        private void MapCollections(IMappingExpression<UserProfileDto, Principal> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Logins, opt => opt.Ignore())
                .ForMember(t => t.Roles, opt => opt.Ignore())
                .ForMember(t => t.TagAssignment, opt => opt.Ignore())
                .ForMember(t => t.Properties, opt => opt.Ignore())
                .ForMember(t => t.Claims, opt => opt.Ignore());
        }
    }
}