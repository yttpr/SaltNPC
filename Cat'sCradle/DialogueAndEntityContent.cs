// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.DialogueAndEntityContent
// Assembly: "Cat'sCradle", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0655AEEE-5A60-4F93-BDB6-92433D76888B
// Assembly location: C:\Users\windows\Downloads\Cat'sCradle\Cat'sCradle.dll

#nullable disable
namespace Cat_sCradle
{
  public class DialogueAndEntityContent
  {
    public DialogueDataReference dialogueRef;
    public TalkingEntityContentData entityContent;

    public DialogueAndEntityContent(
      DialogueDataReference dialogueRef,
      TalkingEntityContentData entityContent)
    {
      this.dialogueRef = dialogueRef;
      this.entityContent = entityContent;
    }
  }
}
