using UnityEngine;

namespace Runner
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class Bonus : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collision)
        {
            CubeController pickUp = collision.GetComponent<CubeController>();

            if (pickUp != null && pickUp.PlayerCubeMode == CubeController.CubeMode.Main)
            {
                OnPickeUp();

                Destroy(gameObject);

                Sounds.Instance.PlaySounds(Sounds.Instance.AudioClipPickUp);
            }

            if (pickUp != null && pickUp.PlayerCubeMode == CubeController.CubeMode.Other)
            {
                Destroy(gameObject);

                LevelSequenceController.Instance?.FinishCurrentLevel(false);
            }
        }

        protected abstract void OnPickeUp();
    }
}