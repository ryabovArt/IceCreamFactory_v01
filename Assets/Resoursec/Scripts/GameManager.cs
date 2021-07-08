using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Transform spawnPoint;
    public Transform SpawnPoint { get => spawnPoint; }

    [SerializeField] private Transform destroyPoint;
    public Transform DestroyPoint { get => destroyPoint; }

    public GameObject dispenser;
    public GameObject firstIceCreamInDispenser;

    public List<DispenserData> dispenserData = new List<DispenserData>();
    internal int dispenserIndex;

    public List<DispenserData> additionalDispenserData = new List<DispenserData>();

    [SerializeField] private List<Texture> textures = new List<Texture>();

    [SerializeField] private List<GameObject> spawnedIceCreame = new List<GameObject>();
    public List<GameObject> SpawnedIceCreame { get => spawnedIceCreame; }

    public int numberOfGamesPlayed;
    public int countGamesToChangeLevel;

    public static int levelProgressIndex;

    #region [Поля настройки]

    [Header("Отступ слева")]
    [SerializeField] private float leftDelay;
    public float LeftDelay { get => leftDelay; }

    [Header("Отступ справа")]
    [SerializeField] private float rightDelay;
    public float RightDelay { get => rightDelay; }

    [Header("Время между спавном дозаторов мороженого")]
    [SerializeField] private float delay;
    public float Delay { get => delay; }

    [Header("Скорость дозатора")]
    [SerializeField] private float disprnserSpeed;
    public float DispenserSpeed { get => disprnserSpeed; }

    [Header("Скорость мороженого при достижении финиша")]
    [SerializeField] private float iceCreamFinishSpeed;
    public float IceCreamFinishSpeed { get => iceCreamFinishSpeed; }

    //
    public int level;
    public int dispenserCountInLevel;
    public static int staticLevel;
    public int totalNumberOfDispensers;

    #endregion


    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        SetDispenserCount();
    }

    void Start()
    {
        //PlayerPrefs.DeleteKey("NumberOfGamesPlayed");
        numberOfGamesPlayed = PlayerPrefs.GetInt("NumberOfGamesPlayed");

        PlayerPrefs.SetInt("Level", level);

        levelProgressIndex = dispenserData.Count;
        ChangeLevel();
        StartCoroutine(InstantiateDispenser());
    }

    /// <summary>
    /// Спавним дозатор с мороженым
    /// </summary>
    /// <returns></returns>
    IEnumerator InstantiateDispenser()
    {
        while (dispenserIndex <= totalNumberOfDispensers)
        {
            dispenser = Instantiate(dispenserData[dispenserIndex].prefab, spawnPoint);
            dispenserData[dispenserIndex].mat.color = dispenserData[dispenserIndex].clr;
            dispenser.tag = dispenserData[dispenserIndex].tagName;
            //dispenser.GetComponent<MeshRenderer>().material.mainTexture = textures[dispenserIndex];

            dispenserIndex++;

            if (dispenser.CompareTag("Dispenser"))
            {
                dispenser.GetComponent<SpawnIceCream>().SpawnFirstIceCream();
                yield return new WaitForSeconds(0.2f);
                dispenser.GetComponent<SpawnIceCream>().SpawnFirstIceCream();
            }

            //print("dispenserIndex " + dispenserIndex);
            //print("totalNumberOfDispensers " + totalNumberOfDispensers);
            if (level < 7)
            {
                if (dispenserIndex > totalNumberOfDispensers)
                {
                    StartCoroutine(InstantiateFinish());
                }
            }

            //if (dispenserIndex == 4)
            //{
            //    StartCoroutine(InstantiateFinish());
            //}


            yield return new WaitForSeconds(delay);
        }

        if (level > 7)
        {
            dispenser = Instantiate(additionalDispenserData[0].prefab, spawnPoint);
            additionalDispenserData[0].mat.color = additionalDispenserData[0].clr;
            dispenser.tag = additionalDispenserData[0].tagName;

            dispenser.transform.GetChild(1).gameObject.SetActive(false);

            /*if(spawnedIceCreame.Count > 0) *//*spawnedIceCreame[spawnedIceCreame.Count - 1].transform.GetChild(2).GetComponent<Collider>().enabled = true;*/

            if (level < 10)
                StartCoroutine(InstantiateFinish());
            if (level >= 10)
                StartCoroutine(InstantiateTopping());
        }
        
    }

    /// <summary>
    /// Спавним дозатор с топпингом
    /// </summary>
    /// <returns></returns>
    IEnumerator InstantiateTopping()
    {
        yield return new WaitForSeconds(delay);
        dispenser = Instantiate(additionalDispenserData[1].prefab, spawnPoint);
        additionalDispenserData[1].mat.color = additionalDispenserData[1].clr;
        dispenser.tag = additionalDispenserData[1].tagName;

        dispenser.transform.GetChild(1).gameObject.SetActive(false);

        StartCoroutine(InstantiateFinish());
    }

    /// <summary>
    /// Спавним финиш
    /// </summary>
    /// <returns></returns>
    IEnumerator InstantiateFinish()
    {
        yield return new WaitForSeconds(delay);
        dispenser = Instantiate(dispenserData[4].prefab, spawnPoint);
        staticLevel = spawnedIceCreame.Count;
    }

    /// <summary>
    /// Устанавливаем количество дозаторов в зависимости от уровня
    /// </summary>
    private void SetDispenserCount()
    {
        if (level == 1)
        {
            dispenserCountInLevel = 0;
            totalNumberOfDispensers = 0;
        }
        if (level > 1 && level < 4)
        {
            dispenserCountInLevel = 1;
            totalNumberOfDispensers = 1;
        }
        if (level > 3 && level <= 10)
        {
            //int dispenserCount = Random.Range(1, 3);
            int dispenserCount = GetRecipe.recipeDatasIndex - 1;
            dispenserCountInLevel = dispenserCount;
            totalNumberOfDispensers = dispenserCount;
        }
        if (level > 10 && level <= 25)
        {
            int dispenserCount = GetRecipe.recipeDatasIndex - 1;
            dispenserCountInLevel = dispenserCount;
            totalNumberOfDispensers = dispenserCount;
        }
    }

    /// <summary>
    /// Прибавляем уровень
    /// </summary>
    private void ChangeLevel()
    {
        if (numberOfGamesPlayed == countGamesToChangeLevel)
        {
            level++;
            countGamesToChangeLevel += 10;
        }
    }
}
