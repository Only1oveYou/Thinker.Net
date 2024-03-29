﻿namespace Thinker.Net.Model.Dto.Menu;

public class MenuEdit
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Index { get; set; } = "";
    public string FilePath { get; set; } = "";
    public string ParentId { get; set; } = "";
    public int Order { get; set; } 
    public bool IsEnable { get; set; }
    public string Icon { get; set; } = "";
    public string Description { get; set; } = "";
}
