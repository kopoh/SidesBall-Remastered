using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScript : MonoBehaviour
{
    [SerializeField] private Material ObstacleMat;
    public int speed = 1;
    public Color obscolor;
    
    public Color[] colors;
    public float duration = 3.0f;
    
    private int index = 0;
    private float timer = 0.0f;
    private Color currentColor;
    void Start()
    {
        //StartCoroutine(ColorChanger());
    }

    private void Update()
    {
        // мы тут меняем цвет на рандомный, как в том меме с думгаем (DoomGuy) который работает под анимешную музыку в шлеме
        
            currentColor = Color.Lerp(obscolor, colors[index], timer);

            timer += Time.deltaTime / duration;
            if (timer > 1.0f)
            {
                timer -= 1.0f;
                index++;
                if (index >= colors.Length)
                    index = 0;
                obscolor = currentColor;
                //ObstacleMat.SetColor("_Color", currentColor);
            }
            ObstacleMat.SetColor("_Color", currentColor);
    }

    /*public IEnumerator ColorChanger()
    {
        while (true) // мы тут меняем цвет на рандомный, как в том меме с думгаем (DoomGuy)
        {
            currentColor = Color.Lerp(obscolor, colors[index], timer);
        
            timer += Time.deltaTime / duration;
            if(timer > 1.0f)
            {
                timer -= 1.0f;
                index++;
                if(index >= colors.Length)
                    index = 0;
                obscolor = currentColor;
                ObstacleMat.SetColor("_Color", obscolor);
            }
            
            //Color obscolor = (new Color(Random.value, Random.value, Random.value, 1));
            
            //ObstacleMat.SetColor("_Color", obscolor);
            Debug.Log(obscolor);
            //yield return new WaitForSeconds(speed);
        }
    }*/
}
