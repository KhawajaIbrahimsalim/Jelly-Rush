using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float FollowSpeed;

    private GameObject Head;

    // Start is called before the first frame update
    void Start()
    {
        Head = GameObject.Find("Head");
    }

    // Update is called once per frame
    void Update()
    {
        if (Head != null)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(Head.transform.position.x, 10, Head.transform.position.z - 10), FollowSpeed);
        }
    }
}
