using _Game.Services;


    public static class G
    {
        public static void InitGlobalServices()
        {
            CMS.Init();
            RegGlobal(new ExampleMouseService());
        }

        #region Wrappers

        public static T RegGlobal<T>(T service) where T : class
        {
            ServiceLocator.Scripts.ServiceLocator.Global.Register(typeof(T),  service);
            return service;
        }
    
        public static T RegLocal<T>(T service) where T : class
        {
            ServiceLocator.Scripts.ServiceLocator.ForSceneOfCurrent().Register(typeof(T),  service);
            return service;
        }
    
        public static T GetLocal<T>() where T : class
        {
            return ServiceLocator.Scripts.ServiceLocator.ForSceneOfCurrent().Get<T>();
        }
        public static T GetGlobal<T>() where T : class
        {
            return ServiceLocator.Scripts.ServiceLocator.ForSceneOfCurrent().Get<T>();
        }

        #endregion
    }
