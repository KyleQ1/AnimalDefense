using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMGUpgrade : MonoBehaviour
{
    public shooting s; 
    public int price;
    public GameObject money;
    public int level = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void smg(){
        MoneyCounter m = money.GetComponent<MoneyCounter>();
        if (price <= m.amount && s.timeBetweenFiring > 0.05f){
            if(s != null) {s.timeBetweenFiring -= 0.15f;}
            m.buy(price);
            level++;
        }
    }
        
}
