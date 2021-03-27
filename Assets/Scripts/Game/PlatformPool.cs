using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformPool : MonoBehaviour
{
    [SerializeField]
    GameObject dostPlatformPrefab=default;
    [SerializeField]
    GameObject olumculPlatformPrefab = default;

    [SerializeField]
    GameObject playerPrefab = default;

    List<GameObject> platforms = new List<GameObject>();
    Vector2 platformPozisyon;
    Vector2 playerPozisyon;
    
    [SerializeField]
    float PlatformlarArasiMesafe = default;
    // Start is called before the first frame update
    void Start()
    {
        PlatformUret();
    }

    // Update is called once per frame
    void Update()
    {
        if(platforms[platforms.Count-1].transform.position.y<
            Camera.main.transform.position.y + EkranHesaplayicisi.instance.Yukseklik)
        {
            PlatformYerlestir();
        }
    }

    void PlatformYerlestir()
    {
        for(int i = 0; i < 5; i++)
        {
            GameObject temp;
            temp= platforms[i + 5];
            platforms[i + 5] = platforms[i];
            platforms[i]= temp;
            platforms[i + 5].transform.position = platformPozisyon;
                if(platforms[i + 5].gameObject.tag == "Platform")
                {
                    platforms[i + 5].GetComponent<Altin>().AltinKapa();
                    float rastgeleAltin = Random.Range(0f, 1f);
                    if (rastgeleAltin > 0.6)
                    {
                        platforms[i + 5].GetComponent<Altin>().AltinAc();
                    }
                }
            SonrakiPlatfrom();

        }
        
    }
    void PlatformUret()
    {
        platformPozisyon = new Vector2(0, 0);
        playerPozisyon = new Vector2(0, 0.5f);

        GameObject player = Instantiate(playerPrefab, playerPozisyon, Quaternion.identity);
        GameObject ilkPlatform = Instantiate(dostPlatformPrefab, platformPozisyon, Quaternion.identity);
        ilkPlatform.GetComponent<Platform>().Hareket = true;
        player.transform.parent = ilkPlatform.transform;
        platforms.Add(ilkPlatform);
        SonrakiPlatfrom();
        
      
        for(int i = 0; i < 8; i++)
        {
            GameObject platform =Instantiate(dostPlatformPrefab, platformPozisyon, Quaternion.identity);
            platforms.Add(platform);
            platform.GetComponent<Platform>().Hareket = true;
            if (i % 2 != 0)
            {
                platform.GetComponent<Altin>().AltinAc();
            }
            SonrakiPlatfrom();
        }

        GameObject olumculPlatform = Instantiate(olumculPlatformPrefab, platformPozisyon, Quaternion.identity);
        platforms.Add(olumculPlatform);
        olumculPlatform.GetComponent<OlumculPlatform>().Hareket = true;
        SonrakiPlatfrom();

    }

    private void SonrakiPlatfrom()
    {
        platformPozisyon.y += PlatformlarArasiMesafe;
        float random = Random.Range(0.0f, 1.0f);
        if (random < 0.5)
        {
            platformPozisyon.x = EkranHesaplayicisi.instance.Genislik / 2;
        }
        else
        {
            platformPozisyon.x = -EkranHesaplayicisi.instance.Genislik / 2;
        }

    }
}
