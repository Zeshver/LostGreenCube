using UnityEngine;

namespace Runner
{
    [RequireComponent(typeof(Rigidbody))]
    public class CubeController : MonoBehaviour
    {
        public enum CubeMode
        {
            Main,
            Other
        }

        [SerializeField] private CubeMode m_CubeMode;
        public CubeMode PlayerCubeMode => m_CubeMode;

        [SerializeField] private Vector3 m_MoveDirection;

        private void Start()
        {
            MovementController.Instance.AddListCubeController(this);
        }
    }
}