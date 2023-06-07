using App.Model;
using System.Runtime.Serialization;
using System.Xml;

namespace App.Persistance
{
    public class Persistance : IPersistance
    {
        private const string fileName = "musics.xml";
        private const string folderName = "Data";
        private readonly string FolderPath;
        private string FullPath => Path.Combine(FolderPath, fileName);

        public Persistance(string path)
            => FolderPath = Path.Combine(path, folderName);

        public IEnumerable<Music> LoadMusics()
        {
            if (!File.Exists(FullPath)) return Enumerable.Empty<Music>();

            DataContractSerializer serializer = new(typeof(IEnumerable<Music>));
            using (Stream stream = File.OpenRead(FullPath)) return serializer.ReadObject(stream) as IEnumerable<Music>;
        }

        public void SaveMusics(IEnumerable<Music> musics)
        {
            if (!Directory.Exists(FolderPath)) Directory.CreateDirectory(FolderPath);

            DataContractSerializer serializer = new(typeof(IEnumerable<Music>));
            XmlWriterSettings settings = new() { Indent = true};

            using (TextWriter tw = File.CreateText(FullPath))
            using (XmlWriter writer = XmlWriter.Create(tw, settings))
                serializer.WriteObject(writer, musics);
        }
    }
}