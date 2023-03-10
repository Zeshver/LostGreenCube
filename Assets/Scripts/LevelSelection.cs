using UnityEngine;
using TMPro;

namespace Runner
{
    public class LevelSelection : MonoBehaviour
    {
        [SerializeField] private Level m_Level;

        [SerializeField] private TextMeshProUGUI m_LevelNickname;

        private void Start()
        {
            if (m_LevelNickname != null)
            {
                m_LevelNickname.text = m_Level.LevelName;
            }
        }               

        public void OnStartEpisodeButtonClicked()
        {
            Sounds.Instance.PlaySounds(Sounds.Instance.AudioClipButton);

            LevelSequenceController.Instance.StartEpisode(m_Level);
        }
    }
}