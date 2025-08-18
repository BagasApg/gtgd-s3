using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Chapter1
{
    public class Welcome : MonoBehaviour
    {
        private Text welcomeTextObj;

        public GameObject welcomeCanvas;

        [SerializeField] private string playerName = "dasap";

        // Start is called before the first frame update
        void Start()
        {
            SetInitialReferences();
            WelcomeMesage();


        }

        void SetInitialReferences()
        {
            welcomeTextObj = GameObject.Find("Welcome Text").GetComponent<Text>();
        }

        void WelcomeMesage()
        {

            string welcomeMessage = "Welcome back, " + playerName + "!";
            Debug.Log(welcomeMessage);
            if (welcomeTextObj != null)
            {

                welcomeTextObj.text = welcomeMessage;
            }
            else
            {
                Debug.LogWarning("Not assigned!");
            }
            StartCoroutine(DisableCanvas(3.5f));
        }

        IEnumerator DisableCanvas(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            welcomeCanvas.SetActive(false);
        }
    }
}