namespace SEMBS.SEMBS.Models.DTO
{
    public class LoginResponseDTO
    {
        public string AccessToken { get; set; } = "";
        public int ExpiresIn { get; set; }
        public string Role { get; set; } = "";
        public int UserId { get; set; }
        public string FullName { get; set; } = "";
    }
}
