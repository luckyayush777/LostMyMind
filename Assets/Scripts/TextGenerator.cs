using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextGenerator : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI wordText;
    const string glyph = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    public void GenerateWord()
    {
        wordText.text = null;
        for(int i = 0; i < 3; i++)
        {
            wordText.text += glyph[Random.Range(0, 26)];
        }
    }

   


}
