namespace FreeInvader.Scripts;

public static class GlobalState
{
    public static int ResetCount { get; set; } = 0;
    public static float SpeedScale { get; set; } = 1f;
    public static int EnemyCount { get; set; } = 0;
    public static int Score { get; set; } = 0;
    public static int Live { get; set; } = 2;
    public static void AddScore(int score)
    {
        Score += score;
    }

    public static void AddLive()
    {
        Live++;
    }

    public static void ReduceLive()
    {
        Live--;
    }
}