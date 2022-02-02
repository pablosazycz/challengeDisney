namespace Disney.Entities
{
    public class Character
    {
        public int Id { get; set; }

        public string Image { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Weight {get;set;}
        public string History { get; set;}

        //relacion

        public ICollection<MovieSerie> MovieSerie { get; set; }  = new List<MovieSerie>();



    }
}
