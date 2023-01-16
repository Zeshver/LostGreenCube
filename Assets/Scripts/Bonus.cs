using UnityEngine;

namespace Runner
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class Bonus : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collision)
        {
            PickUp pickUp = collision.GetComponent<PickUp>();

            if (pickUp != null && pickUp.Mode == PickUp.PickUpMode.AddScore)
            {
                OnPickeUp();

                Destroy(gameObject);

                Sounds.Instance.PlaySounds(Sounds.Instance.AudioClipPickUp);
            }

            if (pickUp != null && pickUp.Mode == PickUp.PickUpMode.Destroy)
            {
                Destroy(gameObject);

                LevelSequenceController.Instance?.FinishCurrentLevel(false);
            }
        }

        protected abstract void OnPickeUp();
    }
}