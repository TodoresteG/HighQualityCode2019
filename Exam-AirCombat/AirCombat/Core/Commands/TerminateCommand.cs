namespace AirCombat.Core.Commands
{
    using Contracts;
    using Entities.AirCrafts.Contracts;
    using Entities.Parts.Contracts;

    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    public class TerminateCommand : ICommand
    {
        private readonly IDictionary<string, IAirCraft> aircrafts;
        private readonly IList<string> defeatedAircrafts;
        private readonly IDictionary<string, IPart> parts;

        public TerminateCommand(IDictionary<string, IAirCraft> aircrafts,
                                IList<string> defeatedAircrafts,
                                IDictionary<string, IPart> parts)
        {
            this.aircrafts = aircrafts;
            this.defeatedAircrafts = defeatedAircrafts;
            this.parts = parts;
        }

        public string ExecuteCommand(IList<string> arguments)
        {
            StringBuilder finalResult = new StringBuilder();

            finalResult.Append("Remaining Aircrafts: ");

            if (this.aircrafts.Count > 0)
            {
                finalResult
                    .AppendLine(string.Join(", ",
                        this.aircrafts
                            .Values
                            .Select(v => v.Model)
                            .ToArray()));
            }
            else
            {
                finalResult.AppendLine("None");
            }

            finalResult.Append("Defeated Aircrafts: ");

            if (this.defeatedAircrafts.Count > 0)
            {
                finalResult
                    .AppendLine(string.Join(", ", this.defeatedAircrafts));
            }
            else
            {
                finalResult
                    .AppendLine("None");
            }

            finalResult
                .Append("Currently Used Parts: ")
                .Append(this.parts.Count);

            return finalResult.ToString();
        }
    }
}
