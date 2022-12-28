using UnityEngine;

namespace Runner
{
    public class MainMenuController : SingletonBase<MainMenuController>
    {
        [SerializeField] private GameObject m_EpisodeSelection;

        [SerializeField] private GameObject m_GlobalStatistic;

        public void OnButtonStartNew()
        {
            m_EpisodeSelection.gameObject.SetActive(true);
            SoundButton.Instance.OnButtonSound();
        }

        public void OnGlobalStatistic()
        {
            m_GlobalStatistic.SetActive(true);
            SoundButton.Instance.OnButtonSound();
        }

        public void OnBack()
        {
            m_EpisodeSelection.SetActive(false);
            m_GlobalStatistic.SetActive(false);
            SoundButton.Instance.OnButtonSound();
        }
    }
}