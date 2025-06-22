using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;

public class testR : MonoBehaviour
{
    private async Task Start()
    {
        await UnityServices.InitializeAsync();
        // await makes sure game doesn't free while waiting for input

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId);
        };

        await AuthenticationService.Instance.SignInAnonymouslyAsync();


    }

    private async void RelayRace()
    {
        try {
            Allocation allocation = await RelayService.Instance.CreateAllocationAsync(4);
            //4 players plus ther host = 5
            string joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);
        } catch (RelayServiceException e) { Debug.Log(e); }
    }
}

