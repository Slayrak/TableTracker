namespace TableTracker.Domain.Entities
{
    public class VisitorFavourites : IEntity<long>
    {
        public long Id { get; set; }

        public long VisitorId { get; set; }
        public Visitor Visitor { get; set; }
        public long RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
