using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChanger : MonoBehaviour
{
    private Light pointLight;
    private Color[] colors = { Color.blue, Color.magenta, Color.red, Color.yellow, Color.green, Color.cyan};
    void Start()
    {
        pointLight = GetComponent<Light>();
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        while (true)
        {
            for (int i = 0; i < colors.Length; i++)
            {
                pointLight.color = colors[i];
                yield return new WaitForSeconds(0.3f);
            }               
        }
    }
}
