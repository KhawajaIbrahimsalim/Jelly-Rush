using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Tail;
    public GameObject Head;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        Add_BodyParts();
    }

    public void Add_BodyParts()
    {
        // Spawn new body part
        Vector3 pos = new Vector3(Head.transform.position.x, Head.transform.position.y, Head.transform.position.z - 1.3f);
        GameObject tail = Instantiate(Tail, pos, Head.transform.rotation);

        // Set Parent
        tail.transform.SetParent(Head.transform);

        // Set Target to follow
        tail.GetComponent<TailMechanic>().target = Head.transform.GetChild(Head.transform.childCount - 2);
    }
}
