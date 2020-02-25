using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public bool hasPowerup;
    private float powerupstrength = 10;
    public GameObject powerIndicator;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward*forwardInput*speed);
        powerIndicator.transform.position = transform.position;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine("PowerupCountdownRoutine");
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRB.AddForce(awayFromPlayer * powerupstrength, ForceMode.Impulse);
            Debug.Log("Collided with:" + collision.gameObject.name + "With powerup set to:" + hasPowerup);
        }
    }
}

    