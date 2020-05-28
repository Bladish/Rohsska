using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperLantern : MonoBehaviour
{
    [SerializeField]
    float flightSpeed = 2f;
    [SerializeField]
    float maxHeight = 3f;
    float timer = 3f;
    float duration = 1.5f;
    Quaternion start, end;
    float alternate = 1;
    void Update()
    {
        if (transform.position.y < maxHeight)
        {
            transform.Translate(new Vector3(0, flightSpeed/100.0f,  0) * Time.deltaTime, Space.Self);
        }
        if (timer <= duration)
        {
            transform.rotation = Quaternion.Lerp(start, end, timer / duration);
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            start = transform.rotation;
            end = Quaternion.Euler(Random.Range(5.0f, 10.0f) * alternate, 0, 0);
            alternate *= -1;
        }
    }
}