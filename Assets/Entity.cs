using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public EntityManager.Handle handle;

    public void SetHandle(EntityManager.Handle handle)
    {
        this.handle = handle;
    }
}


public class Resident : Entity
{
    public string name;
    public int age;
    public Building home;
}


public class Building : Entity
{
    public string name;
    public int age;
    public int total;
    public int totalResidentialUnits;
   // public GameObject home;
}