using UnityEngine;
using System.Collections;

public class ColliderTest : MonoBehaviour {
    public float rad = 1f;
    public float hgt = 3f;
    private float score = 0f;
    public GameObject objectToAnimate;
    private Animator theAnimator;

    CapsuleCollider thisone;
	// Use this for initialization
	void Start () {
        thisone = GetComponent<CapsuleCollider>();
        theAnimator = objectToAnimate.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            thisone.enabled = true;
            Debug.Log("Collider.enabled = " + thisone.enabled);
            theAnimator.GetComponent<Animation>().Play("one");
            Debug.Log(theAnimator.GetComponent<Animation>());
        } else {
            thisone.enabled = false;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("CollisionEnter \"" + other.gameObject.name + " \"Object");
        if (other.gameObject.tag == "Chip"){
            other.gameObject.health--;
            score = score + 0.5f;
        }
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("CollisionStay \"" + other.gameObject.name + " \"Object");
               if (other.gameObject.tag == "Chip"){
            other.gameObject.health--;
            score++;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("CollisionExit \"" + other.gameObject.name + " \"Object");
               if (other.gameObject.tag == "Chip"){
            other.gameObject.health--;
            score++;
        }
    }
}
