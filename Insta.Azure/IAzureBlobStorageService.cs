using System.IO;
using System.Threading.Tasks;

using Insta.Azure.Entities;

namespace Insta.Azure
{
    public interface IAzureBlobStorageService
    {
        Task<FileUploadResult> Upload(string cloudPath, string cloudFileName, Stream stream);

        Task<FileDeleteResult> Delete(string blobName);
    }
}