namespace Disney.Entities
{
    public class Gender

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        //relacion
        public ICollection<MovieSerie> MovieSerie { get; set; } = new List<MovieSerie>();
    }
}
