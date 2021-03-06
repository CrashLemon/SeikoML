﻿using System;
using RoR2;
using EntityStates;
using SeikoML;
using UnityEngine;

public class BanditMod : ISeikoMod{
	public void OnStart(){
        SurvivorModInfo survivorModInfo = new SurvivorModInfo {
            bodyPrefabString = "BanditBody",
            descriptionTokenString = "BANDIT_DESCRIPTION",
            portraitPrefabString = "Prefabs/Characters/BanditDisplay",
            usedColor = new Color(0.8039216f, 0.482352942f, 0.843137264f),
            toReplace = 3,
            unlockableNameString = "",
            primarySkillNameToken = "Blast",
            primarySkillDescriptionToken = "Fire a powerful slug for <style=cIsDamage>150% damage</style>.",
            secondarySkillNameToken = "Lights Out",
            secondarySkillDescriptionToken = "Take aim for a headshot, dealing <style=cIsDamage>600% damage</style>. If the ability <style=cIsDamage>kills an enemy</style>, the Bandit's <style=cIsUtility>Cooldowns are all reset to 0</style>.",
            utilitySkillNameToken = "Smokebomb",
            utilitySkillDescriptionToken = "Turn invisible for <style=cIsDamage>3 seconds</style>, gaining <style=cIsUtility>increased movement speed</style>.",
            specialSkillNameToken = "Thermite Toss",
            specialSkillDescriptionToken = "Fire off a burning Thermite grenade, dealing <style=cIsDamage>damage over time</style>.",
		};
        var org_secondary = BodyCatalog.FindBodyPrefab(survivorModInfo.bodyPrefabString).GetComponents<GenericSkill>()[1];
        survivorModInfo.Primary = org_secondary;
        survivorModInfo.Primary.baseMaxStock = 6;
        var mult_secondary = BodyCatalog.FindBodyPrefab("ToolbotBody").GetComponents<GenericSkill>()[1];
        survivorModInfo.Secondary = mult_secondary;
        survivorModInfo.Secondary.activationState = mult_secondary.activationState;
        ModLoader.SurvivorMods.Add(survivorModInfo);
	}
}
