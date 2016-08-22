using UnityEngine;
using System.Collections;

public class shotScript : MonoBehaviour {

    Transform enemyTransform;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //Debug.Log("Hit!");
            Destroy(gameObject);
            enemyTransform = col.gameObject.GetComponent<Transform>();
            enemyTransform.localScale += new Vector3(.1f, .1f, .1f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
