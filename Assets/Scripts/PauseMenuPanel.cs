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
            Sounds.Instance.PlaySounds(Sounds.Instance.AudioClipButton);

            Time.timeScale = 0;
            gameObject.SetActive(true);
        }

        public void OnButtonContinue()
        {
            Sounds.Instance.PlaySounds(Sounds.Instance.AudioClipButton);

            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        public void OnButtonMainMenu()
        {
            Sounds.Instance.PlaySounds(Sounds.Instance.AudioClipButton);

            Time.timeScale = 1;
            gameObject.SetActive(false);

            SceneManager.LoadScene(LevelSequenceController.MainMenuSceneNickname);
        }

        public void OnButtonRestart()
        {
            Sounds.Instance.PlaySounds(Sounds.Instance.AudioClipButton);

            LevelSequenceController.Instance.RestartLevel();
        }
    }
}
