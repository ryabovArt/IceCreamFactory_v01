using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCream : MonoBehaviour
{
    [SerializeField] private GameObject cone;

    [SerializeField] private Animator iceCreamAnimator;

    public Renderer rend;
    private float filling = 0.9f;

    public GameObject effects;
    public Effects playEffect;

    private bool isCollision = true;
    private Rigidbody rigidbody;

    private float leftDelay;
    private float rightDelay;

    public static bool isOneStar;
    public static bool isTwoStar;

    public static List<int> indexOfIceCreamInCone = new List<int>();

    public static event Action OnHit;

    private void OnEnable()
    {
        rigidbody = GetComponent<Rigidbody>();
        isCollision = true;

        leftDelay = GameManager.instance.LeftDelay;
        rightDelay = GameManager.instance.RightDelay;

        effects = GameObject.FindGameObjectWithTag("Effects");
        playEffect = effects.GetComponent<Effects>();

        //rend.material.SetTexture("_texture", GameManager.instance.textures[GameManager.instance.dispenserIndex - 1]);
    }

    /// <summary>
    /// Проверяем, куда попало мороженое
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckFallingObject") && isCollision)
        {
            iceCreamAnimator.SetTrigger("HitOnIceCream");
            gameObject.GetComponent<Transform>().parent = other.transform.root;

            rigidbody.constraints = RigidbodyConstraints.FreezeAll;

            OnHit?.Invoke();
            playEffect.Smiles();
            
            GameManager.instance.SpawnedIceCreame.Add(gameObject);
            indexOfIceCreamInCone.Add(GameManager.instance.dispenserIndex);

            isOneStar = true;

            isCollision = false;
        }
        if (other.CompareTag("IceCream") && isCollision)
        {
            if (transform.position.y < 4.3f && transform.position.y > 2.4f)
            {
                var distance = other.transform.position.x - gameObject.transform.position.x;

                if (distance > -0.35f && distance < 0.35f)
                {
                    iceCreamAnimator.SetTrigger("HitOnIceCream");
                    rigidbody.constraints = RigidbodyConstraints.FreezeAll;

                    gameObject.transform.parent = other.transform.root;

                    GameManager.instance.SpawnedIceCreame.Add(gameObject);
                    indexOfIceCreamInCone.Add(GameManager.instance.dispenserIndex);

                    OnHit?.Invoke();
                    playEffect.Smiles();

                    isTwoStar = true;

                    isCollision = false;
                }
            }
            if (transform.position.y < 2.4f)
            {
                iceCreamAnimator.SetTrigger("HitOnFloor");

                var distance = other.transform.position.x - gameObject.transform.position.x;

                if (distance > -0.35f && distance < 0.35f)
                {
                    
                    playEffect.SetSadSmile();
                    rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    isCollision = false;
                }  
            }
        }
        if (other.CompareTag("Floor") && isCollision)
        {
            iceCreamAnimator.SetTrigger("HitOnFloor");

            isCollision = false;
        }
        if (other.CompareTag("Cone") && isCollision)
        {
            rigidbody.constraints &= ~RigidbodyConstraints.FreezeAll;
            //iceCreamAnimator.SetTrigger("Stage_1");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out DoseIceCream dose))
        {
            //print("DoseIceCream : MonoBehaviour");
            GameManager.instance.firstIceCreamInDispenser = gameObject;
            iceCreamAnimator.SetTrigger("Fall");
        }
    }

    /// <summary>
    /// Активируем шейдер заливки
    /// </summary>
    /// <param name="other"></param>
    private void OnParticleCollision(GameObject other)
    {
        StartCoroutine(StartFill());
    }

    IEnumerator StartFill()
    {
        if (gameObject.transform.position == GameManager.instance.SpawnedIceCreame[GameManager.instance.SpawnedIceCreame.Count - 1].transform.position)
        {
            while (filling >= 0.2f)
            {
                filling -= 0.005f;
                rend.material.SetFloat("_transitionLevel", filling);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
