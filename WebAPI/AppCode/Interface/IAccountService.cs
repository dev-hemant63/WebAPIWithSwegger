using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.AppCode.Interface
{
    public interface IAccountService
    {
        Task<Response> SignUp(ApplicationUser request);
        Task<ApplicationUser> SignIn(ApplicationUser request);
    }
}
