using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class block : MonoBehaviour
{
    public event UnityAction<block> BulletHit;
    public void Break() // метод который ломает блок
    {
        BulletHit?.Invoke(this);//? 
        Destroy(gameObject);
    }
}
