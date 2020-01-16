namespace DOMBuilder
{
    using Contracts;

    public class Program
    {
        public static void Main()
        {
            IElement html = new Element("html", 
                                new Element("head"),
                                new Element("body", 
                                    new Element("section", 
                                        new Element("h2"),
                                        new Element("p"),
                                        new Element("span")),
                                    new Element("footer")));

            System.Console.WriteLine(html.Display());
        }
    }
}
