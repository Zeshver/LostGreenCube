using UnityEngine;
using TMPro;

namespace Runner
{
    public class InternationalText : MonoBehaviour
    {
        [SerializeField] string _en;
        [SerializeField] string _ru;

        private void Start()
        {
            if (Language.Instance.CurrentLanguage == "en")
            {
                GetComponent<TextMeshProUGUI>().text = _en;
            }
            else if (Language.Instance.CurrentLanguage == "ru")
            {
                GetComponent<TextMeshProUGUI>().text = _ru;
            }
            else
            {
                GetComponent<TextMeshProUGUI>().text = _en;
            }
        }
    }
}