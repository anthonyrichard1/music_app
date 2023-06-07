using App.Model;
using App.Persistance;
using App.Stub;

Manager manager = new(new Persistance(""));

foreach (var item in manager.MusicList) Console.WriteLine(item);