using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puan : MonoBehaviour
{
    int puan;
    int enYuksekPuan;

    int altin;
    int enYuksekAltin;

    [SerializeField]
    Text puanText = default;

    [SerializeField]
    Text altinText = default;

    [SerializeField]
    Text oyunBittiPuanText = default;

    [SerializeField]
    Text oyunBittiAltinText = default;

    bool toplama = true;
    // Start is called before the first frame update
    void Start()
    {
        altinText.text = altin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (toplama == true)
        {
        puan = (int)Camera.main.transform.position.y;
        puanText.text ="Puan: " + puan;   
        }
       
    }   

    public void AltinKazan()
    {
        if (toplama == true)
        {
            FindObjectOfType<SesKontrol>().AltinSes();
            altin++;
            altinText.text = altin.ToString();
        }
       
    }

    public void Oyunbitti()
    {
        if (Secenekler.KolayDegerOku() == 1)
        {
            enYuksekPuan = Secenekler.KolayPuanDegerOku();
            enYuksekAltin = Secenekler.KolayAltinDegerOku();
            if (puan > enYuksekPuan)
            {
                Secenekler.KolayPuanDegerAta(puan);
            }
            if (altin > enYuksekAltin)
            {
                Secenekler.KolayAltinDegerAta(altin);
            }
        }

        if (Secenekler.OrtaDegerOku() == 1)
        {
            enYuksekPuan = Secenekler.OrtaPuanDegerOku();
            enYuksekAltin = Secenekler.OrtaAltinDegerOku();
            if (puan > enYuksekPuan)
            {
                Secenekler.OrtaPuanDegerAta(puan);
            }
            if (altin > enYuksekAltin)
            {
                Secenekler.OrtaAltinDegerAta(altin);
            }
        }

        if (Secenekler.ZorDegerOku() == 1)
        {
            enYuksekPuan = Secenekler.ZorPuanDegerOku();
            enYuksekAltin = Secenekler.ZorAltinDegerOku();
            if (puan > enYuksekPuan)
            {
                Secenekler.ZorPuanDegerAta(puan);
            }
            if (altin > enYuksekAltin)
            {
                Secenekler.ZorAltinDegerAta(altin);
            }
        }

        toplama = false;
        oyunBittiPuanText.text = "Puan: " + puan;
        oyunBittiAltinText.text = altin.ToString();

    }
}
