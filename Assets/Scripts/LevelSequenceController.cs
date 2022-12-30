using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner
{
    [System.Serializable]
    public class PlayerSaveData
    {
        public int m_LevelIndex;
    }

    public class LevelSequenceController : SingletonBase<LevelSequenceController>
    {
        [DllImport("__Internal")]
        private static extern void SaveExtern(string date);

        [DllImport("__Internal")]
        private static extern void LoadExtern();

        [DllImport("__Internal")]
        private static extern void SetToLeaderboard(int value);

        [DllImport("__Internal")]
        private static extern void ShowAdv();

        public static string MainMenuSceneNickname = "MainMenu";

        public Level CurrentEpisode { get; private set; }

        public int CurrentLevel { get; private set; }

        public bool LastLevelResult { get; private set; }

        public PlayerStatistics LevelStatistics { get; private set; }

        public static Player PlayerCube { get; set; }

        public PlayerSaveData m_PlayerSaveData;

        protected override void Awake()
        {
            base.Awake();

            LoadExtern();
        }

        public void StartEpisode(Level episode)
        {
            CurrentEpisode = episode;
            CurrentLevel = 0;

            LevelStatistics = new PlayerStatistics();
            LevelStatistics.Reset();

            SceneManager.LoadScene(episode.Levels[CurrentLevel]);
        }

        public void RestartLevel()
        {
            LevelStatistics.Reset();

            SceneManager.LoadScene(CurrentEpisode.Levels[CurrentLevel]);
        }

        public void FinishCurrentLevel(bool success)
        {
            LastLevelResult = success;
            CalculateLevelStatistic();

            if (LastLevelResult == true)
            {
                SaveLevel(CurrentEpisode.IndexIsCompleated);
            }

            ShowAdv();

            ResultPanelController.Instance.ShowResults(LevelStatistics, success);
        }

        public void AdvanceLevel()
        {
            LevelStatistics.Reset();

            CurrentLevel++;

            if (CurrentEpisode.Levels.Length <= CurrentLevel)
            {
                SceneManager.LoadScene(MainMenuSceneNickname);
            }
            else
            {
                SceneManager.LoadScene(CurrentLevel);
            }
        }

        private void CalculateLevelStatistic()
        {
            LevelStatistics.score = Player.Instance.Score;
            LevelStatistics.time = (int)LevelController.Instance.LevelTime;
        }

        public void SaveLevel(int index)
        {
            if (m_PlayerSaveData.m_LevelIndex < index)
            {
                m_PlayerSaveData.m_LevelIndex = index;

                SaveYandexDate();
                SetToLeaderboard(m_PlayerSaveData.m_LevelIndex);
            }

            if (m_PlayerSaveData.m_LevelIndex == 5)
            {
                Yandex.Instance.RateGameButton();
            }
        }

        public void SaveYandexDate()
        {
            string jsonString = JsonUtility.ToJson(m_PlayerSaveData);
            SaveExtern(jsonString);
        }

        public void LoadYandexDate(string value)
        {
            m_PlayerSaveData = JsonUtility.FromJson<PlayerSaveData>(value);
        }
    }
}