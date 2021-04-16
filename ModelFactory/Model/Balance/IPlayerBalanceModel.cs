namespace ModelFactory.Model.Balance
{
    public interface IPlayerBalanceModel : IModel
    {
         int PlayerId { get; set; }
         decimal Balance { get; set; }

    }
}