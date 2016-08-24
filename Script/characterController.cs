using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour {
    public float speed;
    public float rotateSpeed;
    public float knockback = 300.0F;
    public int enemy1Damage;

    public GameObject character;
    string[] animationNames = new string[5];
    Animation anim;
    CharacterController controller;
    public playerHealth health;

    // Use this for initialization
    void Start()
    {
        anim = character.GetComponent<Animation>();
        controller = GetComponent<CharacterController>();

        int i = 0;
        string temp;
        foreach (AnimationState state in anim)
        {
            temp = state.name;
            animationNames[i] = temp;
            i++;
        }
        health.Start();
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
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            anim.Play(animationNames[0]);
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            speed = 50f;
        if (Input.GetKeyDown(KeyCode.Space))
            playAnimation(1);
        moveCharacter(speed);
    }

    void playAnimation(int idx)
    {
        anim.PlayQueued(animationNames[idx]);
        StartCoroutine(WaitForAnimation(anim));
        anim.Play(animationNames[idx]);
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
        controller.SimpleMove(forward * curSpeed);
    }

    void playerDeath()
    {
        playAnimation(3);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Enemy")
        {
            playAnimation(2);

            health.loseHealth(enemy1Damage);
            if (health.checkHealth())
            {
                playerDeath();
            }
            Transform chara = GetComponent<Transform>();
            Vector3 newPosition = chara.position;
            newPosition -= new Vector3(knockback,0,knockback);

            chara.position = Vector3.Lerp(chara.position, newPosition, 0.005f);
        }
    }
}
