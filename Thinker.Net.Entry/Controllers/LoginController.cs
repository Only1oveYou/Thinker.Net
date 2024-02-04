using Thinker.Net.Model.Dto.Login;

namespace Thinker.Net.Entry.Controllers;

[Route("api/login")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IBaseService<Users, UserRes> _baseService;
    private readonly ICustomJwtService _jwtService;

    public LoginController(IBaseService<Users, UserRes> baseService, ICustomJwtService jwtService)
    {
        ISqlSugarClient _db = App.GetService<ISqlSugarClient>(false);
        _baseService = baseService;
        _jwtService = jwtService;
    }


    [HttpPost]
    [Route("token")]
    public async Task<ApiResult> GetToken([FromBody] LoginReq req)
    {
        var user = await _baseService.SelectOneAsync(o => o.Name == req.UserName && o.Password == req.PassWord);
        var res = await _jwtService.GetToken(user);
        return ApiResultHelper.Success(res);
    }

    [HttpGet]
    [Route("user")]
    public async Task<ApiResult> GetUser()
    {
        var users = await _baseService.SelectAllAsync();
        return ApiResultHelper.Success(users);
    }
}
