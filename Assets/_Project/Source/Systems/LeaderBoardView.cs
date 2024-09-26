using UnityEngine;
using Cysharp.Threading.Tasks;
using LootLocker.Requests;
using TMPro;

public class LeaderBoardView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerNamesDisplayText;
    [SerializeField] private TextMeshProUGUI _playerScoresDisplayText;

    public async UniTask SumbitScoreRoutine(int scoreToUpload)
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");

        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, Consts.LEADER_BOARD_KEY, (response) =>
        {
            if(!response.success)
            {
                Debug.Log("Could not submit score!");
                Debug.Log(response.errorData.ToString());

                return;
            }

            Debug.Log("Successfully uploaded score");
            done = true;
        });

        await UniTask.WaitUntil(() => done);
    }

    public async UniTask FetchTopHighscoresRoutine()
    {
        bool done = false;

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
            string tempPlayerScores = "Scores\n";

            LootLockerLeaderboardMember[] members = response.items;

            for(int i = 0; i < members.Length; i++)
            {
                tempPlayerNames += members[i].rank + ". ";
                    
                if(!string.IsNullOrEmpty(members[i].player.name))
                {
                    tempPlayerNames += members[i].player.name;
                }
                else
                {
                    tempPlayerNames += members[i].player.id;
                }
                    
                tempPlayerScores += members[i].score + "\n";
                tempPlayerNames += "\n";
            }

            _playerNamesDisplayText.text = tempPlayerNames;
            _playerScoresDisplayText.text = tempPlayerScores;

            done = true;
        });

        await UniTask.WaitUntil(() => done);
    }
}
