using UnityEngine.SceneManagement;
using UnityEngine;

public class ObstacleCollisionScript : MonoBehaviour
{
    public void RestartGame() {
        SceneManager.LoadScene("GameScene");
    }
}
