using UnityEngine;

namespace Runner
{
    public class Teleporter : MonoBehaviour
    {
        [SerializeField] private Teleporter target;

        [SerializeField] private bool IsReceive;

        private void OnTriggerEnter(Collider collision)
        {
            if (IsReceive == true)
            {
                return;
            }

            CubeController cube = collision.transform.root.GetComponent<CubeController>();

            if (cube != null && cube.PlayerCubeMode == CubeController.CubeMode.Main)
            {
                target.IsReceive = true;

                cube.transform.position = target.transform.position;
            }
        }

        private void OnTriggerExit(Collider collision)
        {
            CubeController cube = collision.transform.root.GetComponent<CubeController>();

            if (cube != null)
            {
                IsReceive = false;
            }
        }
    }
}