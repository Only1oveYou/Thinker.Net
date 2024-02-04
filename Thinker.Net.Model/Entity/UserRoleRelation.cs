namespace Thinker.Net.Model.Entity;

/// <summary>
/// 用户角色关系
/// </summary>
public class UserRoleRelation : Base.Base
{
    /// <summary>
    /// 用户主键
    /// </summary>
    [SugarColumn(IsNullable = false)]
    public string UserId { get; set; }
    /// <summary>
    /// 角色主键
    /// </summary>
    [SugarColumn(IsNullable = false)]
    public string RoleId { get; set; }
}

