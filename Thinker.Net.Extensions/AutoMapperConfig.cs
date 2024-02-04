namespace Thinker.Net.Extensions;

public  class AutoMapperConfig : Profile
{

    public AutoMapperConfig()
    {
        //角色
        //CreateMap<Role, RoleRes>();
        CreateMap<RoleAdd, Role>();
        CreateMap<RoleEdit, Role>();
        //用户
        CreateMap<Users, UserRes>();
        CreateMap<UserAdd, Users>();
        CreateMap<UserEdit, Users>();
        //菜单
        //CreateMap<Menu, MenuRes>();
        CreateMap<MenuAdd, Menu>();
        CreateMap<MenuEdit, Menu>();
    }
}