using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    private Material TrailMat;
    private Material BallMat;
    private Material CylinderMat;
    public Color BallColor;
    public Color TrailColor;
    public Color CylinderColor;
    public GameObject Cylinder;

    public void Start()
    {
        TrailMat = gameObject.GetComponent<TrailRenderer>().material;
        BallMat = gameObject.GetComponent<Renderer>().material;
        CylinderMat = Cylinder.GetComponent<Renderer>().material;
        TrailMat.SetColor("_EmissionColor", TrailColor);
        TrailMat.SetColor("_Color", TrailColor);
        BallMat.SetColor("_Color", BallColor);
        BallMat.SetColor("_EmissionColor", BallColor);
        CylinderMat.SetColor("_Color", CylinderColor);
        CylinderMat.SetColor("_EmissionColor", CylinderColor);
    }
 
    /*public IEnumerator ColorChanger()
    {
        while (true) // мы тут меняем цвет на рандомный, как в том меме с думгаем (DoomGuy)
        {
            TrailColor = (new Color(Random.value, Random.value, Random.value, 1));
            Debug.Log("Хуй" + 1);
            yield return new WaitForSeconds(speed);
        }
    }*/
}
