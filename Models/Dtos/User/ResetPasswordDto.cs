namespace PasantiasTW.Models.Dtos.User
{
    public record ResetPasswordDto
    {
        public string Email { get; set; } = string.Empty;
    }
}
