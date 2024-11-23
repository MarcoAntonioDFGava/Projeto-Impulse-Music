using UnityEngine;
using System.Collections;

public class CollectibleItem : MonoBehaviour
{
    public AudioSource musicSource; // Referência à música
    public float speedMultiplier = 1.4f; // Multiplicador de velocidade
    public float effectDuration = 8f; // Duração do efeito

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bird")) // Verifica se o jogador colidiu
        {
            StartCoroutine(ApplyMusicSpeedBoost());
            gameObject.SetActive(false); // Faz o item "sumir"
        }
    }

    private IEnumerator ApplyMusicSpeedBoost()
    {
        Debug.Log("Velocidade aumentada!");
        musicSource.pitch *= speedMultiplier;

        yield return new WaitForSeconds(effectDuration);

        musicSource.pitch = 1.0f;
        Debug.Log("Velocidade restaurada!");
    }
}
