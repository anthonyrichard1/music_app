using System.Collections.ObjectModel;

namespace App.Model
{
    public class Manager
    {
        private IPersistance persistance;
        private Scanner scanner;
        public ObservableCollection<Music> MusicList { get; set; }

        public Manager(IPersistance _persistance)
        {
            this.persistance = _persistance;
            MusicList = new(persistance.LoadMusics());
            scanner = new();
        }

        public void Scan()
        {
            MusicList = new(scanner.Scan(MusicList.ToList()));
            persistance.SaveMusics(MusicList);
        }
    }
}
