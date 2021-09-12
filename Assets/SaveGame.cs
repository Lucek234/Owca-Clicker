using System;
using System.IO;
using UnityEngine;

namespace Assets
{
    [Serializable]
    public class SaveGame
    {
        public int EkoLevel = 1;
        public int KurczakAutoZbieraczJaj = 0;
        public int LiczbaAutoMatycznychNozyczek = 0;

        public int LiczbaKurczokow = 0;
        public int LiczbaNozyczek = 1;
        public int LiczbaOwiec = 1;
        public int OwcaLiczbaPrzyspieszenia = 0;
        public string Name = "Staś";
        public int Points;
        public int KurczakLepszaPaszaLevel = 0;
        public int KurczokLiczbaPrzyspieszenia = 0;

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