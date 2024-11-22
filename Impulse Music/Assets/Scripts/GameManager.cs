using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void StartGame()
    {
        // Altere "GameScene" para o nome da cena do jogo
        SceneManager.LoadScene("GameScene");
    }
}
