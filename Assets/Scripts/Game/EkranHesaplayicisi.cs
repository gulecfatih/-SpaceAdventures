using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EkranHesaplayicisi : MonoBehaviour
{
    public static EkranHesaplayicisi instance;
    float yukselik,genislik;

    public float Yukseklik
    {
        get
        {
            return yukselik;
        }
    }

    public float Genislik
    {
        get
        {
            return genislik;
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        yukselik = Camera.main.orthographicSize;
        genislik = yukselik* Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
