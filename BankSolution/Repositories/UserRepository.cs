using BankSolution.Contexts;
using BankSolution.Models;

public class UserRepository : BaseRepository<int, User>
{
    public UserRepository(BankSolutionContext context) : base(context) { }
}