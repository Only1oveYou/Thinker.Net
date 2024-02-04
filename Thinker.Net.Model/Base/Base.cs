namespace Thinker.Net.Model.Base;

public class Base
{
    /// <summary>
    /// 主键
    /// </summary>
    [SugarColumn(IsPrimaryKey = true)]
    public string Id { get; set; } = "";
}
