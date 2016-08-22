using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour {
    public float speed;
    public float rotateSpeed = 3.0F;

    public GameObject character;
    string[] animationNames = new string[5];
    Animation anim;
    CharacterController controller;
    Rigidbody body;
    Vector3 impact = Vector3.zero;
    public int mass;

    // Use this for initialization
    void Start()
    {
        anim = character.GetComponent<Animation>();
        controller = GetComponent<CharacterController>();
        body = GetComponent<Rigidbody>();

        int i = 0;
        string temp;
        foreach (AnimationState state in anim)
        {
            temp = state.name;
            animationNames[i] = temp;
            //Debug.Log(state.name);
            i++;
        }
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            anim.Play(animationNames[4]);
            speed = 100F;
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            anim.Play(animationNames[4]);
            speed = 50F;
        }
        if (Input.GetKeyUp(KeyCode.W))
            anim.Play(animationNames[0]);
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            speed = 50f;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.PlayQueued( animationNames[1] );
            StartCoroutine(WaitForAnimation(anim));
            anim.Play(animationNames[1]);
        }
        moveCharacter(speed);
    }

    private IEnumerator WaitForAnimation(Animation animation)
    {
        do
        {
            yield return null;
        } while (animation.isPlaying);
    }

    void moveCharacter(float moveSpeed)
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = moveSpeed * Input.GetAxis("Vertical");
        //Debug.Log(curSpeed);
        controller.SimpleMove(forward * curSpeed);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Enemy")
        {
            //Debug.Log("Hit enemy");
            anim.PlayQueued(animationNames[2]);
            StartCoroutine(WaitForAnimation(anim));
            anim.Play(animationNames[2]);
            controller.detectCollisions = true;

            /*Transform chara = GetComponent<Transform>();
            Vector3 newPosition = chara.position;
            newPosition -= new Vector3(200f,0,200f);
            chara.position = Vector3.Lerp(chara.position, newPosition, 0.05f);*/
        }
    }
}
