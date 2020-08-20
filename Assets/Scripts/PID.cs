using UnityEngine;

[System.Serializable]
public class PID
{
    public float Kp = 0.8f;
    public float Ki = 0.1f;
    public float Kd = 0.1f;
    public float Minimum = -1;
    public float Maximum = 1;

    public PID(float pCoefficient, float iCoefficient, float dCoefficient)
    {
        Kp = pCoefficient;
        Ki = iCoefficient;
        Kd = dCoefficient;
    }

    float integral;
    float lastProportional;

    public float Control(float targetValue, float currentValue)
    {
        float deltaTime = Time.fixedDeltaTime;
        float proportional = targetValue - currentValue;

        float derivative = ( proportional - lastProportional ) / deltaTime;
        integral += proportional * deltaTime;
        lastProportional = proportional;

        float value = Kp * proportional + Ki * integral + Kd * derivative;
        value = Mathf.Clamp( value, Minimum, Maximum );

        return value;
    }
}