using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerFloorIndex=LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer==layerFloorIndex)
        {
            SceneManager.LoadScene(0);
        }
    }
}
