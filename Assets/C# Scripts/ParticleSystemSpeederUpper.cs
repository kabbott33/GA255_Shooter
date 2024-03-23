using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{

    private ParticleSystem ps;
    public float hSliderValue = 1.0F;
    public float singularity;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        singularity = singularity * 1.001f;
        //this.transform.Rotate(0, 0.1f * spinSpeed, 0.1f * spinSpeed);
        //this.transform.Rotate(0.1f * spinSpeed, 0.1f * spinSpeed, 0);
        var main = ps.main;
        main.simulationSpeed = hSliderValue*singularity;
    }

    void OnGUI()
    {
        hSliderValue = GUI.HorizontalSlider(new Rect(25, 45, 100, 30), hSliderValue, 0.0F, 5.0F);
    }
}