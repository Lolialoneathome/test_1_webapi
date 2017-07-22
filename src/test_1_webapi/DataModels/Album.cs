namespace test_1_webapi_Domain.DataModels
{
    public class Album : IModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }

    }
}
