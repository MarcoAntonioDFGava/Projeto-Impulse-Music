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

    public float jumpForce = 20f; // For�a do pulo
    private Rigidbody2D rb; // Refer�ncia para o Rigidbody2D

    public string initialSceneName = "MainMenu"; // Nome da cena inicial

    private bool isGrounded = false; // Flag para verificar se o jogador est� no ch�o

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

    // Fun��o para carregar a tela inicial
    void LoadInitialScene()
    {
        // Carrega a cena inicial usando o nome da cena
        SceneManager.LoadScene(initialSceneName);
    }

    void Update()
    {
        // Atualiza a verifica��o de estar no ch�o
        isGrounded = onGround();

        // Movimento horizontal com a velocidade baseada no enum 'CurrentSpeeds'
        transform.position += Vector3.right * velocityValues[(int)CurrentSpeeds] * Time.deltaTime;

        // Verifica se o jogador pressionou o bot�o do mouse (clique esquerdo)
        if (Input.GetMouseButtonDown(0)) // Usando GetMouseButtonDown para detectar o clique
        {
            // Verifica se o jogador est� no ch�o antes de pular
            if (isGrounded == false)
            {
                Debug.Log("N�o est� no ch�o. N�o pode pular!");
            }
            else
            {
                Jump();
            }
        }
    }

    // Fun��o para verificar se o jogador est� tocando o ch�o
    bool onGround()
    {
        // A verifica��o do ch�o ocorre em torno do GroundCheckTransform
        bool grounded = Physics2D.OverlapCircle(GroundCheckTransform.position, GroundCheckRadius, GroundMask);
        Debug.Log("Est� no ch�o? " + grounded);
        return grounded;
    }

    // Fun��o para fazer o personagem pular
    void Jump()
    {
        // Se o jogador n�o estiver no ch�o, n�o pule
        if (!isGrounded) return;

        // Zera a velocidade vertical antes de aplicar o pulo
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);

        // Aplica uma for�a para cima
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        Debug.Log("Jogador pulou!");
    }
}