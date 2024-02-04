

namespace Thinker.Net.Model.Dto.Login
{
    public class LoginReq
    {
        [Required]
        [DefaultValue("admin")]
        public string UserName { get; set; }
        [Required]
        [DefaultValue("123456")]
        public string PassWord { get; set; }
    }
}