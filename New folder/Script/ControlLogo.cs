using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLogo :  MonoBehaviour
{
    private Touch touch;
    private Vector2 touchPosition;
    private Quaternion rotationY,rotationX;
    public float rotateSpeed = 0.1f, _currentScale,_temp,_scalingRate = 100;
    public float minScale, maxScale;

    void Start()
    {
        _currentScale = transform.localScale.x;
        minScale = _currentScale;
        maxScale = minScale*4;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount>0)
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                rotationY=Quaternion.Euler(touch.deltaPosition.y*rotateSpeed,-touch.deltaPosition.x*rotateSpeed,0f);
                transform.rotation =rotationY*transform.rotation;
            }
        }
        if(Input.touchCount==2)
        {
            transform.localScale = new Vector3(_currentScale, _currentScale,_currentScale);
                float distance = Vector3.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                if (_temp > distance) {
                    if (_currentScale < minScale)
                        return;
                    _currentScale -= (Time.deltaTime) * _scalingRate;
                }

                else if (_temp < distance) {
                    if (_currentScale >= maxScale)
                        return;
                    _currentScale += (Time.deltaTime) * _scalingRate;
                }
                _temp = distance;
        }
        
    }
}
