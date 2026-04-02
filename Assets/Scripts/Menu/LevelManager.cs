using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance;

    [Header("Meta Progression")]
    public int maxUnlockedLevel = 1;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadProgress();
        } else {
            Destroy(gameObject);
        }
    }

    public void LoadProgress() {
        maxUnlockedLevel = PlayerPrefs.GetInt("MaxUnlockedLevel", 1);
    }

    public void UnlockNextLevel(int completedLevelIndex) {
        int nextLevel = completedLevelIndex + 1;
        if (nextLevel > maxUnlockedLevel) {
            maxUnlockedLevel = nextLevel;
            PlayerPrefs.SetInt("MaxUnlockedLevel", maxUnlockedLevel);
            PlayerPrefs.Save();
        }
    }
}
