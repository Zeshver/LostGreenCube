using UnityEngine;
using TMPro;

namespace Runner
{
    public class ResultPanelController : SingletonBase<ResultPanelController>
    {
        [SerializeField] private TextMeshProUGUI m_Score;
        [SerializeField] private TextMeshProUGUI m_Time;

        [SerializeField] private TextMeshProUGUI m_Result;

        [SerializeField] private TextMeshProUGUI m_ButtonNextText;

        private bool m_Success;

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void ShowResults(PlayerStatistics levelResult, bool success)
        {
            gameObject.SetActive(true);

            m_Success = success;

            m_Score.text = "Очки : " + levelResult.score.ToString();
            m_Time.text = "Время : " + levelResult.time.ToString();

            m_Result.text = success ? "Победа" : "Поражение";
            m_ButtonNextText.text = success ? "Следующий уровень" : "Заново";

            Time.timeScale = 0;
        }

        public void OnButtonNextAction()
        {
            Sounds.Instance.PlaySounds(Sounds.Instance.AudioClipButton);

            gameObject.SetActive(false);

            Time.timeScale = 1;

            if (m_Success)
            {
                LevelSequenceController.Instance.AdvanceLevel();
            }
            else
            {
                LevelSequenceController.Instance.RestartLevel();
            }
        }
    }
}
