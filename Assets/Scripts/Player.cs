using UnityEngine;

namespace Runner
{
    public class Player : SingletonBase<Player>
    {
        #region Score

        public int Score { get; private set; }        

        public void AddScore(int num)
        {
            Score += num;
        }

        #endregion
    }
}