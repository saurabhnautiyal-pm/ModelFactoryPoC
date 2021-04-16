namespace ModelFactory.Model.Balance
{
    public class PlayerBalanceModel : IPlayerBalanceModel
    {
        public int PlayerId { get; set; }
        public decimal Balance { get; set; }
    }
}