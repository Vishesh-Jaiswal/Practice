using BankSolution.Interfaces;
using BankSolution.Models;

namespace BankSolution.Services
{
    public class UserService:IUserService
    {
        private readonly IRepository<int, User> _userRepository;
        public UserService(IRepository<int, User> userRepository)
        {
            _userRepository = userRepository;
        }
        public User? Register(User user)
        {
            var result = _userRepository.Add(user);
            if (result != null)
            {
                return user;
            }
            return null;
        }
    }
}
