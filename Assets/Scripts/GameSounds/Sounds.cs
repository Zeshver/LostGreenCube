using UnityEngine;

namespace Runner
{
    [RequireComponent(typeof(AudioSource))]
    public class Sounds : SingletonBase<Sounds>
    {
        [SerializeField] private AudioSource m_AudioSource;

        [Header("Sounds")]
        [SerializeField] private AudioClip m_AudioClipButton;
        public AudioClip AudioClipButton => m_AudioClipButton;

        [SerializeField] private AudioClip m_AudioClipPickUp;
        public AudioClip AudioClipPickUp => m_AudioClipPickUp;

        private void Start()
        {
            m_AudioSource = GetComponent<AudioSource>();
        }

        public void PlaySounds(AudioClip audioClip)
        {
            if (SetPlayerInput.Instance.m_ControlMusic == ControlMusic.Play)
            {
                m_AudioSource.clip = audioClip;
                m_AudioSource.Play();
            }
            if (SetPlayerInput.Instance.m_ControlMusic == ControlMusic.Pause)
            {
                return;
            }
        }
    }
}