using System.Collections.Generic;
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

        public enum InputTransform
        {
            UpDown,
            LeftRight
        }

        [SerializeField] private CubeMode m_CubeMode;
        public CubeMode PlayerCubeMode => m_CubeMode;

        [SerializeField] private InputTransform m_InputTransform;
        public InputTransform PlayerInputTransform => m_InputTransform;

        [SerializeField] private Vector3 m_MoveDirection;

        private void Start()
        {
            MovementController.Instance.AddListCubeController(this);
        }
    }
}