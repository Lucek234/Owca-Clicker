using System.IO;
using UnityEngine;
namespace Assets
{
    [System.Serializable]
    public class SaveGame 
    {
        public string Name = "Staś";
        public int LiczbaOwiec = 1;
        public int LiczbaAutoMatycznychNozyczek = 0;
        public int LiczbaPrzyspieszenia = 0;
      public int LiczbaNozyczek = 1;
       public int Points;
        public int EkoLevel = 1;

        public int LiczbaKurczokow = 0;
        public int KurczakAutoZbieraczJaj = 0;

        internal void Save()
        {
            var path = Path.Combine(Application.persistentDataPath, "save.dat");
            var str = JsonUtility.ToJson(this);
            File.WriteAllText(path, str);
        }

        public static SaveGame Load()
        {

            var path = Path.Combine(Application.persistentDataPath, "save.dat");
            var str = File.ReadAllText(path);
            var saveGame = JsonUtility.FromJson<SaveGame>(str);
            return saveGame;
        }
    }
}