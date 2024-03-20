// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.BlueItem
// Assembly: "Cat'sCradle", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0655AEEE-5A60-4F93-BDB6-92433D76888B
// Assembly location: C:\Users\windows\Downloads\Cat'sCradle\Cat'sCradle.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace Cat_sCradle
{
  public class BlueItem
  {
    public Sprite ability;
    public Sprite item;
    public EffectSO indirect;
    public WearableStaticModifierSetterSO slap;
    public Ability FlowingJab;
    public Item BlueDisciple;

    public BlueItem(ItemPools pool)
    {
      this.ability = ResourceLoader.LoadSprite("BlueFist.png", 32);
      this.item = ResourceLoader.LoadSprite("BlueMask.png", 32);
      this.indirect = (EffectSO) ScriptableObject.CreateInstance<DamageEffect>();
      (this.indirect as DamageEffect)._indirect = true;
      this.FlowingJab = new Ability()
      {
        name = "Flowing Jab",
        description = "Deal 4 indirect damage to the Opposing enemy. \nFor every Blue pigment in the pigment tray, there is a 10% chance to refresh this party member's abilities.",
        sprite = this.ability,
        cost = new ManaColorSO[1]{ Pigments.Blue },
        effects = new Effect[2]
        {
          new Effect(this.indirect, 4, new IntentType?((IntentType) 1), Slots.Front),
          new Effect((EffectSO) ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 100), Slots.Self, (EffectConditionSO) ScriptableObject.CreateInstance<BlueEffectCondition>())
        },
        visuals = LoadedAssetsHandler.GetCharacterAbility("Parry_1_A").visuals,
        animationTarget = Slots.Front
      };
      this.slap = (WearableStaticModifierSetterSO) ScriptableObject.CreateInstance<BasicAbilityChange_Wearable_SMS>();
      ((BasicAbilityChange_Wearable_SMS) this.slap)._basicAbility = this.FlowingJab.CharacterAbility();
      EffectItem effectItem = new EffectItem();
      effectItem.name = "Blue Disciple";
      effectItem.flavorText = "\"Let it flow inside you.\"";
      effectItem.description = "Replaces slap on this party member with \"Flowing Jab\".";
      effectItem.sprite = this.item;
      effectItem.consumeTrigger = (TriggerCalls) 1000;
      effectItem.unlockableID = (UnlockableID) 775002;
      effectItem.namePopup = false;
      effectItem.consumedOnUse = false;
      effectItem.itemPools = pool;
      effectItem.shopPrice = 6;
      effectItem.startsLocked = false;
      effectItem.immediate = true;
      effectItem.equippedModifiers = new WearableStaticModifierSetterSO[1]
      {
        this.slap
      };
      this.BlueDisciple = (Item) effectItem;
    }
  }
}
