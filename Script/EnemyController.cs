using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float rotateSpeed = 3.0F;
    float maxDistance = 150f;
    float minDistance = 18f;
    public int enemy1Health;
    bool isDead;

    public GameObject character;
    string[] animationNames = new string[5];
    Animation anim;
    Transform enemy;
    Transform player;

    float speed = 0.009f;

	void Start () {
        anim = character.GetComponent<Animation>();
        int i = 0;
        string temp;
        isDead = false;
        foreach (AnimationState state in anim)
        {
            temp = state.name;
            animationNames[i] = temp;
            i++;
        }
	}

    void Awake()
    {
        enemy = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        checkHealth();
        if(Vector3.Distance(enemy.position,player.position) <= maxDistance){
            if (Vector3.Distance(enemy.position, player.position) <= minDistance)
            {
                anim.Play(animationNames[0]);
            }
            else
            {
                checkHealth();
                if (isDead)
                    return;
                else
                {
                    enemy.LookAt(player.position);
                    anim["Attack"].speed = 0.3f;
                    anim.Play(animationNames[1]);
                    transform.position = Vector3.Lerp(enemy.position, player.position, speed);
                }
            }
        }
    }

    void checkHealth()
    {
        if (enemy1Health <= 0)
        {
            isDead = true;
            anim.Play(animationNames[4]);
            StartCoroutine(wait());
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Throwable")
        {
                anim.Play(animationNames[3]);
                StartCoroutine(wait());
                enemy1Health--;

        }
    }

    /*void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall")
            Debug.Log("wall");
    }*/

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        if (isDead)
            Destroy(character);
        else
            anim.Play(animationNames[0]);
    }
}
