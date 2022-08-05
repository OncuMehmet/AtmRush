using System.Collections.Generic;
using Data.ValueObject;
using UnityEngine;

[CreateAssetMenu(fileName = "CD_Collectables", menuName = "ATMRush/CD_Collectables", order = 0)]
public class CD_Collectables : ScriptableObject
{
    public List<MeshFilter> filters;
    public MeshStateData meshState;
    public CollectableStateData collectableStateData;

}
