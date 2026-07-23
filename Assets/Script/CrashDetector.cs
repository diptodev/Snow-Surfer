using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem playerParticle;
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerFloorIndex=LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer==layerFloorIndex)
        {
            playerParticle.Stop();
            crashParticle.Play();
            Invoke("reloadScene",1f);
        }
    }
    void reloadScene()
    {
        crashParticle.Stop();
        SceneManager.LoadScene(0);
    }
}
