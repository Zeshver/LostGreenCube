using UnityEngine;

namespace Runner
{
    public class LevelConditionScore : MonoBehaviour, ILevelCondition
    {
        [SerializeField] private int score;

        private int m_Reached;

        int ILevelCondition.IsCompleted
        {
            get
            {
                if (Player.Instance != null)
                {
                    if (Player.Instance.Score >= score)
                    {
                        m_Reached = 1;
                    }
                }

                return m_Reached;
            }
        }
    }
}
