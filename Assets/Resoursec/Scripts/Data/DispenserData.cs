using UnityEngine;


[CreateAssetMenu(fileName = "Dispenser", menuName = "Dispenser/Type")]
public class DispenserData : ScriptableObject
{
    public GameObject prefab;
    public Material mat;
    public Color clr;
    public Texture texture;
    public string tagName;
}
