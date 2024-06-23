using Unity.VisualScripting;

public class BaseState
{
    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public string name;
    public EVENT stage;

    protected StateMachine stateMachine;

    public BaseState(string name, StateMachine stateMachine)
    {
        this.name = name;
        this.stateMachine = stateMachine;

        stage = EVENT.ENTER;
    }

    public virtual void Enter() { stage = EVENT.ENTER; }
    public virtual void Update() { stage = EVENT.ENTER; }
    public virtual void Exit() { stage = EVENT.EXIT; }
}