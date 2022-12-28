using UnityEngine;

namespace Runner
{
    public class PickUp : MonoBehaviour
    {
        public enum PickUpMode
        {
            Destroy,
            AddScore
        }

        [SerializeField] private PickUpMode m_PickUpMode;
        public PickUpMode Mode => m_PickUpMode;
    }
}