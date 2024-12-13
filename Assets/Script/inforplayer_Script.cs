using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inforplayer_Script : MonoBehaviour
{
    public int maxheath = 100;
    public int currentheath;
    
    // Start is called before the first frame update
    void Start()
    {
        currentheath = maxheath;
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void TakeDamage( int damage)
    {
        currentheath -= damage;
        Debug.Log("player taked " + damage+" damage");
        if(currentheath <= 0)
        {
            currentheath = 0;
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("player has die!!!");
    }
}
