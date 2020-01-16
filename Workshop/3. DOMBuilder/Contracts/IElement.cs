namespace DOMBuilder.Contracts
{
    using System.Collections.Generic;

    public interface IElement
    {
        string Type { get; }

        //ICollection<IElement> Children { get; }

        void Add(IElement element);

        void Remove(IElement element);

        string Display();
    }
}
