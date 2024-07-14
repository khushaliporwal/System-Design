namespace Data.Publisher
{
    public interface IPublisher
    {
        public async Task ProduceAsync(string msg) { }
    }
}
