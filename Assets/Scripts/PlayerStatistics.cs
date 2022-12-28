using UnityEngine;

namespace Runner
{
    public class PlayerStatistics : MonoBehaviour
    {
        public int score;
        public int time;

        public void Reset()
        {
            score = 0;
            time = 0;
        }
    }
}