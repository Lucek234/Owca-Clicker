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
        public int KurczokLiczbaLepszejPaszy = 0;

        public void Save()
        {
            var path = Path.Combine(Application.persistentDataPath, "save.json");
            var str = JsonUtility.ToJson(this);
            File.WriteAllText(path, str);
        }

        public static SaveGame Load()
        {
            try
            {
                var path = Path.Combine(Application.persistentDataPath, "save.json");
                var str = File.ReadAllText(path);
                if (string.IsNullOrWhiteSpace(str)) throw new Exception();
                var saveGame = JsonUtility.FromJson<SaveGame>(str);
                return saveGame;
            }
            catch
            {
                return new SaveGame();
            }
        }

        private SaveGame() { }

        public static SaveGame Instance { get; } = SaveGame.Load();
        public int KrowaLevel1;
        public int KrowaLevel2;
        public int KrowaLevel3;
        public int KrowaLevel4;

        public int KozaLevel1;
        public int KozaLevel2;
        public int KozaLevel3;
        public int KozaLevel4;
    }
}