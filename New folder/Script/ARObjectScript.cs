using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObjectScript : MonoBehaviour
{
    public AudioSource Backsound;
    public GameObject Logo;
    public float minTime, maxTime, timer;
    public bool blinking;
    // Start is called before the first frame update
    void Start()
    {
        minTime=0.1f;
        maxTime=1.2f;
        timer =Random.Range(minTime,maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        blinkingfunction();
    }
    public void ImageFound()
    {
        Backsound.Play();
    }
    public void ImageLost()
    {
        Backsound.Stop();
    }
    void blinkingfunction()
    {
        if (timer>0){
            timer -= Time.deltaTime;
        }
        if (timer<=0){
            if (blinking==true){
            Logo.SetActive(false);
            blinking=false;}
            else{
            Logo.SetActive(true); 
            blinking=true; 
            }
            timer= Random.Range(minTime,maxTime);
        }
    }
}
