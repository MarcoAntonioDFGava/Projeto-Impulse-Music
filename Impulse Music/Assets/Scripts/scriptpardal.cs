using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Importando o SceneManager

public enum velocity { Slow = 0, Normal = 1, Fast = 2, Faster = 3, Fastest = 4 };

public class Pardalberto : MonoBehaviour
{
    public velocity CurrentSpeeds;
    // 0 Slow, 1 Normal, 2 Fast, 3 Faster, 4 Fastest
    float[] velocityValues = { 7.2f, 8.6f, 12.96f, 15.6f, 19.27f };
    public Transform GroundCheckTransform;
    public float GroundCheckRadius;
    public LayerMask GroundMask;

    public float jumpForce = 20f; // Força do pulo
    private Rigidbody2D rb; // Referência para o Rigidbody2D

    public string initialSceneName = "MainMenu"; // Nome da cena inicial

    private bool isGrounded = false; // Flag para verificar se o jogador está no chão

    void Start()
    {
        // Pegando o componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o jogador colidiu com o inimigo
        if (collision.gameObject.CompareTag("Snake"))
        {
            // Quando o personagem colide com o inimigo, carregamos a tela inicial
            Debug.Log("Colidiu com o inimigo! Voltando para a tela inicial.");
            LoadInitialScene();
        }
    }

    // Função para carregar a tela inicial
    void LoadInitialScene()
    {
        // Carrega a cena inicial usando o nome da cena
        SceneManager.LoadScene(initialSceneName);
    }

    void Update()
    {
        // Atualiza a verificação de estar no chão
        isGrounded = onGround();

        // Movimento horizontal com a velocidade baseada no enum 'CurrentSpeeds'
        transform.position += Vector3.right * velocityValues[(int)CurrentSpeeds] * Time.deltaTime;

        // Verifica se o jogador pressionou o botão do mouse (clique esquerdo)
        if (Input.GetMouseButtonDown(0)) // Usando GetMouseButtonDown para detectar o clique
        {
            // Verifica se o jogador está no chão antes de pular
            if (isGrounded)
            {
                Jump();
            }
            else
            {
                Debug.Log("Não está no chão. Não pode pular!");
            }
        }
    }

    // Função para verificar se o jogador está tocando o chão
    bool onGround()
    {
        // A verificação do chão ocorre em torno do GroundCheckTransform
        bool grounded = Physics2D.OverlapCircle(GroundCheckTransform.position, GroundCheckRadius, GroundMask);
        Debug.Log("Está no chão? " + grounded);
        return grounded;
    }

    // Função para fazer o personagem pular
    void Jump()
    {
        // Zera a velocidade vertical antes de aplicar o pulo
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);

        // Aplica uma força para cima
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        Debug.Log("Jogador pulou!");
    }
}