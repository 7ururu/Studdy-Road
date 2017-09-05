using UnityEngine;

public static class Settings {

    private const string SELECTED_CHAR_INDEX_PREF = "selected_char_index";
    public static int SelectedCharacterIndex {
        get {
            return PlayerPrefs.HasKey(SELECTED_CHAR_INDEX_PREF) ?
                   PlayerPrefs.GetInt(SELECTED_CHAR_INDEX_PREF) : 0;
        }
        set {
            PlayerPrefs.SetInt(SELECTED_CHAR_INDEX_PREF, value);
            PlayerPrefs.Save();
        }
    }
}