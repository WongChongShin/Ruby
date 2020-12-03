using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBox : MonoBehaviour
{
    public GameObject item;
    public GameObject tempParent;
    public Transform guide;
    bool carrying;
    bool collidePlayer;
    public float ThrowForce;
    private Rigidbody rbItem;
    Collider collider;
    Collider triggercollider;
    void Start()
    {
        collider = item.GetComponent<Collider>();
        triggercollider = GetComponent<Collider>();
        rbItem = item.GetComponent<Rigidbody>();
        rbItem.useGravity = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (carrying == false && collidePlayer == true)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                pickup();
                collider.enabled = false;
                triggercollider.enabled = false;
                carrying = true;
            }
        }
        else if (carrying == true)
        {
            if (Input.GetButtonDown("Throw"))
            {
                StartCoroutine(wait2());
            }
            IEnumerator wait2()
            {
                yield return new WaitForSeconds(0.5f);
                collider.enabled = true;
                triggercollider.enabled = true;
                carrying = false;
                rbItem.useGravity = true;
                rbItem.isKinematic = false;
                item.transform.parent = null;
                collidePlayer = false;
                item.gameObject.tag = "box";
                rbItem.velocity = item.transform.TransformDirection(new Vector3(0, 0, ThrowForce));
                Destroy(item, 3);
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                drop();
                carrying = false;
                StartCoroutine(wait());
            }
            IEnumerator wait()
            {
                yield return new WaitForSeconds(0.5f);
                collidePlayer = false;
            }
        }
    }
    void pickup()
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = guide.transform.position;
        item.transform.rotation = guide.transform.rotation;
        item.transform.parent = tempParent.transform;
    }
    void drop()
    {
        collider.enabled = true;
        triggercollider.enabled = true;
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        item.transform.position = guide.transform.position;
    }
    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player")
        {
            collidePlayer = true;
        }
    }
}

