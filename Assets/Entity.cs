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
