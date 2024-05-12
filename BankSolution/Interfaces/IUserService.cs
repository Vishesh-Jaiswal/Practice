using BankSolution.Models;

namespace BankSolution.Interfaces
{
    public interface IUserService
    {
        User? Register(User user);
    }
}