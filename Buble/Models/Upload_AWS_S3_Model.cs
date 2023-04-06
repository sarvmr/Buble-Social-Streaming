using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buble.Models
{
    public class Upload_AWS_S3_Model
    {
        public async Task<bool> UploadFileAsync(
            IAmazonS3 client,
            string bucketName,
            string objectName,
            string filePath)
        {
            RegionEndpoint region_end_point = RegionEndpoint.USWest2;
            try
            {
                var request = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = objectName,
                    FilePath = filePath
                };

                var response = await client.PutObjectAsync(request);
                if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine($"Successfully uploaded {objectName} to {bucketName}.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Could not upload {objectName} to {bucketName}.");
                    return false;
                }
            }
            catch (AmazonS3Exception)
            {
                Console.WriteLine("Could not connect AWS S3");
                return false;

            }
            catch (Exception)
            {
                Console.WriteLine("File Not Found");
                return false;
            }
        }
    }
}
