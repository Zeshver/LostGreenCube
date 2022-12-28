using UnityEngine;
using UnityEngine.Events;

namespace Runner
{
    public class LevelConditionScoreAndTime : SingletonBase<LevelConditionScoreAndTime>, ILevelCondition
    {
        [SerializeField] private int score;

        [SerializeField] private float time;
        public float Timer => time;

        private int m_Reached;

        private void Update()
        {
            time -= Time.deltaTime;

            if (time < 0)
            {
                time = 0;
            }
        }

        int ILevelCondition.IsCompleted
        {
            get
            {
                if (Player.Instance != null)
                {
                    if (Player.Instance.Score >= score && time >= 0)
                    {
                        m_Reached = 1;
                    }
                    else if (time <= 0)
                    {
                        m_Reached = 2;
                    }
                }

                return m_Reached;
            }
        }
    }
}