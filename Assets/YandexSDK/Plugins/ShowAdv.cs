using System.Runtime.InteropServices;
using UnityEngine;

namespace Runner
{
    public class ShowAdv : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern void Help();

        [SerializeField] private GameObject[] m_HelpPanel;

        public void OnButtonHelp()
        {
            Help();
        }

        public void OpenHelpPanel()
        {
            foreach (var panel in m_HelpPanel)
            {
                panel.SetActive(true);
            }
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void PlayGame()
        {
            Time.timeScale = 1;
        }
    }
}