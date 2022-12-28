using UnityEngine;

namespace Runner
{
    public class BonusScore : Bonus
    {
        [SerializeField] private int m_Score;

        [SerializeField] private Vector3 m_Rotation;
        [SerializeField] private float m_SpeedRotation;

        private void Update()
        {
            transform.Rotate(m_Rotation * m_SpeedRotation * Time.deltaTime);
        }

        protected override void OnPickeUp()
        {
            Player.Instance.AddScore(m_Score);
        }
    }
}