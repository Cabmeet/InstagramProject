namespace Insta.BusinessLogic.Entities
{
    public sealed class Container<TEntity>
    {
        public TEntity[] Entities { get; set; }

        public int Page { get; set; }

        public int TotalEntities { get; set; }
    }
}
