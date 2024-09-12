namespace Application.Models
{
    public record ApplicationUserDto : BaseDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
