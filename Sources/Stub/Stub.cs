using App.Model;

namespace App.Stub
{
    public class Stub : IPersistance
    {
        private List<Music> Musics;

        public Stub()
            => Musics = LoadMusics().ToList();

        public IEnumerable<Music> LoadMusics()
            => new List<Music>()
            {
                new("Title 1", "Artist 1"),
                new("Title 2", "Artist 2"),
                new("Title 3", "Artist 3"),
                new("Title 4", "Artist 4"),
                new("Title 5", "Artist 5")
            };

        public void SaveMusics(IEnumerable<Music> musics)
        {
            foreach (var music in musics) if (!Musics.Contains(music)) Musics.Add(music);
        }
    }
}