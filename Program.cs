using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace aws_s3_read_write_files
{
    class Program
    {
        private static AwsConfig _awsConfig;

        private const string downloadedFilePath = @"c:\temp\test-downloaded.txt";
        private const string filePath = @"c:\temp\test.txt";
        private const string keyName = @"test.txt";
        // Specify your bucket region (an example region is shown).
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.SAEast1;
        private static IAmazonS3 s3Client;        
        
        public static void Main()
        {
            LoadConfigFile();

            var awsCredentials = new BasicAWSCredentials(_awsConfig.Credential.AccessKey, _awsConfig.Credential.SecretKey);
            s3Client = new AmazonS3Client(awsCredentials, bucketRegion);
            
            UploadFileAsync().Wait();

            ReadObjectDataAsync().Wait();
        }

        private static void LoadConfigFile()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");
            
            var config = builder.Build();
            _awsConfig = config.GetSection("AWS").Get<AwsConfig>();
        }


        private static async Task UploadFileAsync()
        {
            try
            {
                var fileTransferUtility = new TransferUtility(s3Client);

                // Option 1. Upload a file. The file name is used as the object key name.
                await fileTransferUtility.UploadAsync(filePath, _awsConfig.S3.Bucket);
                Console.WriteLine("Upload 1 completed");
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }
        }

        private static async Task ReadObjectDataAsync()
        {
            try
            {
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = _awsConfig.S3.Bucket,
                    Key = keyName
                };
                using (GetObjectResponse response = await s3Client.GetObjectAsync(request))
                using (Stream responseStream = response.ResponseStream)
                using (Stream s = File.Create(downloadedFilePath))
                    responseStream.CopyTo(s);
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered ***. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }
        }
    }
}