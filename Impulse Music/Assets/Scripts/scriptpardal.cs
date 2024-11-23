using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum velocity { Slow = 0, Normal = 1, Fast = 2, Faster = 3, Fastest = 4 };

public class Pardalberto : MonoBehaviour
{
    public velocity CurrentSpeeds;
    float[] velocityValues = { 7.2f, 8.6f, 12.96f, 15.6f, 19.27f };

    public float jumpForce = 20f; // Força do pulo
    private Rigidbody2D rb; // Referência para o Rigidbody2D

    public string initialSceneName = "MainMenu"; // Nome da cena inicial

    private bool isGrounded = false; // Verifica se está no chão

    void Start()
    {
        // Pegando o componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimento horizontal com base no enum 'CurrentSpeeds'
        transform.position += Vector3.right * velocityValues[(int)CurrentSpeeds] * Time.deltaTime;

        // Verifica se o jogador clicou para pular
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Aplica uma força de pulo
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // Zera a velocidade vertical
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        Debug.Log("Jogador pulou!");
    }

    // Combinação dos métodos OnCollisionEnter2D
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("isGrounded"))
        {
            isGrounded = true;
            Debug.Log("Jogador está no chão.");
        }
        else if (collision.gameObject.CompareTag("Snake"))
        {
            Debug.Log("Colidiu com o inimigo! Voltando para a tela inicial.");
            LoadInitialScene();
        }
    }

    // Atualiza o estado de isGrounded ao sair do chão
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("isGrounded"))
        {
            isGrounded = false;
            Debug.Log("Jogador saiu do chão.");
        }
    }

    // Função para carregar a tela inicial
    void LoadInitialScene()
    {
        SceneManager.LoadScene(initialSceneName);
    }
}
