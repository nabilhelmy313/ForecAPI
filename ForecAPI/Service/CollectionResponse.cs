namespace ForecAPI.Service
{
    public class CollectionResponse<T>
    {
        public CollectionResponse(ICollection<T> collection, int length)
        {
            Collection = collection;
            Length = length;
        }
        public ICollection<T> Collection { get; set; }
        public int Length { get; }
    }
}
