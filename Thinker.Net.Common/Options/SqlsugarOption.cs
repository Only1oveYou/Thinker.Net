namespace Thinker.Net.Common.Options;

public class SqlsugarOption: IConfigurableOptions
{
    public bool Enable { get; set; }

    public string ConnectionString { get; set; }
}