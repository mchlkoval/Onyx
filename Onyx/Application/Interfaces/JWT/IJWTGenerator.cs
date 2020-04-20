using Domain.Identity;

namespace Application.Interfaces.JWT
{
    public interface IJWTGenerator
    {
        string CreateToken(AppUser user);
    }
}
