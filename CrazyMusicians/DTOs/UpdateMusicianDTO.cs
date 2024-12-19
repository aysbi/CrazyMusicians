namespace CrazyMusicians.DTOs
{
    public class UpdateMusicianDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Occupation { get; set; } = "";

        public string Description { get; set; } = "";
    }
}
