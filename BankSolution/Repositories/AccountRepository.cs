using BankSolution.Contexts;
using BankSolution.Models;

public class AccountRepository : BaseRepository<int, Account>
{
    public AccountRepository(BankSolutionContext context) : base(context) { }
}