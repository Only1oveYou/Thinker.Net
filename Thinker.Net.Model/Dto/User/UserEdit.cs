﻿namespace Thinker.Net.Model.Dto.User;

public class UserEdit
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string NickName { get; set; }
    public string Password { get; set; }
    //public int UserType { get; set; }
    public bool IsEnable { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
}
