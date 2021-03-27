using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlumculPlatform : MonoBehaviour
{
    BoxCollider2D BoxCollider2D;

    float randomHiz;
    [SerializeField]
    bool hareket;

    float min, max;
    /// <summary>
    /// hareket değerini alıyor
    /// </summary>
    public bool Hareket
    {
        get
        {
            return hareket;
        }
        set
        {
            hareket = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
        randomHiz = Random.Range(0.5f, 1.0f);
        float objeGenisligi = BoxCollider2D.bounds.size.x / 2;

        if (transform.position.x > 0)
        {
            min = objeGenisligi;
            max = EkranHesaplayicisi.instance.Genislik - objeGenisligi;
        }
        else
        {
            min = -EkranHesaplayicisi.instance.Genislik + objeGenisligi;
            max = -objeGenisligi;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hareket)
        {
            float pingPongX = Mathf.PingPong(Time.time * randomHiz, max - min) + min;
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
            transform.position = pingPong;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ayaklar"){
            FindObjectOfType<OyunKontrol>().OyunuBitir();
        }
    }
}
