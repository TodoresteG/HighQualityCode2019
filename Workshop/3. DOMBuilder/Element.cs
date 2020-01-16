namespace DOMBuilder
{
    using Contracts;

    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    public class Element : IElement
    {
        private List<IElement> children;

        public Element(string type, params IElement[] children)
        {
            this.Type = type;
            this.children = children.ToList();
        }

        public string Type { get; private set; }

        //public ICollection<IElement> Children => this.children.AsReadOnly();

        public void Add(IElement element)
        {
            this.ValidateForNullElements(element);
            this.children.Add(element);
        }

        public string Display()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"<{this.Type}>");

            foreach (var element in this.children)
            {
                sb.AppendLine(element.Display());
            }

            sb.AppendLine($"</{this.Type}>");

            return sb.ToString().TrimEnd();
        }

        public void Remove(IElement element)
        {
            this.ValidateForNullElements(element);

            if (!this.children.Contains(element))
            {
                throw new ArgumentException("This child is present in the DOM");
            }

            this.children.Remove(element);
        }

        private void ValidateForNullElements(IElement element) 
        {
            if (element == null)
            {
                throw new ArgumentException("Element cannot be null");
            }
        }
    }
}
