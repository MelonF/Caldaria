using Mirror;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;


public class NetworkMan : NetworkManager
{


    public async void getHostCodeAndStartServer()
    {

        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
        Allocation allocation = await RelayService.Instance.CreateAllocationAsync(4);
        //4 + host
        string joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

        StartHost();






    }





}
