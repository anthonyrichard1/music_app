namespace App.Model
{
    public interface IPersistance
    {
        public void SaveMusics(IEnumerable<Music> musics);
        public IEnumerable<Music> LoadMusics();
    }
}
