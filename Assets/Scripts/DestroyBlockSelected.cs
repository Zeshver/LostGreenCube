using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class DestroyBlockSelected : MonoBehaviour
    {
        [SerializeField] private List<GameObject> m_SecondGroup;

        private void OnTriggerEnter(Collider collision)
        {
            CubeController cube = collision.transform.root.GetComponent<CubeController>();

            if (cube != null && cube.PlayerCubeMode == CubeController.CubeMode.Main)
            {
                foreach (var second in m_SecondGroup)
                {
                    second.GetComponentInChildren<ParticleSystem>().Play();
                    second.GetComponent<BoxCollider>().isTrigger = true;
                    Destroy(second.GetComponentInChildren<Renderer>());
                    Destroy(second, 2);
                }

                Destroy(gameObject);
            }
        }
    }
}