using System;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositions : MonoBehaviour
{
    public string tagToReset = "target";
    private Dictionary<GameObject, Vector3> initialPositions = new Dictionary<GameObject, Vector3>();

    public GameObject hitAnimation;
    public AudioClip hitAudio;

    private void OnCollisionEnter(Collision collision)
    {
        //--- When we hit another game object with the matching tag
        if (collision.collider.tag == "bullet")
        {
            //--- Play our animation at the current position
            GameObject fireAnimationInstance =
                Instantiate(hitAnimation, transform.position, transform.rotation);
            fireAnimationInstance.transform.localScale = Vector3.one * 0.1f;

            //--- Play the audio at the current location
            AudioSource.PlayClipAtPoint(hitAudio,
                this.gameObject.transform.position);

            //--- Reset the tagged object positions
            Reset();
        }
    }

    private void Start()
    {
        //--- Store initial positions
        GameObject[] objectsToReset = GameObject.FindGameObjectsWithTag(tagToReset);
        foreach (var obj in objectsToReset)
        {
            initialPositions[obj] = obj.transform.position;
        }

        Debug.Log("Initial positions: " + objectsToReset.Length);
    }

    //--- Method to reset positions by tag
    public void Reset()
    {
        foreach (var entry in initialPositions)
        {
            GameObject prefab = entry.Key;
            Vector3 initialPosition = entry.Value;

            if (prefab != null)
            {
                //--- Instantiate a new object at the initial position
                Instantiate(prefab, initialPosition, Quaternion.identity);
            }
        }
    }
}