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

    public void FetchTopHighscoresRoutine()
    {
        LootLockerSDKManager.GetScoreList(Consts.LEADER_BOARD_KEY, 10, (response) =>
        {
            if(!response.success)
            {
                Debug.Log("Failed to load leaderboard");
                Debug.Log(response.errorData.ToString());

                return;
            }

            Debug.Log("Successfully loaded leaderboard");

            string tempPlayerNames = "Names\n";
            string tempPlayerScores = "Seconds\n";

            LootLockerLeaderboardMember[] members = response.items;

            if(response.items == null || response.items.Length < 1)
            {
                Debug.Log("No leaderboard data available.");

                return;
            }

            foreach(var member in members)
            {
                tempPlayerNames += member.rank + ". ";

                //if(!string.IsNullOrEmpty(member.player.name)) tempPlayerNames += member.player.name;
                //else tempPlayerNames += member.player.id;

                tempPlayerNames += _playerService.CurrentPlayerId;

                float memberScore = member.score / 1000f;

                tempPlayerScores += memberScore + "\n";
                tempPlayerNames += "\n";
            }

            _playerNamesDisplayText.text = tempPlayerNames;
            _playerScoresDisplayText.text = tempPlayerScores;
        });
    }
}
