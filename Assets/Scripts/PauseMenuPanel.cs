using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner
{
    public class PauseMenuPanel : MonoBehaviour
    {
        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void OnButtonShowPause()
        {
            SoundButton.Instance.OnButtonSound();

            Time.timeScale = 0;
            gameObject.SetActive(true);
        }

        public void OnButtonContinue()
        {
            SoundButton.Instance.OnButtonSound();

            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        public void OnButtonMainMenu()
        {
            SoundButton.Instance.OnButtonSound();

            Time.timeScale = 1;
            gameObject.SetActive(false);

            SceneManager.LoadScene(LevelSequenceController.MainMenuSceneNickname);
        }

        public void OnButtonRestart()
        {
            SoundButton.Instance.OnButtonSound();

            LevelSequenceController.Instance.RestartLevel();
        }
    }
}
