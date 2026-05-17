using UnityEngine;

public class Jajo : MonoBehaviour
{
    public GameObject Jajo1;
    public GameObject Jajo2;
    public GameObject Jajo3;
    public GameObject Jajo1_gniazdo;
    public GameObject Jajo2_gniazdo;
    public GameObject Jajo3_gniazdo;
    public GameObject Jajo1_baza;
    public GameObject Jajo2_baza;
    public GameObject Jajo3_baza;
    void Start()
    {
        Jajo1.SetActive(false);
        Jajo2.SetActive(false);
        Jajo3.SetActive(false);
        Jajo1_baza.SetActive(false);
        Jajo2_baza.SetActive(false);
        Jajo3_baza.SetActive(false);
        Jajo1_gniazdo.SetActive(true);
        Jajo2_gniazdo.SetActive(true);
        Jajo3_gniazdo.SetActive(true);
    }

    public void Egg1_pickup()
    {
        Jajo1.SetActive(true);
        Jajo1_gniazdo.SetActive(false);
        Jajo1_baza.SetActive(false);
    }
    public void Egg2_pickup()
    {
        Jajo2.SetActive(true);
        Jajo2_gniazdo.SetActive(false);
        Jajo2_baza.SetActive(false);
    }
    public void Egg3_pickup()
    {
        Jajo3.SetActive(true);
        Jajo3_gniazdo.SetActive(false);
        Jajo3_baza.SetActive(false);
    }

    public void Egg1_PutDown()
    {
        Jajo1.SetActive(false);
        Jajo1_gniazdo.SetActive(false);
        Jajo1_baza.SetActive(true);
    }
    public void Egg2_PutDown()
    {
        Jajo2.SetActive(false);
        Jajo2_gniazdo.SetActive(false);
        Jajo2_baza.SetActive(true);
    }
    public void Egg3_PutDown()
    {
        Jajo3.SetActive(false);
        Jajo3_gniazdo.SetActive(false);
        Jajo3_baza.SetActive(true);
    }
}
