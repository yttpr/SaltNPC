// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.MultiNPCRoomHandler
// Assembly: "Cat'sCradle", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0655AEEE-5A60-4F93-BDB6-92433D76888B
// Assembly location: C:\Users\windows\Downloads\Cat'sCradle\Cat'sCradle.dll

using System.Collections.Generic;
using Tools;
using UnityEngine;

#nullable disable
namespace Cat_sCradle
{
  public class MultiNPCRoomHandler : NPCRoomHandler
  {
    public string TalkExtra;
    public BaseRoomItem Artist;
    public string TalkArtist;
    public BaseRoomItem Chilly;
    public string TalkChilly;
    public BaseRoomItem Ember;
    public string TalkEmber;
    public BaseRoomItem Jub;
    public string TalkJub;
    public BaseRoomItem Peep;
    public string TalkPeep;
    public BaseRoomItem PeepWithGun;
    public string TalkLeftover;
    public string PeepFlipCheck;

    public virtual BaseRoomItem[] RoomSelectables
    {
      get
      {
        if (this._allSelectables == null)
          this.MoreGenerateAllSelectables();
        return this._allSelectables;
      }
    }

    public TalkingEntityContentData ContentExtra => new TalkingEntityContentData(this.TalkExtra);

    public TalkingEntityContentData ContentArtist => new TalkingEntityContentData(this.TalkArtist);

    public TalkingEntityContentData ContentChilly => new TalkingEntityContentData(this.TalkChilly);

    public TalkingEntityContentData ContentEmber => new TalkingEntityContentData(this.TalkEmber);

    public TalkingEntityContentData ContentJub => new TalkingEntityContentData(this.TalkJub);

    public TalkingEntityContentData ContentPeep => new TalkingEntityContentData(this.TalkPeep);

    public TalkingEntityContentData Leftover => new TalkingEntityContentData(this.TalkLeftover);

    public virtual void PopulateRoom(
      IGameCheckData gameData,
      IMinimalRunInfoData runData,
      IMinimalZoneInfoData zoneData,
      int dataID)
    {
      DialogueDataReference dialogueDataReference = new DialogueDataReference(dataID, this._dialogueMusic);
      this._npcSelectable.SetClickData(Utils.startDialogNtf, (object) dialogueDataReference);
      this._entityData = zoneData.GetTalkingEntityData(dataID);
      DialogueDataReference dialogueRef = new DialogueDataReference(-1, this._dialogueMusic);
      if (Object.op_Inequality((Object) this._extraSelectable, (Object) null))
        this._extraSelectable.SetClickData("ForceDialogeNotif", (object) new DialogueAndEntityContent(dialogueRef, this.ContentExtra));
      if (Object.op_Inequality((Object) this.Artist, (Object) null))
        this.Artist.SetClickData("ForceDialogeNotif", (object) new DialogueAndEntityContent(dialogueRef, this.ContentArtist));
      if (Object.op_Inequality((Object) this.Chilly, (Object) null))
        this.Chilly.SetClickData("ForceDialogeNotif", (object) new DialogueAndEntityContent(dialogueRef, this.ContentChilly));
      if (Object.op_Inequality((Object) this.Ember, (Object) null))
        this.Ember.SetClickData("ForceDialogeNotif", (object) new DialogueAndEntityContent(dialogueRef, this.ContentEmber));
      if (Object.op_Inequality((Object) this.Jub, (Object) null))
        this.Jub.SetClickData("ForceDialogeNotif", (object) new DialogueAndEntityContent(dialogueRef, this.ContentJub));
      if (Object.op_Inequality((Object) this.Peep, (Object) null))
        this.Peep.SetClickData("ForceDialogeNotif", (object) new DialogueAndEntityContent(dialogueRef, this.ContentPeep));
      if (Object.op_Inequality((Object) this.PeepWithGun, (Object) null))
        this.PeepWithGun.SetClickData("ForceDialogeNotif", (object) new DialogueAndEntityContent(dialogueRef, this.Leftover));
      if (!SavePerRun.Check(this.PeepFlipCheck))
        return;
      this.DoSwap();
    }

    public void DoSwap()
    {
      this.Peep.HideItem();
      this.PeepWithGun.ShowItem();
    }

    public void MoreGenerateAllSelectables()
    {
      List<BaseRoomItem> baseRoomItemList = new List<BaseRoomItem>();
      baseRoomItemList.Add(this._npcSelectable);
      if (Object.op_Inequality((Object) this._extraSelectable, (Object) null))
        baseRoomItemList.Add(this._extraSelectable);
      if (Object.op_Inequality((Object) this.Artist, (Object) null))
        baseRoomItemList.Add(this.Artist);
      if (Object.op_Inequality((Object) this.Chilly, (Object) null))
        baseRoomItemList.Add(this.Chilly);
      if (Object.op_Inequality((Object) this.Ember, (Object) null))
        baseRoomItemList.Add(this.Ember);
      if (Object.op_Inequality((Object) this.Jub, (Object) null))
        baseRoomItemList.Add(this.Jub);
      if (Object.op_Inequality((Object) this.Peep, (Object) null))
        baseRoomItemList.Add(this.Peep);
      if (Object.op_Inequality((Object) this.PeepWithGun, (Object) null))
        baseRoomItemList.Add(this.PeepWithGun);
      this._allSelectables = baseRoomItemList.ToArray();
    }
  }
}
