using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
    public float turnSpeed;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * turnSpeed, Vector3.up) * offset;
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);
    }

}
