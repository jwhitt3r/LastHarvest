using Economy;

public sealed class GameState
{
    public IEconomy Economy { get; private set; } = new MemoryEconomy();

    public static GameState Instance { get; } = new();

    private GameState(){}
}