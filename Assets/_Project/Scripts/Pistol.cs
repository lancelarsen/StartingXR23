using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float bulletSpeed = 20f;

    public AudioClip pistolFireSound;
    public GameObject pistolFireAnimation;

    public void FireBullet()
    {
        //--- Instantiate a bullet and fire it forward
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>()
            .AddForce(spawnPoint.forward * bulletSpeed, ForceMode.Impulse);

        //--- Destroy the bullet after 5 seconds
        Destroy(spawnedBullet, 5);

        //--- Play our animation at the current position
        GameObject fireAnimationInstance = 
            Instantiate(pistolFireAnimation, spawnPoint.position, spawnPoint.rotation);
        fireAnimationInstance.transform.localScale = Vector3.one * 0.05f;

        //--- Play the audio at the current location
        AudioSource.PlayClipAtPoint(pistolFireSound, this.gameObject.transform.position);
    }
}
