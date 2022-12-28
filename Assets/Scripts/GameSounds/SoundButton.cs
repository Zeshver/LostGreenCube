using UnityEngine;

namespace Runner
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundButton : SingletonBase<SoundButton>
    {
        [SerializeField] private AudioSource m_AudioSourceButton;

        private void Start()
        {
            m_AudioSourceButton = GetComponent<AudioSource>();
        }

        public void OnButtonSound()
        {
            if (SetPlayerInput.Instance.m_ControlMusic == ControlMusic.Play)
            {
                m_AudioSourceButton.Play();
            }
            if (SetPlayerInput.Instance.m_ControlMusic == ControlMusic.Pause)
            {
                return;
            }
        }
    }
}