using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField]
    private int minutes;
    [SerializeField]
    private int sec;
    public Text textbox;

    // Start is called before the first frame update
    void Start()
    {
        SetText();
        StartCoroutine(Second());
    }

    // Update is called once per frame
    void Update()
    {
        if(sec == 0 && minutes == 0)
        {
            textbox.text = "00:00";
            StopCoroutine(Second());
        }
    }

    IEnumerator Second()
    {
        yield return new WaitForSeconds(1f);

        if (sec == 0 && minutes != 0)
        {
            sec = 60;
            minutes--;
        }
        if (sec > 0)
        {
            sec--;
        }

        SetText();
        StartCoroutine(Second());
    }

    void SetText()
    {
        if (minutes >= 10)
        {
            if (sec >= 10)
            {
                textbox.text = "0" + minutes + ":" + sec;
            }
            else
            {
                textbox.text = "0" + minutes + ":0" + sec;
            }
        }
        else
        {
            if (minutes < 1)
            {
                textbox.color = Color.red;
            }
            if (sec >= 10)
            {
                textbox.text = "0" + minutes + ":" + sec;
            }
            else
            {
                textbox.text = "0" + minutes + ":0" + sec;
            }
        }
    }
}
