using TMPro;
using UnityEngine;

namespace Runner
{
    public class BlockPanel : MonoBehaviour
    {
        [SerializeField] private int m_IndexBlockPanel;

        private void Start()
        {
            if (m_IndexBlockPanel < LevelSequenceController.Instance.m_PlayerSaveData.m_LevelIndex)
            {
                UnlockIsReady();
            }
        }

        private void UnlockIsReady()
        {
            Destroy(gameObject);
        }
    }
}