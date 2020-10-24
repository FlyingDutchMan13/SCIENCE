using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICounter : MonoBehaviour
{
    public Text displayText;

    public void UpdateText(int number, string word)
    {
        displayText.text = word + ": " + number;
    }
    
    
}
