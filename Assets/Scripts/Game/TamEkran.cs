using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamEkran : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Vector2 tempScale = transform.localScale;

        float spriteGenislik = spriteRenderer.size.x;
        float ekranYuksekligi = Camera.main.orthographicSize * 2.0f;
        float ekranGenisligi = ekranYuksekligi / Screen.height * Screen.width;
        tempScale.x = ekranGenisligi / spriteGenislik;
        transform.localScale = tempScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
