using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject character;
    private Rigidbody rb;
    string[] animationNames = new string[5];
    Animation anim;

    public Rigidbody projectile;
    public float speed = 20;
    public float timeBetweenBullets = 0.15f;
    float timer;

	// Use this for initialization
	void Start () {
        anim = character.GetComponent<Animation>();
        rb = GetComponent<Rigidbody>();

        int i = 0;
        string temp;
        foreach (AnimationState state in anim)
        {
            temp = state.name;
            animationNames[i] = temp;
            //Debug.Log(state.name);
            i++;
        }
        for (i = 0; i < 5; i++)
        {
            //Debug.Log(animationNames[i]);
        }
	}

	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.Play(animationNames[4]);

            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            //rb.AddForce(movement*25000);
            //rb.velocity = movement*100;
            //GetComponent.<Animation>().CrossFade(animationList[4],0.01);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            anim.Play(animationNames[0]);
            Debug.Log("W was released");

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            transform.position = rb.transform.position;
            transform.LookAt(transform.position + rb.velocity);
            transform.rotation = Quaternion.LookRotation(movement);
            rb.AddForce(movement * 25000);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            anim.Play(animationNames[0]);
            Debug.Log("A was released");

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
	}
}
