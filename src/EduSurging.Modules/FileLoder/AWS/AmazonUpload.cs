using System;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;

namespace FileLoder.AWS
{
    public class AmazonUpload
    {
        private static readonly string ACCESS_KEY = "I6TSA88OA4KP5Z8EH5V6";
        private static readonly string SECRET_KEY = "J3Eu9pWn87xp9A67T2LglbxjemfoP5OCCivR2nXo";
        private static AmazonS3Client _client;

        private static AmazonS3Client GetClient()
        {
            if (_client == null)
            {
                AmazonS3Config clientConfig = new AmazonS3Config()
                {
                    ServiceURL = "http://eos-beijing-1.cmecloud.cn",
                    ForcePathStyle = true,
                    SignatureVersion = "2",
                    SignatureMethod = SigningAlgorithm.HmacSHA1
                };
                _client = new AmazonS3Client(ACCESS_KEY, SECRET_KEY, clientConfig);
            }

            return _client;
            //ListBucketsResponse response = client.ListBuckets();
            //response.Buckets.ForEach(item =>
            //{
            //    Console.WriteLine("{0}\t{1}", item.BucketName, item.CreationDate);
            //});
        }

        public static Task<ListBucketsResponse> GetBuckets()
        {
            try
            {
                return GetClient().ListBucketsAsync(new ListBucketsRequest());
            }
            catch (AmazonClientException e)
            {
                return null;
            }
        }

        public static PutBucketResponse CreateBucket(string BucketName)
        {
            var Request = new PutBucketRequest
            {
                BucketName = BucketName,
                CannedACL = S3CannedACL.Private
            };
            try
            {
                return GetClient().PutBucket(Request);
            }
            catch (AmazonClientException e)
            {
                return null;
            }
        }

        public static Task<DeleteBucketResponse> DeleteBucket(string BucketName)
        {
            try
            {
                var Request = new DeleteBucketRequest
                {
                    BucketName = BucketName
                };
                return GetClient().DeleteBucketAsync(Request);
            }
            catch (AmazonClientException e)
            {
                return null;
            }
        }

        public static Task<GetBucketLocationResponse> GetLocation(string BucketName)
        {
            try
            {
                var request = new GetBucketLocationRequest
                {
                    BucketName = BucketName
                };
                return GetClient().GetBucketLocationAsync(request);
            }
            catch (AmazonClientException e)
            {
                return null;
            }
        }
        public static Task<PutObjectResponse> UpLoadFile(string BucketName, string Key, string FilePath)
        {
            try
            {
                var Object = new PutObjectRequest
                {
                    BucketName = BucketName,
                    Key = Key,
                    CannedACL = S3CannedACL.PublicRead,
                    FilePath = FilePath
                };
                return GetClient().PutObjectAsync(Object);
            }
            catch (AmazonClientException e)
            {
                return null;
            }
        }
        public static Task<GetObjectResponse> Down(string BucketName, string Key)
        {
            try
            {
                var request = new GetObjectRequest
                {
                    BucketName = BucketName,
                    Key = Key
                };
                return GetClient().GetObjectAsync(request);
            }
            catch (AmazonClientException e)
            {
                return null;
            }
            //using (var Response = GetClient().GetObject(request))
            //{
            //    using (var reader = new StreamReader(Response.ResponseStream))
            //    {
            //        string contents = reader.ReadToEnd();
            //        Console.WriteLine(string.Format("Object-{0}", Response.Key));
            //        Console.WriteLine(string.Format("Version-{0}", Response.VersionId));
            //        Console.WriteLine(string.Format("Contents-{0}", contents));
            //    }
            //}
        }
        public Task<PutACLResponse> Acl(string BucketName, string Key)
        {
            try
            {
                return GetClient().PutACLAsync(new PutACLRequest
                {
                    BucketName = BucketName,
                    Key = Key,
                    CannedACL = S3CannedACL.PublicRead
                });
            }
            catch (AmazonClientException e)
            {
                return null;
            }
        }

        public static Task<ListObjectsResponse> GetObjects(string BucketName)
        {
            try
            {
                return GetClient().ListObjectsAsync(new ListObjectsRequest
                {
                    BucketName = BucketName
                });
            }
            catch (AmazonClientException e)
            {
                return null;
            }
        }
        public static Task<DeleteObjectResponse> DeleteObject(string BucketName, string Key)
        {
            try
            {
                return GetClient().DeleteObjectAsync(new DeleteObjectRequest
                {
                    BucketName = BucketName,
                    Key = Key
                });
            }
            catch (AmazonClientException e)
            {
                return null;
            }
        }
        public static void SetMuli()
        {
            try
            {
                PutBucketVersioningRequest myrequest = new PutBucketVersioningRequest
                {
                    VersioningConfig = new S3BucketVersioningConfig
                    {
                        Status = "Enable"//Suspended
                    }
                };
                GetClient().PutBucketVersioning(myrequest);
            }
            catch (AmazonClientException e)
            {

            }
        }

        public static string GetUrlUpload(string BucketName, string Key)
        {
            try
            {
                GetPreSignedUrlRequest request = new GetPreSignedUrlRequest
                {
                    BucketName = BucketName,
                    Key = Key,
                    Expires = DateTime.Now.AddDays(1),
                    Protocol = Protocol.HTTP
                };
                string path = GetClient().GetPreSignedURL(request);
                //byte[] data = UTF8Encoding.UTF8.GetBytes("Sample text.");
                //HttpWebRequest httpRequest = WebRequest.Create(path) as HttpWebRequest;
                //httpRequest.Method = "PUT";
                //httpRequest.ContentLength = data.Length;
                //Stream requestStream = httpRequest.GetRequestStream();
                //requestStream.Write(data, 0, data.Length);
                //requestStream.Close();
                //HttpWebResponse response = httpRequest.GetResponse() as HttpWebResponse;
                return path;
            }
            catch (AmazonClientException e)
            {
                return null;
            }
        }
    }
}
