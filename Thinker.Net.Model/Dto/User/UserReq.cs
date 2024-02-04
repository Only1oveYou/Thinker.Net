namespace Thinker.Net.Model.Dto.User;

public class UserReq
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}
