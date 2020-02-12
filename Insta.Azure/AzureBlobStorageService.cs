using System;
using System.IO;
using System.Threading.Tasks;

using Insta.Azure.Entities;

using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Insta.Azure
{
    public sealed class AzureBlobStorageService : IAzureBlobStorageService
    {
        private readonly Lazy<Task<CloudBlobContainer>> blobContainer;

        private readonly string connectionString;

        public AzureBlobStorageService(IOptions<AzureSettings> options)
        {
            this.connectionString = options.Value.ConnectionString;
            this.blobContainer = new Lazy<Task<CloudBlobContainer>>(() => this.GetBlobContainer(options.Value.ContainerName));
        }

        public async Task<FileUploadResult> Upload(string cloudPath, string cloudFileName, Stream stream)
        {
            if (!stream.CanRead)
            {
                throw new ArgumentException("The stream is not readable.");
            }

            var container = await this.blobContainer.Value.ConfigureAwait(false);

            var blockBlob = container
                .GetBlockBlobReference(Path.Combine(cloudPath, cloudFileName));

            await blockBlob.UploadFromStreamAsync(
                stream,
                null,
                new BlobRequestOptions { StoreBlobContentMD5 = true },
                null).ConfigureAwait(false);

            return new FileUploadResult
            {
                Uri = blockBlob.Uri,
                ContentMD5 = blockBlob.Properties.ContentMD5
            };
        }

        public async Task<FileDeleteResult> Delete(string blobName)
        {
            if (string.IsNullOrEmpty(blobName))
            {
                return new FileDeleteResult { FileName = blobName, IsDeleted = false };
            }

            var container = await this.blobContainer.Value.ConfigureAwait(false);
            var blockBlob = container.GetBlockBlobReference(blobName);
           
            var isDeleted = await blockBlob
                                .DeleteIfExistsAsync()
                                .ConfigureAwait(false);

            return new FileDeleteResult { FileName = blobName, IsDeleted = isDeleted };
        }

        private async Task<CloudBlobContainer> GetBlobContainer(string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(this.connectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);

            await container
                .CreateIfNotExistsAsync()
                .ConfigureAwait(false);

            return container;
        }
    }
}