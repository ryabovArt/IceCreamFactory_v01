using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeData", menuName = "RecipeData/Type")]
public class RecipeData : ScriptableObject
{
    public int iceCreamCount;
    public Color toppingColor;
    public bool nuts;
    public Sprite recipe;
}
