namespace DevFreela.Infrastructure.CloudServices.Interfaces
{
    public interface IFileStorageService
    {
        void Updload(byte[] bytes, string fileName);
    }
}
