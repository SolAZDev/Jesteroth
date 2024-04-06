using System.Diagnostics.CodeAnalysis;
using HarmonyLib;
using UnityEngine;

namespace Jesteroth;

[HarmonyPatch(typeof(JesterAI))]
public static class JesterAiPatch {
    [HarmonyPatch(nameof(JesterAI.Start))]
    [HarmonyPrefix]
    public static void JesterothPatch(
        [SuppressMessage("ReSharper", "InconsistentNaming")] ref AudioClip ___popGoesTheWeaselTheme,
        [SuppressMessage("ReSharper", "InconsistentNaming")] ref AudioClip ___screamingSFX,
        [SuppressMessage("ReSharper", "InconsistentNaming")] ref AudioSource ___farAudio,
        [SuppressMessage("ReSharper", "InconsistentNaming")] ref AudioSource ___creatureVoice
        ) {
        if (JesterothBase.Instance.IntroEnabled.Value) {
            ___popGoesTheWeaselTheme = JesterothBase.Instance.Intro;
            ___farAudio.volume = JesterothBase.Instance.IntroVolume.Value / 100.0f;
        }
        if (JesterothBase.Instance.SoloEnabled.Value) {
            ___screamingSFX = JesterothBase.Instance.Solo;
            ___creatureVoice.volume = JesterothBase.Instance.SoloVolume.Value / 100.0f;
        }
    }
}