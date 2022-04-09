namespace TableTracker.Domain.DataTransferObjects
{
    public class VisitorFavouriteDTO
    {
        public long Id { get; set; }

        public VisitorDTO Visitor { get; set; }

        public RestaurantDTO Restaurant { get; set; }
    }
}
