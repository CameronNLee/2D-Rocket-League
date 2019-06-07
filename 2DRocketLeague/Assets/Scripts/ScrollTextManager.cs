using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollTextManager : MonoBehaviour
{
    private static ScrollTextManager instance;

    public GameObject textPrefab;

    public RectTransform canvasTransform;

    public float speed;

    public float fadeTime;

    public Vector3 direction;

    public static ScrollTextManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<ScrollTextManager>();
            }
            return instance;
        }
    }

    public void CreateText(Vector3 position, string text, Color color, int fontsize)
    {
        GameObject sct = (GameObject)Instantiate(textPrefab, position, Quaternion.identity);
        sct.transform.SetParent(canvasTransform);
        sct.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        sct.GetComponent<ScrollText>().Initialize(speed, direction, fadeTime);
        sct.GetComponent<Text>().text = text;
        sct.GetComponent<Text>().color = color;
        sct.GetComponent<Text>().fontSize = fontsize;
    }
}
