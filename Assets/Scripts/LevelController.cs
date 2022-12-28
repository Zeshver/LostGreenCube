using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Runner
{
    public interface ILevelCondition
    {
        int IsCompleted { get; }
    }

    public class LevelController : SingletonBase<LevelController>
    {
        [SerializeField] private UnityEvent m_EventLevelCompleted;

        [SerializeField] private TextMeshProUGUI m_LevelTimeText;

        [SerializeField] private GameObject m_TimePanel;

        private LevelConditionScoreAndTime m_LevelConditionScoreAndTime;

        private ILevelCondition[] m_Conditions;

        private bool m_IsLevelCompleted;

        private float m_LevelTime;
        public float LevelTime => m_LevelTime;

        private void Start()
        {
            m_Conditions = GetComponentsInChildren<ILevelCondition>();

            if (gameObject.GetComponentInChildren<LevelConditionScoreAndTime>() == null)
            {
                Destroy(m_TimePanel);

                return;
            }

            if (m_LevelConditionScoreAndTime == null)
            {
                m_LevelConditionScoreAndTime = GetComponentInChildren<LevelConditionScoreAndTime>();
            }
        }

        private void Update()
        {
            if (m_LevelConditionScoreAndTime != null)
            {
                m_LevelTimeText.text = Mathf.Round(m_LevelConditionScoreAndTime.Timer).ToString();
            }

            if (!m_IsLevelCompleted)
            {
                m_LevelTime += Time.deltaTime;

                CheckLevelConditions();
            }
        }

        private void CheckLevelConditions()
        {
            if (m_Conditions == null || m_Conditions.Length == 0) return;

            int numCompleted = 0;

            foreach (var v in m_Conditions)
            {
                if (v.IsCompleted == 1)
                {
                    numCompleted += 1;
                }

                if (v.IsCompleted == 2)
                {
                    numCompleted += 2;
                }
            }

            if (numCompleted == m_Conditions.Length)
            {
                m_IsLevelCompleted = true;
                m_EventLevelCompleted?.Invoke();

                LevelSequenceController.Instance?.FinishCurrentLevel(true);
            }

            if (numCompleted > m_Conditions.Length)
            {
                m_IsLevelCompleted = true;
                m_EventLevelCompleted?.Invoke();

                LevelSequenceController.Instance?.FinishCurrentLevel(false);
            }
        }
    }
}
