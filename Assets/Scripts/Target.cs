using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject hitAnimation;
    public AudioClip hitAudio;

    private void OnCollisionEnter(Collision collision)
    {
        //--- When we hit another game object with the matching tag
        if (collision.collider.tag == "bullet")
        {
            //--- Play our animation at the current position
            Instantiate(hitAnimation, transform.position, transform.rotation);

            //--- Play the audio at the current location
            AudioSource.PlayClipAtPoint(hitAudio,
                this.gameObject.transform.position);

            //--- Make the object hitting disappear
            Destroy(gameObject);

            //--- Make the object that was hit disappear
            Destroy(collision.gameObject);
        }
    }
}
