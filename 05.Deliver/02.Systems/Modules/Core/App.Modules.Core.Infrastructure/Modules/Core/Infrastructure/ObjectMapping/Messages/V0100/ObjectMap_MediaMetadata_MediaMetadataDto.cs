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
    public class ObjectMap_MediaMetadata_MediaMetadataDto
        : MapUntenantedRecordStatedTimestampedNoIdBase<MediaMetadata, MediaMetadataDto>
    {
        /// <summary>
        ///     Configures the map from entity to dto.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<MediaMetadata, MediaMetadataDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.DataClassification, opt =>
                {
                    opt.ExplicitExpansion();
                    opt.MapFrom(s => s.DataClassification);
                })
                .ForMember(t => t.ContentSize, opt => opt.MapFrom(s => s.ContentSize))
                .ForMember(t => t.ContentHash, opt => opt.MapFrom(s => s.ContentHash))
                .ForMember(t => t.LocalName, opt => opt.MapFrom(s => s.LocalName))
                .ForMember(t => t.LatestScanDateTimeUtc, opt => opt.MapFrom(s => s.LatestScanDateTimeUtc))
                .ForMember(t => t.LatestScanMalwareDetetected, opt => opt.MapFrom(s => s.LatestScanMalwareDetetected))
                .ForMember(t => t.LatestScanResults, opt => opt.MapFrom(s => s.LatestScanResults))
                .ForMember(t => t.MimeType, opt => opt.MapFrom(s => s.MimeType))
                .ForMember(t => t.SourceFileName, opt => opt.MapFrom(s => s.SourceFileName))
                .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                .ForMember(t => t.UploadedDateTimeUtc, opt => opt.MapFrom(s => s.UploadedDateTimeUtc));

            base.ConfigureMapFromEntityToDto(mappingExpression);
            // Use an Enum as DataClassification is shared across Bounded DbContexts
            // Results of scanning, whenever done:
        }

        /// <summary>
        ///     Configures the map from dto to entity.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<MediaMetadataDto, MediaMetadata> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.DataClassification, opt =>
                {
                    opt.ExplicitExpansion();
                    opt.MapFrom(s => s.DataClassification);
                })
                .ForMember(t => t.ContentSize, opt => opt.MapFrom(s => s.ContentSize))
                .ForMember(t => t.ContentHash, opt => opt.MapFrom(s => s.ContentHash))
                .ForMember(t => t.LocalName, opt => opt.MapFrom(s => s.LocalName))
                .ForMember(t => t.MimeType, opt => opt.MapFrom(s => s.MimeType))
                .ForMember(t => t.SourceFileName, opt => opt.MapFrom(s => s.SourceFileName))
                .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                .ForMember(t => t.UploadedDateTimeUtc, opt => opt.MapFrom(s => s.UploadedDateTimeUtc))
                .ForMember(t => t.DataClassificationFK, opt => opt.Ignore())
                ;
            // And ...
            MapLatest(mappingExpression);

            base.ConfigureMapFromDtoToEntity(mappingExpression);
            // Use an Enum as DataClassification is shared across Bounded DbContexts
            // Results of scanning, whenever done:
        }

        private void MapLatest(IMappingExpression<MediaMetadataDto, MediaMetadata> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.LatestScanDateTimeUtc, opt => opt.MapFrom(s => s.LatestScanDateTimeUtc))
                .ForMember(t => t.LatestScanMalwareDetetected, opt => opt.MapFrom(s => s.LatestScanMalwareDetetected))
                .ForMember(t => t.LatestScanResults, opt => opt.MapFrom(s => s.LatestScanResults))
                ;
            base.ConfigureMapFromDtoToEntity(mappingExpression);
        }
    }
}