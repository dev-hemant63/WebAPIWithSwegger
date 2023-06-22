using System.Threading.Tasks;
using WebAPI.AppCode.Interface;
using WebAPI.Models;

namespace WebAPI.AppCode.Services
{
    public class AccountService: IAccountService
    {
        private readonly IHellper _helper;
        public AccountService(IHellper hellper)
        {
            _helper = hellper;
        }
        public async Task<Response> SignUp(ApplicationUser request)
        {
            string sp = @"insert into Users(Name,Mobile,EmailID,Password)
                            values(@Name,@Mobile,@EmailID,@Password)";
            var res = new Response();
            try
            {
                var i = await _helper.ExecuteProcAsync<int>(sp, new
                {
                    request.Name,
                    request.EmailID,
                    request.Mobile,
                    request.Password
                });
                if (i == 1)
                {
                    res.Statuscode = 1;
                    res.Msg = "SignUp successfully";
                }
            }
            catch (System.Exception ex)
            {
                res.Statuscode = -1;
                res.Msg = "SignUp failed try after sometime!";
            }
            return res;
        }
        public async Task<ApplicationUser> SignIn(ApplicationUser request)
        {
            string sp = @"select * from Users where Mobile = @Mobile and @Password = Password";
            var res = new ApplicationUser();
            try
            {
                res = await _helper.GetAsync<ApplicationUser>(sp, new
                {
                    request.Mobile,
                    request.Password
                });
            }
            catch (System.Exception ex)
            {
                
            }
            return res;
        }
    }
}
