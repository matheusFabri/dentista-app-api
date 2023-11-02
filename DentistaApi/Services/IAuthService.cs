using DentistaApi.Models;

namespace DentistaApi.Services;

public interface IAuthService
{
    public Task<IReturn<string>> Register
                                    (User model, string role);
    public Task<IReturn<string>> Login(User model);

    public interface IReturn<T>
    {
        public EReturnStatus Status { get; }
        public T Result { get; }
    }
}
