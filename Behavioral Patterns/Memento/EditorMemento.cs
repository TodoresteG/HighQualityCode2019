namespace Memento
{
    public class EditorMemento
    {
        private string content;

        public EditorMemento(string content)
        {
            this.content = content;
        }

        public string Content 
        {
            get { return this.content; }
        }
    }
}
