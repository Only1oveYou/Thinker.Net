namespace Thinker.Net.Entry.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class GenerateController(ISqlSugarClient db) : ControllerBase
{
    /// <summary>
    /// Initializes the data information if the settings information is enable. 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<string> CodeFirst()
    {
        
        var sugarOption = App.GetOptions<SqlsugarOption>();
        var str = sugarOption.ConnectionString;
        if (!sugarOption.Enable)
        {
            return "Initializing the database settings is not enable, please check the ORM settings information";
        }

        // 1、Create the database if it does not exist.
        db.DbMaintenance.CreateDatabase();
        var tblist = db.DbMaintenance.GetTableInfoList();
        if (tblist != null && tblist.Count > 0)
        {
            tblist.ForEach(t => { db.DbMaintenance.DropTable(t.Name); });
        }

        // 2、生成表
        string nspace = "Zhaoxi.Admin.Model.Entity";
        Type[] ass = Assembly.LoadFrom(AppContext.BaseDirectory + "Zhaoxi.Admin.Model.dll").GetTypes()
            .Where(p => p.Namespace == nspace).ToArray();
        // SetStringDefaultLength 为所有字符串类型的属性指定一个默认长度（默认是100，这里改为200，Model里会覆盖这里）
        db.CodeFirst.SetStringDefaultLength(200).InitTables(ass);
        // 3、添加测试数据
        //初始化炒鸡管理员和菜单
        //初始化炒鸡管理员和菜单
        Users user = new Users()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "admin",
            NickName = "炒鸡管理员",
            Password = "123456",
            UserType = 0,
            IsEnable = true,
            Description = "数据库初始化时默认添加的炒鸡管理员",
            CreateDate = DateTime.Now,
            CreateUserId = "",
        };
        string userId = (await db.Insertable(user).ExecuteReturnEntityAsync()).Id;
        var m1 = new Menu()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "菜单管理",
            Index = "/menu",
            FilePath = "menu.vue",
            ParentId = "",
            Order = 1,
            IsEnable = true,
            Icon = "folder",
            Description = "数据库初始化时默认添加的默认菜单",
            CreateDate = DateTime.Now,
            CreateUserId = userId
        };
        string mid1 = (await db.Insertable(m1).ExecuteReturnEntityAsync()).Id;
        var m11 = new Menu()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "菜单列表",
            Index = "/menu",
            FilePath = "menu.vue",
            ParentId = mid1,
            Order = 1,
            IsEnable = true,
            Icon = "notebook",
            Description = "数据库初始化时默认添加的默认菜单",
            CreateDate = DateTime.Now,
            CreateUserId = userId
        };
        await db.Insertable(m11).ExecuteReturnEntityAsync();

        var m2 = new Menu()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "角色管理",
            Index = "/role",
            FilePath = "role.vue",
            ParentId = "",
            Order = 1,
            IsEnable = true,
            Icon = "folder",
            Description = "数据库初始化时默认添加的默认菜单",
            CreateDate = DateTime.Now,
            CreateUserId = userId
        };
        string mid2 = (await db.Insertable(m2).ExecuteReturnEntityAsync()).Id;
        var m22 = new Menu()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "角色列表",
            Index = "/role",
            FilePath = "role.vue",
            ParentId = mid2,
            Order = 1,
            IsEnable = true,
            Icon = "notebook",
            Description = "数据库初始化时默认添加的默认菜单",
            CreateDate = DateTime.Now,
            CreateUserId = userId
        };
        await db.Insertable(m22).ExecuteReturnEntityAsync();

        var m3 = new Menu()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "用户管理",
            Index = "/user",
            FilePath = "user.vue",
            ParentId = "",
            Order = 1,
            IsEnable = true,
            Icon = "folder",
            Description = "数据库初始化时默认添加的默认菜单",
            CreateDate = DateTime.Now,
            CreateUserId = userId
        };
        string mid3 = (await db.Insertable(m3).ExecuteReturnEntityAsync()).Id;
        var m33 = new Menu()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "用户列表",
            Index = "/user",
            FilePath = "user.vue",
            ParentId = mid3,
            Order = 1,
            IsEnable = true,
            Icon = "notebook",
            Description = "数据库初始化时默认添加的默认菜单",
            CreateDate = DateTime.Now,
            CreateUserId = userId
        };
        await db.Insertable(m33).ExecuteCommandIdentityIntoEntityAsync();

        return "Initialization data succeed";
    }
}