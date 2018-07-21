using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Localizator : MonoBehaviour {

    public bool debugEn;

    public Font ruFont;
    public Font enFont;

    public int ruFontSize;
    public int enFontSize = 21;

    public string ruText;
    public string enText;

    private Text text;

    void Update()
    {
        text = GetComponent<Text>();
        if (text)
        {
            text.text = Application.systemLanguage == SystemLanguage.Russian && !debugEn ? ruText : enText;
            text.font = Application.systemLanguage == SystemLanguage.Russian && !debugEn ? ruFont : enFont;
            text.fontSize = Application.systemLanguage == SystemLanguage.Russian && !debugEn ? ruFontSize : enFontSize;
        }

    }
	
}
