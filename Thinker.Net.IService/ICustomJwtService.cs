using Thinker.Net.Model.Dto.User;

namespace Thinker.Net.IService;

public interface ICustomJwtService
{
    Task<string> GetToken(UserRes userRes);
}
