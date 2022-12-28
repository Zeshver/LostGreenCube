using System.Collections;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Runner
{
    public class Yandex : SingletonBase<Yandex>
    {
        [DllImport("__Internal")]
        private static extern void Hello();

        [DllImport("__Internal")]
        private static extern void RateGame();

        [DllImport("__Internal")]
        private static extern void GetTypePlatformDevice();

        [SerializeField] private TextMeshProUGUI m_NameText;
        [SerializeField] private RawImage m_Photo;

        private void Start()
        {
            GetPlatformDevice();
        }

        public void RateGameButton()
        {
            RateGame();
        }

        public void GetPlatformDevice()
        {
            GetTypePlatformDevice();
        }

        public void SetPlatformDevice(string typeDevice)
        {
            switch (typeDevice)
            {
                case "desktop":
                    //MovementController.Instance.m_ControlMode = MovementController.ControlMode.Keyboard;
                    break;
                case "mobile":
                    //MovementController.Instance.m_ControlMode = MovementController.ControlMode.Mobile;
                    break ;
                case "tablet":
                    //MovementController.Instance.m_ControlMode = MovementController.ControlMode.Mobile;
                    break;
                default:
                    //MovementController.Instance.m_ControlMode = MovementController.ControlMode.Mobile;
                    break;
            }
        }
    }
}
