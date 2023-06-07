using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace App.Model
{
    [DataContract]
    public class Music : INotifyPropertyChanged, IEquatable<Music>
    {
        [DataMember]
        public string Title
        {
            get => title;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) title = "Default";
                else title = value;
                NotifyPropertyChanged();
            }
        }
        private string title;

        [DataMember]
        public string Artist
        {
            get => artist;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) artist = "Default";
                else artist = value;
                NotifyPropertyChanged();
            }
        }
        private string artist;

        public Music(string _title, string _artist)
        {
            title = _title;
            artist = _artist;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public bool Equals(Music? other)
            => other != null && Title == other.Title;

        public override int GetHashCode()
            => Title.GetHashCode()^Artist.GetHashCode();

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Music)) return false;
            return Equals((Music)obj);
        }

        public override string ToString()
            => $"{Title} : {Artist}";
    }
}