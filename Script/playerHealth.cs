using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

    public Text health;
    public int totalHealth;

	// Use this for initialization
	public void Start () {
        health.text = "Health: " + totalHealth;
	}
	
    public void loseHealth(int loss)
    {
        if(totalHealth > 0)
            totalHealth -= loss;
        health.text = "Health: " + totalHealth;
    }

    public bool checkHealth()
    {
        if (totalHealth <= 0)
            return true;
        return false;
    }
}
