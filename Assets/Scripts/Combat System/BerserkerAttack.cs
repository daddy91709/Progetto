using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkerAttack : MonoBehaviour
{
    public GameObject objectToThrow; // Prefab for the object to throw
    public float throwForce = 10f; // Force with which to throw the object
    public float growSpeed = 1f; // Speed at which the object grows
    public float waitTime= 5f;

    private GameObject currentObject; // Reference to the currently thrown object
    private Transform player; // Transform component of the player
    private Vector3 initialScale;
    private bool flag= true;
    private Stanza stanza;

void Start()
{
    stanza= transform.GetComponentInParent<Transform>().GetComponentInParent<Stanza>();
}
void Update()
{
    player=  GameObject.FindGameObjectWithTag("Player").transform;

    if (stanza.GetInside())
    {
        // If there is no object being thrown, instantiate a new one
        if (currentObject == null && flag)
        {
            currentObject = Instantiate(objectToThrow, transform.position, Quaternion.identity, transform);
            initialScale = currentObject.transform.localScale;

            GetComponent<AudioSource>().volume= PlayerPrefs.GetFloat("EffectsVolume");
            GetComponent<AudioSource>().Play();
        }
        // Otherwise, update the size and velocity of the object
        else if (currentObject != null)
        {
            // Increase the size of the object
            currentObject.transform.localScale += Vector3.one * growSpeed * Time.deltaTime;

            // If the object has grown to n-times its initial size, destroy it
            if (currentObject.transform.localScale.x > initialScale.x * 1.75f)
            {
                Destroy(currentObject);
                currentObject = null;

                // Set a timer to wait before throwing a new object
                StartCoroutine(WaitAndThrow());
            }
            else
            {
                // Calculate the direction from the boss to the player
                Vector2 direction = player.position - transform.position;

                // Set the velocity of the object in the correct direction
                currentObject.GetComponent<Rigidbody2D>().velocity = Vector3.Slerp(currentObject.GetComponent<Rigidbody2D>().velocity, direction, throwForce);
            }
        }
    }
}

    // Coroutine to wait before throwing a new object
    IEnumerator WaitAndThrow()
    {
        flag = false;
        yield return new WaitForSeconds(waitTime);
        flag = true;
    }
}