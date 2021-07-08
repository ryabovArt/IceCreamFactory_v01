using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetRecipe : MonoBehaviour
{
    [SerializeField] private InventoryRecipe targetRecipe;

    [SerializeField] private Image recipeImage;

    private int currentLevel;

    public static int recipeDatasIndex;

    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("Level");

        //recipeImage.sprite = targetRecipe.recipeDatas[6].recipe;
        if (currentLevel == 1)
        {
            recipeImage.sprite = targetRecipe.recipeDatas[0].recipe;
            recipeDatasIndex = targetRecipe.recipeDatas[0].iceCreamCount;
        }
        if (currentLevel > 1 && currentLevel < 4)
        {
            recipeImage.sprite = targetRecipe.recipeDatas[1].recipe;
            recipeDatasIndex = targetRecipe.recipeDatas[1].iceCreamCount;
        }
        if (currentLevel > 3 && currentLevel <= 6)
        {
            int index = Random.Range(1, 3);
            recipeImage.sprite = targetRecipe.recipeDatas[index].recipe;
            recipeDatasIndex = targetRecipe.recipeDatas[index].iceCreamCount;
        }
        if (currentLevel > 6 && currentLevel < 10)
        {
            int index = Random.Range(3, 5);
            recipeImage.sprite = targetRecipe.recipeDatas[index].recipe;
            recipeDatasIndex = targetRecipe.recipeDatas[index].iceCreamCount;
        }
        if (currentLevel >= 10 && currentLevel <= 25)
        {
            int index = Random.Range(5, 7);
            print("index " + index);
            recipeImage.sprite = targetRecipe.recipeDatas[index].recipe;
            recipeDatasIndex = targetRecipe.recipeDatas[index].iceCreamCount;
        }
        print(currentLevel);
        print("recipeDatasIndex " + recipeDatasIndex);
    }
}
