using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OyunKontrol : MonoBehaviour
{
    public GameObject oyunBittiPanel;
    public GameObject joystick;
    public GameObject ziplamaButtonu;
    public GameObject tabela;
    public  GameObject slider;
    public GameObject menuButtonu;
    // Start is called before the first frame update
    void Start()
    {
        oyunBittiPanel.SetActive(false);
        UIAc();
    }

  
    public void OyunuBitir()
    {
        FindObjectOfType<SesKontrol>().OyunBittiSes();
        oyunBittiPanel.SetActive(true);
        UIKapa();
        FindObjectOfType<KameraHareketi>().OyunBitti();
        FindObjectOfType<OyuncuHareket>().OyunBitti();
        FindObjectOfType<Puan>().Oyunbitti();
    }

    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("Menu");
    }

    public void TekrarOyna()
    {
        SceneManager.LoadScene("Oyun");
    }
    public void UIAc()
    {
        joystick.SetActive(true);
        ziplamaButtonu.SetActive(true);
        tabela.SetActive(true);
        slider.SetActive(true);
        menuButtonu.SetActive(true);
    }
    public void UIKapa()
    {
        joystick.SetActive(false);
        ziplamaButtonu.SetActive(false);
        tabela.SetActive(false);
        slider.SetActive(false);
        menuButtonu.SetActive(false);
    }
}
