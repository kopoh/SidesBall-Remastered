using UnityEngine;
#pragma warning disable 618

namespace I2.Loc
{
    #if UNITY_EDITOR
    [UnityEditor.InitializeOnLoad] 
    #endif
    public class LocalizeTarget_UnityStandard_GUITexture : LocalizeTarget<UnityEngine.UI.Image>
    {
        static LocalizeTarget_UnityStandard_GUITexture() { AutoRegister(); }
        [RuntimeInitializeOnLoadMethod] static void AutoRegister() { LocalizationManager.RegisterTarget(new LocalizeTargetDesc_Type<UnityEngine.UI.Image, LocalizeTarget_UnityStandard_GUITexture>() { Name = "GUITexture", Priority = 100 }); }

        public override eTermType GetPrimaryTermType(Localize cmp) { return eTermType.Texture; }
        public override eTermType GetSecondaryTermType(Localize cmp) { return eTermType.Text; }
        public override bool CanUseSecondaryTerm() { return false; }
        public override bool AllowMainTermToBeRTL() { return false; }
        public override bool AllowSecondTermToBeRTL() { return false; }

        public override void GetFinalTerms ( Localize cmp, string Main, string Secondary, out string primaryTerm, out string secondaryTerm)
        {
            primaryTerm = mTarget.sprite ? mTarget.sprite.name : string.Empty;
            secondaryTerm = null;
        }


        public override void DoLocalize(Localize cmp, string mainTranslation, string secondaryTranslation)
        {
            Sprite Old = mTarget.sprite;
            if (Old == null || Old.name != mainTranslation)
                mTarget.sprite = cmp.FindTranslatedObject<Sprite>(mainTranslation);

            // If the old value is not in the translatedObjects, then unload it as it most likely was loaded from Resources
            //if (!HasTranslatedObject(Old))
            //	Resources.UnloadAsset(Old);
        }
    }
}
