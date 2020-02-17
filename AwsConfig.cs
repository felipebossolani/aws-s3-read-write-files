using System;
using System.Collections.Generic;
using System.Text;

namespace aws_s3_read_write_files
{
    public class AwsConfig
    {
        public Credential Credential { get; set; }
        public S3 S3 { get; set; }
    }

    public class Credential
    {
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
    }

    public class S3
    {
        public string Bucket { get; set; }
    }
}
