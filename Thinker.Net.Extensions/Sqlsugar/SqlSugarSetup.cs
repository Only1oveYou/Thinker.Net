namespace Thinker.Net.Extensions.Sqlsugar;

public static class SqlSugarSetup
{
    public static void AddSqlSugarSetup(this IServiceCollection services)
    {
        var conn = AppSettings.app(new[] { "Sqlsugar", "ConnectionString" });

        services.AddSingleton<ISqlSugarClient>(o =>
        {
            var db = new SqlSugarClient(new ConnectionConfig()
            {
                DbType = DbType.MySql,
                ConnectionString = AppSettings.app(new[] { "Sqlsugar", "ConnectionString" }),
                IsAutoCloseConnection = true,
            });

            db.Aop.OnLogExecuting = (sql, para) =>
            {
                Console.WriteLine($"===================");
                Console.WriteLine($"Sql语句:{sql}");
                List<string> list = new List<string>();
                para.ToList().ForEach(p => { list.Add(p.Value != null ? p.Value.ToString() : ""); });
                Console.WriteLine($"参数:{string.Join(",", list)}");
            };
            Console.WriteLine($"DB: {db.GetHashCode()}");
            return db;
        });
    }
}