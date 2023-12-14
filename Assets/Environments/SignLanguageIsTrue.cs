using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignLanguageIsTrue : MonoBehaviour
{
    [SerializeField] GameObject[] HandSign;
    string[] SignAlphabet = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","S","U","V","W","X","Y"};
    public void OnClick()
    {
        foreach (GameObject obj in HandSign)
        {
            obj.active = false;
        }
        int RastgeleSayi = Random.RandomRange(1, 23);
        string sign = SignAlphabet[RastgeleSayi];
        foreach (GameObject obj in HandSign)
        {
            if (sign == obj.name)
            {
                obj.active = true;
            }
        }
    }
}
