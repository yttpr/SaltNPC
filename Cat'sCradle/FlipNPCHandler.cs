// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.FlipNPCHandler
// Assembly: "Cat'sCradle", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0655AEEE-5A60-4F93-BDB6-92433D76888B
// Assembly location: C:\Users\windows\Downloads\Cat'sCradle\Cat'sCradle.dll

using Tools;
using UnityEngine;

#nullable disable
namespace Cat_sCradle
{
  public class FlipNPCHandler : NPCRoomHandler
  {
    public string check;
    public int refer;
    public Sprite Second;
    public bool Shake = true;

    public virtual void PopulateRoom(
      IGameCheckData gameData,
      IMinimalRunInfoData runData,
      IMinimalZoneInfoData zoneData,
      int dataID)
    {
      DialogueDataReference dialogueDataReference = new DialogueDataReference(dataID, this._dialogueMusic);
      this._npcSelectable.SetClickData(Utils.startDialogNtf, (object) dialogueDataReference);
      this._extraSelectable.SetClickData(Utils.startDialogNtf, (object) dialogueDataReference);
      this._extraSelectable.HideItem();
      this.refer = dataID;
      this._entityData = zoneData.GetTalkingEntityData(dataID);
      if (!SavePerRun.Check(this.check))
        return;
      this.DoFlip();
    }

    public void DoFlip()
    {
      this._npcSelectable.HideItem();
      this._extraSelectable.ShowItem();
      if (!this.Shake)
        return;
      ScreenShake.Shake(0.25f);
    }
  }
}
