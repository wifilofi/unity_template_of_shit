using System;
using _Game.Scripts.Services;
using _Game.Scripts.Services.CursorService;
using _Game.Services;
using Tools.CMSTags;

namespace ServiceTags
{

    [Serializable]
    public class ExampleGameplayServiceTag : TagBase<ExampleGameplayService.Settings>
    {
    }

    [Serializable]
    public class CursorServiceTag : TagBase<CursorService.Settings>
    {
    }
    
    [Serializable]
    public class MusicServiceTag : TagBase<MusicService.Settings>
    {
    }
}
