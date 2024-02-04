namespace Thinker.Net.Model.Entity;

/// <summary>
/// 菜单角色关系
/// </summary>
public class MenuRoleRelation : Base.Base
{
    /// <summary>
    /// 菜单主键
    /// </summary>
    [SugarColumn(IsNullable = false)]
    public string MenuId { get; set; }
    /// <summary>
    /// 角色主键
    /// </summary>
    [SugarColumn(IsNullable = false)]
    public string RoleId { get; set; }
}

