using UnityEngine;

namespace Runner
{
    public class OnButtonInput : MonoBehaviour
    {
        [SerializeField] private GameObject m_PCControllButton;
        [SerializeField] private GameObject m_MobileControllButton;

        [SerializeField] private GameObject m_PlayMusic;
        [SerializeField] private GameObject m_PauseMusic;

        [SerializeField] private GameObject m_PauseMusicObject;

        private void Start()
        {
            if (SetPlayerInput.Instance.m_ControlMode == ControlMode.Keyboard)
            {
                m_PCControllButton.SetActive(false);
                m_MobileControllButton.SetActive(true);
            }
            if (SetPlayerInput.Instance.m_ControlMode == ControlMode.Mobile)
            {
                m_PCControllButton.SetActive(true);
                m_MobileControllButton.SetActive(false);
            }

            if (SetPlayerInput.Instance.m_ControlMusic == ControlMusic.Play)
            {
                m_PlayMusic.SetActive(false);
                m_PauseMusic.SetActive(true);
                m_PauseMusicObject.SetActive(true);
            }
            if (SetPlayerInput.Instance.m_ControlMusic == ControlMusic.Pause)
            {
                m_PlayMusic.SetActive(true);
                m_PauseMusic.SetActive(false);
                m_PauseMusicObject.SetActive(false);
            }
        }

        public void OnButtonPCController()
        {
            SetPlayerInput.Instance.m_ControlMode = ControlMode.Keyboard;
            m_PCControllButton.SetActive(false);
            m_MobileControllButton.SetActive(true);

            Sounds.Instance.PlaySounds(Sounds.Instance.AudioClipButton);
        }

        public void OnButtonMobileController()
        {
            SetPlayerInput.Instance.m_ControlMode = ControlMode.Mobile;
            m_MobileControllButton.SetActive(false);
            m_PCControllButton.SetActive(true);

            Sounds.Instance.PlaySounds(Sounds.Instance.AudioClipButton);
        }

        public void OnButtonPlayMusic()
        {
            SetPlayerInput.Instance.m_ControlMusic = ControlMusic.Play;
            m_PlayMusic.SetActive(false);
            m_PauseMusic.SetActive(true);
            m_PauseMusicObject.SetActive(true);

            Sounds.Instance.PlaySounds(Sounds.Instance.AudioClipButton);
        }

        public void OnButtonPauseMusic()
        {
            SetPlayerInput.Instance.m_ControlMusic = ControlMusic.Pause;
            m_PlayMusic.SetActive(true);
            m_PauseMusic.SetActive(false);
            m_PauseMusicObject.SetActive(false);

            Sounds.Instance.PlaySounds(Sounds.Instance.AudioClipButton);
        }
    }
}
