using System.Collections;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Runner
{
    public class GetPlayerDataMainMenu : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern void GetPlayerData();

        [SerializeField] private TextMeshProUGUI m_NameText;
        [SerializeField] private RawImage m_Photo;

        private void Start()
        {
            GetPlayerData();
        }

        public void SetName(string name)
        {
            m_NameText.text = name;
        }

        public void SetPhoto(string url)
        {
            StartCoroutine(DownloadImage(url));
        }

        IEnumerator DownloadImage(string mediaUrl)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
            }
            else
            {
                m_Photo.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            }
        }
    }
}