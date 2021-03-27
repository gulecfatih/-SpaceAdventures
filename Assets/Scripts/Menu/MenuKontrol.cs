using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuKontrol : MonoBehaviour
{
    [SerializeField]
    Sprite[] MuzikIkonlar=default;

    [SerializeField]
    Button Muzikbuton=default;

  
    // Start is called before the first frame update
    void Start()
    {
        if (Secenekler.KayitVarmi() == false)
        {
            Secenekler.KolayDegerAta(1);
        }
        if (Secenekler.MuzikKayitVarmi() == false)
        {
            Secenekler.MuzikAcikDegerAta(1);
        }
        MuzikAyarlariniDenetle();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
        
    public void OyunuBaslat()
    {
        SceneManager.LoadScene("Oyun");
    }
    public void Puan()
    {
        SceneManager.LoadScene("Puan");
    }
    public void Ayarlar()
    {
        SceneManager.LoadScene("Ayarlar");
    }
    public void Muzik()
    {
        if (Secenekler.MuzikAcikDegerOku() ==1)
        {
            Secenekler.MuzikAcikDegerAta(0);
            MuzikKontrol.instane.MuzikCal(false);
            Muzikbuton.image.sprite = MuzikIkonlar[0];
        }
        else
        {
            Secenekler.MuzikAcikDegerAta(1);
            MuzikKontrol.instane.MuzikCal(true);
            Muzikbuton.image.sprite = MuzikIkonlar[1];
        }
    }

    void MuzikAyarlariniDenetle()
    {
        if (Secenekler.MuzikAcikDegerOku() == 1)
        {
            MuzikKontrol.instane.MuzikCal(true);
            Muzikbuton.image.sprite = MuzikIkonlar[1];
        }
        else
        {
            MuzikKontrol.instane.MuzikCal(false);
            Muzikbuton.image.sprite = MuzikIkonlar[0];
        }
    }

}
