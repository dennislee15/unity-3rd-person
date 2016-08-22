using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

    public Rigidbody[] projectile;
    public float speed;
    float timer;
    int index;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        index = Random.Range(0, 6);
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile[index], transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
            
        }
        else
        {
            return;
        }
    }
}
