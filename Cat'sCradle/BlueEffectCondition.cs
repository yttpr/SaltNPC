// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.BlueEffectCondition
// Assembly: "Cat'sCradle", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0655AEEE-5A60-4F93-BDB6-92433D76888B
// Assembly location: C:\Users\windows\Downloads\Cat'sCradle\Cat'sCradle.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace Cat_sCradle
{
  public class BlueEffectCondition : EffectConditionSO
  {
    public virtual bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
    {
      ManaBar mainManaBar = CombatManager.Instance._stats.MainManaBar;
      int num = 0;
      foreach (ManaBarSlot manaBarSlot in mainManaBar.ManaBarSlots)
      {
        if (!manaBarSlot.IsEmpty && Object.op_Equality((Object) manaBarSlot.ManaColor, (Object) Pigments.Blue))
          ++num;
      }
      return Random.Range(0, 100) < num * 10;
    }
  }
}
