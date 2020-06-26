using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    public GameObject player;

    private CharacterController cc;

    public Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {

            cc = other.gameObject.GetComponent<CharacterController>();
            player.GetComponent<Movement>().movingPlatform = this;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            player.GetComponent<Movement>().onMovingPlatform = true;
            cc.Move(rb.velocity * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player.GetComponent<Movement>().onMovingPlatform = false;
            cc.Move(rb.velocity * Time.deltaTime);

        }
    }
}
