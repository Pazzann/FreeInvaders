namespace FreeInvader.Scripts;

public static class GlobalState
{
    public static float SpeedScale { get; set; } = 1f;

    public static int Score { get; set; } = 0;
    public static void AddScore(int score)
    {
        Score += score;
    }
}