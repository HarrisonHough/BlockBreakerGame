using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BrickBreaker
{
    public class UIControl : MonoBehaviour
    {
        [SerializeField]
        private Text startText;
        // Use this for initialization
        void Start()
        {

        }

        public void HideStartText()
        {
            startText.enabled = false;
        }

        public void EnableStartText()
        {
            startText.enabled = true;
        }
    }
}
