using System.IO;

namespace SingleResponsibility
{
    public class Persistence
    {
        public void SaveToFile(Journal Journal, string filename, bool overwrite = false)
        {
           if(overwrite || !File.Exists(filename))
               File.WriteAllText(filename, Journal.ToString());
        }
    }
}