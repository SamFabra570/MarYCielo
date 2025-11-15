using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Candle : MonoBehaviour
{
    public Light candle;

    [SerializeField] private float maxInterval = 1;

    private float targetIntensity;
    private float lastIntensity;
    private float interval;
    private float timer;
    
    [SerializeField] private float maxDisplacement = 0.25f;
    private Vector3 targetPos;
    private Vector3 lastPos;
    private Vector3 origin;
    
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        lastPos = origin;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > interval)
        {
            lastIntensity = candle.intensity;
            targetIntensity = Random.Range(0.5f, 1f);
            timer = 0;
            interval = Random.Range(0, maxInterval);
            
            targetPos = origin + Random.insideUnitSphere * maxDisplacement;
            lastPos = candle.transform.position;
        }
        
        candle.intensity = Mathf.Lerp(lastIntensity, targetIntensity, timer / interval);
        candle.transform.position = Vector3.Lerp(lastPos, targetPos, timer / interval);
    }
}
