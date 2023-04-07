using Amazon;
using Amazon.S3;
using Buble.Models;
using Buble.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Buble.ViewModels
{
    public class UploadViewModel : ViewModelBase
    {
        private const string existingBucketName = "practicebucket-sahil";
        // Specify your bucket region (an example region is shown).
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USWest2;
        private static IAmazonS3 s3Client;

        Upload_AWS_S3_Model upload = new Upload_AWS_S3_Model();
        VideoRepository videoRepository = new VideoRepository();

        public UploadViewModel()
        {
            s3Client = new AmazonS3Client(bucketRegion);
        }

        public async void Upload_To_Cloud(
            string key_name,
            string filepath,
            string thumbnail_path)
        {
            //Check if video exists or not.
            videoRepository.AddVideoInformationToMongoDB(key_name, Thread.CurrentPrincipal.Identity.Name, thumbnail_path);
            upload.UploadFileAsync(s3Client, existingBucketName, $"{key_name}.mp4", filepath).Wait();
        }
    }
}
