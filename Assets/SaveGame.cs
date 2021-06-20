using System;
using System.IO;

namespace Assets
{
    [Serializable]
    public class SaveGame
    {
        public int EkoLevel = 1;
        public int LiczbaAutoMatycznychNozyczek = 0;
        public int LiczbaNozyczek = 1;
        public int LiczbaOwiec = 1;
        public int LiczbaPrzyspieszenia = 0;
        public string Name = "Staś";
        public int Points;

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