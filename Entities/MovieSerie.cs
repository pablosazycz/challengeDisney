namespace Disney.Entities
{
    public class MovieSerie
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get;set; }
        public string Description { get;set; }

        public DateOnly Datecreation { get; set; }

        public Decimal Qualification { get; set; }
        
         //relacion
        
         public Gender Gender { set; get; }

         public ICollection<Character> Character { get; set; } = new List<Character>();

    }
}
