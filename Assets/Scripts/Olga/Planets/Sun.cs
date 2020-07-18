using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : Planet
{

    // I can have a light component
    // I can make light intensity and colour 
    // related to height  (y value)
    Light light;

    [SerializeField]
    float intensityMultiplier;
    [SerializeField]
    float highestPoint;
    [SerializeField]
    float currentAltitude;

    [SerializeField]
    Color sunZenithColor;
    [SerializeField]
    Color sunSetColor;

    // Start is called before the first frame update
    override public void Start()
    {
        base.Start();
        light = GetComponent<Light>();
        highestPoint = centerOfOrbit.position.y + orbitRadius;
    }

    // Update is called once per frame
    override public void Update()
    {
        base.Update();
        SetLightIntensityAccordingToPositionInSky();
    }

    void SetLightIntensityAccordingToPositionInSky()
    {
        currentAltitude = transform.position.y - centerOfOrbit.position.y;
        if (currentAltitude > 0)
        {
            light.intensity = intensityMultiplier * currentAltitude;
            float t = currentAltitude / highestPoint;
            light.color = Color.Lerp(sunSetColor, sunZenithColor, t); 
        }
    }


}
