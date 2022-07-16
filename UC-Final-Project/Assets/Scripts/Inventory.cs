using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject KeyTxt;
    public GameObject FuelTxt;
    public GameObject KeyFound;
    public GameObject FuelFound;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    public AudioSource TalaVroom;

    bool KeyFlag = false;
    bool FuelFlag = false;
    public void Start()
    {
        KeyTxt.SetActive(true);
        FuelTxt.SetActive(true);
        KeyFound.SetActive(false);
        FuelFound.SetActive(false);
        WinScreen.SetActive(false);
        LoseScreen.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.tag == "Collectible")
        {
            Collect(other.GetComponent<Collectible>());
        }
        if (FuelFlag && KeyFlag && other.gameObject.tag == "Car")
        {
            Debug.Log("VROOM VROOM");
            WinScreen.SetActive(true);
            TalaVroom.Play();
        }
        if (other.gameObject.tag == "Enemy")
        {
            LoseScreen.SetActive(true);
        }
    }

    private void Collect(Collectible collectible)
    {
        if (collectible.Collect())
        {
            if (collectible is Key)
            {
                //Debug.Log("Key found");
                KeyTxt.SetActive(false);
                KeyFound.SetActive(true);
                 KeyFlag = true;

            }
            else if (collectible is Fuel)
            {
                //Debug.Log("Fuel found");
                FuelTxt.SetActive(false);
                FuelFound.SetActive(true);
                FuelFlag = true;

            }
        }
    }

}
