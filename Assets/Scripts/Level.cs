using UnityEngine;

namespace Runner
{
    [CreateAssetMenu]
    public class Level : ScriptableObject
    {
        [SerializeField] private string m_LevelName;
        public string LevelName => m_LevelName;

        [SerializeField] private string[] m_Levels;
        public string[] Levels => m_Levels;

        [SerializeField] private int m_IndexIsCompleated;
        public int IndexIsCompleated => m_IndexIsCompleated;
    }
}