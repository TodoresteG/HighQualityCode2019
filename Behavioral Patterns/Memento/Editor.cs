namespace Memento
{
    using System;

    public class Editor
    {
        private string content = string.Empty;
        private EditorMemento memento;

        public Editor()
        {
            this.memento = new EditorMemento(string.Empty);
        }

        public string Content
        {
            get { return this.content; }
        }

        public void Type(string words)
        {
            this.content = String.Concat(this.content, " ", words);
        }

        public void Save()
        {
            this.memento = new EditorMemento(this.content);
        }

        public void Restore() 
        {
            this.content = this.memento.Content;
        }
    }
}
