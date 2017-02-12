using VedaYOU.Core.Interfaces;
using VedaYOU.Entities;

namespace VedaYOU.Core.Services
{
    public class UmbracoMediaService : IMediaService
    {
        private readonly global::Umbraco.Core.Services.IMediaService mediaService;

        public UmbracoMediaService(global::Umbraco.Core.Services.IMediaService mediaService)
        {
            this.mediaService = mediaService;
        }

        public string GetMediaPathById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var mediaId = int.Parse(id);
            var media = mediaService.GetById(mediaId);

            var mediaPath = string.Empty;

            if (media.Properties.Contains((GlobalConstants.UmbracoFile)))
            {
                mediaPath = media.Properties[GlobalConstants.UmbracoFile].Value as string;
            }

            return mediaPath;
        }
    }
}