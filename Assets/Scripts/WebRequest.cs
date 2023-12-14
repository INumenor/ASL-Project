using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using Unity.VisualScripting;

public class WebRequest : MonoBehaviour
{
    [SerializeField] public string[] text;
    [SerializeField] GameObject[] HandSign;
    string[] SignAlphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "S", "U", "V", "W", "X", "Y" };
    string sign;
    bool isTrue;
    float fTime = 5;

    private void Update()
    {
        fTime -= Time.deltaTime;
        if (fTime <= 0)
        {
        StartCoroutine(GetRequest("http://127.0.0.1:5000/predict"));

        if (sign == text[1])
            {
               OnClick();
            }
            fTime = 5;
        }
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;
            text = webRequest.downloadHandler.text.ToString().Split(":");
            if (text[1] != null) 
            {
            Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text + text[1]);
            }
        }
    }

    [ContextMenu("aaa")]
    public void OnClick()
    {
        foreach (GameObject obj in HandSign)
        {
            obj.active = false;
        }
        int RastgeleSayi = Random.RandomRange(1, 23);
        sign = SignAlphabet[RastgeleSayi];
        foreach (GameObject obj in HandSign)
        {
            if (sign == obj.name)
            {
                obj.active = true;
            }
        }
    }

}
