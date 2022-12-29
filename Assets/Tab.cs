using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tab : MonoBehaviour
{
    public string fullName;
    public string occupation;
    public string house;
    public bool hasCar;

    public int age;
    public int income;
    public int debt;

    public string city;
    public string country;
    public string address;
    public string postalCode;

    public Color favouriteColor;
    public string favouriteAnimal;
    public int favouriteNumber;

    public string username;
    public string password;

    [HideInInspector]
    public int toolbarTabTop;
    public int toolbarTabBottom;
    public string currentTab;
}
