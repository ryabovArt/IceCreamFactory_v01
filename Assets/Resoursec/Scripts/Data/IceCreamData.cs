using UnityEngine;

[CreateAssetMenu(fileName = "IceCream", menuName = "IceCream/Type")]
public class IceCreamData : ScriptableObject
{
    public GameObject prefab;
    public Material mat;
    public Texture texture;
}
