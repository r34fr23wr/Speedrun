using System;

public static class Consts
{
    public const string LEVEL_1_LEADERBOARD = "Level_1_LeaderBoard";
    public const string LEVEL_2_LEADERBOARD = "Level_2_LeaderBoard";
    public const string LEVEL_3_LEADERBOARD = "Level_3_LeaderBoard";

    public static string GetLeaderBoard(LeaderBoardType leaderBoardType)
    {
        switch(leaderBoardType)
        {
            case LeaderBoardType.Level1:
                return LEVEL_1_LEADERBOARD;
            case LeaderBoardType.Level2:
                return LEVEL_2_LEADERBOARD;
            case LeaderBoardType.Level3:
                return LEVEL_3_LEADERBOARD;
            default:
                throw new ArgumentOutOfRangeException(nameof(leaderBoardType), leaderBoardType, null);
        }
    }
}