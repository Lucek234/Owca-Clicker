//using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;
namespace Assets
{
    [System.Serializable]
    public class SaveGame 
    {
        public string Name;
        public int LiczbaOwiec;

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