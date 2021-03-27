using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuanKontrol : MonoBehaviour
{
    public Text kolayPuan, kolayAltin, ortaPuan, ortaAltin, zorPuan, zorAltin;
    void Start()
    {
        kolayPuan.text = "Puan: " + Secenekler.KolayPuanDegerOku();
        kolayAltin.text = Secenekler.KolayAltinDegerOku().ToString();

        ortaPuan.text = "Puan: " + Secenekler.OrtaPuanDegerOku();
        ortaAltin.text = Secenekler.OrtaAltinDegerOku().ToString();

        zorPuan.text = "Puan: " + Secenekler.ZorPuanDegerOku();
        zorAltin.text = Secenekler.ZorAltinDegerOku().ToString();
    }

    public void AnaMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
