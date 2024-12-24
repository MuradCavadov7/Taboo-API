namespace Taboo.ExternalServices.Abstracts
{
    public interface ICacheService
    {
        Task<T?> GetAsync<T>(string key);
        Task SetAsync<T>(string key,T data,int minute);
        Task RemoveAsync<T>(string key);
    }
}
