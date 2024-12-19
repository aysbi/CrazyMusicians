namespace CrazyMusicians.Models
{
    public static class Data
    {
        private static List<Musician> _musicians = new List<Musician>()
            {
                new Musician() { Id = 1, Name = "Ahmet Calgi", Occupation = "Unlu Calgi Calar", Description = "Her zaman yanlis nota calar, ama cok eglencelidir" },
                new Musician() { Id = 2, Name = "Zeynep Melodi", Occupation = "Populer Melodi Yazari", Description = "Sarkilari yanlis anlasilir ama cok populerdir" },
                new Musician() { Id = 3, Name = "Cemil Akor", Occupation = "Cilgin Akorist", Description = "Akorlari sik degistirir, ama sasirtici derecede yetenekli"},
                new Musician() { Id = 4, Name = "Fatma Nota", Occupation = "Surpriz Nota Ureticisi", Description = "Nota uretirken surekli surprizler yapar"},
                new Musician() { Id = 5, Name = "Hasan Ritim", Occupation = "Ritim Canavari", Description = "Her ritmi kendi tarzinda yapar, hic uymaz ama komiktir"}
            };
       
        public static List<Musician> Musicians()
        {
            return _musicians;
        }                
    }
}
