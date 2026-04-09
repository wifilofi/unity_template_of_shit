using System;
using _Game.Scripts.Services;
using _Game.Scripts.Services.CameraService;
using _Game.Scripts.Services.CursorService;
using _Game.Services;
using Tools.GameFSM;
using UnityEngine;
using Object = UnityEngine.Object;


public static class G
{
    public static void InitGlobalServices()
    {
        CMS.Init();
        RegGlobal(new InputService());
        
        var gameStateMachine = RegGlobal(new GameStateMachine());
        gameStateMachine.Enter<BootstrapState>();

        RegGlobalFromResources<CameraService>();
        RegGlobal(new MusicService());
        RegGlobal(new EffectsService());
        RegGlobal(new CursorService());
        G.GetGlobal<CursorService>().SetCursor(CursorType.Pointer);
    }

    #region Wrappers

    public static T RegGlobalFromResources<T>(string path = null) where T : Object
    {
        path ??= typeof(T).Name;
        var servicePrefab = Resources.Load<T>(path);
        if (servicePrefab == null)
            throw new System.Exception($"[G] Resource not found at path: '{path}'. Make sure the prefab exists inside a Resources folder.");
        var service = Object.Instantiate(servicePrefab);
        RegGlobal(service);

        return service;
    }

    public static T RegGlobal<T>(T service) where T : class
    {
        ServiceLocator.Scripts.ServiceLocator.Global.Register(typeof(T), service);
        return service;
    }

    public static T RegLocal<T>(T service) where T : class
    {
        ServiceLocator.Scripts.ServiceLocator.ForSceneOfCurrent().Register(typeof(T), service);
        return service;
    }

    public static T GetLocal<T>() where T : class
    {
        return ServiceLocator.Scripts.ServiceLocator.ForSceneOfCurrent().Get<T>();
    }

    public static bool TryGetLocal<T>(out T service) where T : class
    {
        return ServiceLocator.Scripts.ServiceLocator.ForSceneOfCurrent().TryGet(out service);
    }

    public static T GetGlobal<T>() where T : class
    {
        return ServiceLocator.Scripts.ServiceLocator.ForSceneOfCurrent().Get<T>();
    }

    #endregion
}