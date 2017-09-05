using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Config")]
public class Config : ScriptableObject {

    private static Config _instance;
    public static Config Instance {
        get {
            if (_instance == null) {
                _instance = Resources.LoadAll<Config>("").FirstOrDefault();
            }
            return _instance;
        }
    }

    public string menuSceneName;
    public string defaultLevelSceneName;

    [Space]
    public Character[] characters;
}