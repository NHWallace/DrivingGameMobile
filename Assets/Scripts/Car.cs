using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float speedGainPerSecond = 0.2f;
    [SerializeField] private float turnSpeed = 200f;

    public int steerValue;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        transform.Rotate(0f, turnSpeed * steerValue * Time.deltaTime, 0f);

        speed += speedGainPerSecond * Time.deltaTime;
    }

    public void SetSteer(int value)
    {
        steerValue = value;
    }
}
