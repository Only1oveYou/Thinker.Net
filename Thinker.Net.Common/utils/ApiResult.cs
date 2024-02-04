namespace Thinker.Net.Common.utils;

/// <summary>
/// 统一返回结果
/// </summary>
public class ApiResult
{
    public bool IsSuccess { get; set; }
    public object Result { get; set; }
    public string Msg { get; set; }
}
