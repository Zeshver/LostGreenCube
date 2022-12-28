using UnityEngine;

namespace Runner
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundPickUp : SingletonBase<SoundPickUp>
    {
        [SerializeField] private AudioSource m_AudioSourcePickup;

        private void Start()
        {
            m_AudioSourcePickup = GetComponent<AudioSource>();
        }

        public void PlaySoundPickup()
        {
            if (SetPlayerInput.Instance.m_ControlMusic == ControlMusic.Play)
            {
                m_AudioSourcePickup.Play();
            }
            if (SetPlayerInput.Instance.m_ControlMusic == ControlMusic.Pause)
            {
                return;
            }
        }
    }
}