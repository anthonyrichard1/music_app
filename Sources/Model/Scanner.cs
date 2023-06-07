using System.Diagnostics;

namespace App.Model
{
    public class Scanner
    {
        public IEnumerable<Music> Scan(List<Music> mList)
        {
            Debug.WriteLine(Directory.GetLogicalDrives());
            return mList;
        }
    }
}
