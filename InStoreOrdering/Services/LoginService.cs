using InStoreOrdering.IRepositorys;
using InStoreOrdering.IServices;
using InStoreOrdering.Models;

namespace InStoreOrdering.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public bool InsertUserInfo(UserModel user)
        {
            try
            {
                return _loginRepository.InsertUserInfo(user);
            }
            catch (Exception ex)
            {
                // 處理例外
                return false;
            }
        }
    }
}
