using System.Runtime.Serialization;

namespace BankSolution.Exceptions
{

    public class CannotTranferFromPFF : Exception
    {
        string message;
        public CannotTranferFromPFF()
        {
            message = "Cannot transfer from this account.";
        }
        public override string Message => message;
    }
}