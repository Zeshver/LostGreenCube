using UnityEngine;

namespace Runner
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicController : MonoBehaviour
    {
        [SerializeField] private AudioSource m_AudioSourceMusic;

        private void Start()
        {
            m_AudioSourceMusic = GetComponent<AudioSource>();

            CheckControlMusicThree();
        }

        private void Update()
        {
            CheckControlMusicThree();
        }

        private void CheckControlMusicThree()
        {
            if (SetPlayerInput.Instance.m_ControlMusic == ControlMusic.Play)
            {
                gameObject.SetActive(true);
            }
            if (SetPlayerInput.Instance.m_ControlMusic == ControlMusic.Pause)
            {
                gameObject.SetActive(false);
            }
        }
    }
}