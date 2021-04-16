namespace ModelFactory.Model.Player
{
    public interface IPlayerModel : IModel
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}