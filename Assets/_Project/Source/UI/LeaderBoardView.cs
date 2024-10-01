using UnityEngine;
using Cysharp.Threading.Tasks;
using Source.Services.Player;
using LootLocker.Requests;
using Zenject;
using TMPro;

public class LeaderBoardView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerNamesDisplayText;
    [SerializeField] private TextMeshProUGUI _playerScoresDisplayText;

    private IPlayerService _playerService;

    [Inject]
    private void Construct(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    public void FetchTopHighscoresRoutine(LeaderBoardType type)
    {
        LootLockerSDKManager.GetScoreList(Consts.GetLeaderBoard(type), 10, (response) =>
        {
            if(!response.success)
            {
                Debug.Log("Failed to load leaderboard");
                Debug.Log(response.errorData.ToString());

                return;
            }

            Debug.Log("Successfully loaded leaderboard");

            string tempPlayerNames = "\n";
            string tempPlayerScores = "\n";

            LootLockerLeaderboardMember[] members = response.items;

            if(response.items == null || response.items.Length < 1)
            {
                Debug.Log("No leaderboard data available.");

                return;
            }

            foreach(var member in members)
            {
                tempPlayerNames += member.rank + ". ";

                tempPlayerNames += _playerService.CurrentPlayerId;

                float memberScore = member.score / 1000f;

                int seconds = Mathf.FloorToInt(memberScore % 60);
                int milliseconds = Mathf.FloorToInt((memberScore * 100) % 100);

                tempPlayerScores += string.Format("{0:0}.{1:0}", seconds, milliseconds) + "\n";
                tempPlayerNames += "\n";
            }

            _playerNamesDisplayText.text = tempPlayerNames;
            _playerScoresDisplayText.text = tempPlayerScores;
        });
    }
}
