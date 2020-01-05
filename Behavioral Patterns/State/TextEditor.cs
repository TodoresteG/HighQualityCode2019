namespace State
{
    public class TextEditor
    {
        private IWritingState writingState;

        public TextEditor()
        {
            this.writingState = new DefaultText();
        }

        public void SetState(IWritingState state) 
        {
            this.writingState = state;
        }

        public void Type(string words) 
        {
            this.writingState.Write(words);
        }
    }
}
