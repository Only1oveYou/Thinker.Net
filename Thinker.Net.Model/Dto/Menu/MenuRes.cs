﻿namespace Thinker.Net.Model.Dto.Menu;

public class MenuRes
{
    [SugarColumn(IsTreeKey = true)] 
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Index { get; set; } = "";
    public string FilePath { get; set; } = "";
    public string ParentId { get; set; } = "";
    public string ParentName { get; set; } = "";
    public int Order { get; set; }
    public bool IsEnable { get; set; }
    public string Icon { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// 子级
    /// </summary>
    [SqlSugar.SugarColumn(IsIgnore = true)]
    public List<MenuRes> Children { get; set; } = new List<MenuRes>();
}