using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Weapon", menuName ="ScritableObjects/Weapon", order = 1)]
public class Weapon : ScriptableObject
{
    

    public enum WeaponType
    {
        Physical,
        Magic
    }

    public string weaponName;
    public WeaponType weapinType;
    public int weaponPower;


}
