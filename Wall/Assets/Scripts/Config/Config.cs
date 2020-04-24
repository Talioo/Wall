using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "ScriptableObjects/Config", order =0)]
public class Config : ScriptableObjectBase<Config>
{
    [SerializeField] private Material planeMat;
    public Material PlaneMat => planeMat;

    [SerializeField] private Material movableMat;
    public Material MovableMat => movableMat;

}
