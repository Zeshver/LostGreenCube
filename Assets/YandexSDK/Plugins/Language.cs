using System.Runtime.InteropServices;
using UnityEngine;

namespace Runner
{
    public class Language : SingletonBase<Language>
    {
        [DllImport("__Internal")]
        private static extern string GetLang();

        public string CurrentLanguage;

        protected override void Awake()
        {
            base.Awake();

            CurrentLanguage = GetLang();
        }
    }
}