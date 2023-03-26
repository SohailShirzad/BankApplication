using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Options;
using myBankApplication.Helpers;

namespace myBankApplication.Services
{
    public class PhotoService : IPhotoService

    {
        private readonly Cloudinary _cloudinary;
        public PhotoService(IOptions<CloudinarySettings> config)
        {
            var account = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret

                );
            _cloudinary = new Cloudinary(account);

        }
        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadImageResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(450).Width(450).Crop("file")
                };
                uploadImageResult  = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadImageResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deleteParams);

            return result;
        }
    }
}
