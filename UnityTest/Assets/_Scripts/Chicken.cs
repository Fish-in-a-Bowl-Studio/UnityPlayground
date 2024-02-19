using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{

    public bool isDead = false;

    public delegate void ChickenEvent();
    public event ChickenEvent OnChickenInstanceKilled;
    public static event ChickenEvent OnChickenKilled;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void SetChickenKilled()
    {
        isDead = true;
        if (OnChickenInstanceKilled != null)
        {
            OnChickenInstanceKilled();
            OnChickenKilled();
        }

    }
}
