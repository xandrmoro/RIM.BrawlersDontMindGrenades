using HarmonyLib;
using UnityEngine;
using Verse;

namespace BrawlersDontMindGrenades
{
    public class BrawlersDontMindGrenades : Mod
    {
        public static Settings Settings { get; private set; }

        public BrawlersDontMindGrenades(ModContentPack contentPack) : base(contentPack)
        {
            Settings = GetSettings<Settings>();

            new Harmony(Content.PackageIdPlayerFacing).PatchAll();
        }

        public override void WriteSettings()
        {
            base.WriteSettings();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);
        }

        public override string SettingsCategory()
        {
            return nameof(BrawlersDontMindGrenades);
        }
    }
}
