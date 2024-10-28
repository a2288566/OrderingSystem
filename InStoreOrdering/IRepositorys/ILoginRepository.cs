using InStoreOrdering.Models;

namespace InStoreOrdering.IRepositorys
{
    public interface ILoginRepository
    {
        bool InsertUserInfo(UserModel user);
        bool CheckAccount(UserModel user);
    }
}
