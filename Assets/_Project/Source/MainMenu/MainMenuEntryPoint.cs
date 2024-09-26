using UnityEngine;
using Cysharp.Threading.Tasks;
using LootLocker.Requests;

public class MainMenuEntryPoint : MonoBehaviour
{
    [SerializeField] private LeaderBoardView _leaderBoardView;

    private void Start()
    {
        _leaderBoardView.FetchTopHighscoresRoutine();
    }
}