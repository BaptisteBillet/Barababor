using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FPSDisplay : MonoBehaviour
{
    float deltaTime = 0.0f;

    Text m_text;
    Color red;
    Color green;
    Color yellow;
    
    void Start()
    {
        m_text = GetComponent<Text>();
        red = Color.red;
        green = Color.green;
        yellow = Color.yellow;
    }

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        
        if(fps<60)
        {
            m_text.color = yellow;

            if(fps<30)
            {
                m_text.color = red;
            }
        }
        else
        {
            m_text.color = green;
        }

        m_text.text= string.Format("{1:0.}", msec, fps);
    }

    /*
    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }*/
}