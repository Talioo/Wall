using UnityEngine;

public class Plane : State
{
    public override Material blockMaterial => Config.Instance.PlaneMat;
    public Plane(Block block) : base(block) { }
}
