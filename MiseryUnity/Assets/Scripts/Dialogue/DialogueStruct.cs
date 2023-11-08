[System.Serializable]
public class DialogueStruct
{
    public string[] text;
    public bool isInteractive;
    public string optionA;
    public string optionB;

    public DialogueStruct(string[] text, bool isInteractive, string optionA, string optionB)
    {
        this.text = text;
        this.isInteractive = isInteractive;
        this.optionA = optionA;
        this.optionB = optionB;
    }
}
