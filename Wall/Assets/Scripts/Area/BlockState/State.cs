using UnityEngine;

public abstract class State
{
    protected Block block;
    public virtual bool DieOnCollision => false;

    private bool freeToPutBlock = true;
    public bool FreeToPutBlock
    {
        get => block.currentState is Plane && freeToPutBlock;
        set => freeToPutBlock = value;
    }

    public virtual Material blockMaterial => Config.Instance.MovableMat;

    public State(Block block)
    {
        this.block = block;
        Initialize();
    }

    protected void ChangeState(State newState)
    {
        block.currentState = newState;
    }
    protected virtual void Initialize()
    {
        block.material = blockMaterial;
    }

    public void Select(bool value)
    {
        if(!value)
            ChangeState(new Plane(block));
        else
            ChangeState(new ReadyToMove(block));
    }

    public virtual void Swipe(Vector3 direction)
    {

    }
    public virtual void StartGame()
    {

    }
    public virtual void Move()
    {

    }
    public override string ToString()
    {
        return GetType().ToString();
    }
}
