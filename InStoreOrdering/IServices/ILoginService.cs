using InStoreOrdering.Models;

namespace InStoreOrdering.IServices
{
    public interface ILoginService
    {
        bool InsertUserInfo(UserModel user);
    }
}
