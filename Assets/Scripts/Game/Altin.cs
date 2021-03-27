using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altin : MonoBehaviour
{
    [SerializeField]
    GameObject altin = default;
    // Start is called before the first frame update
    public void AltinAc()
    {
        altin.SetActive(true);
    }
    public void AltinKapa()
    {
        altin.SetActive(false);
    }

}
