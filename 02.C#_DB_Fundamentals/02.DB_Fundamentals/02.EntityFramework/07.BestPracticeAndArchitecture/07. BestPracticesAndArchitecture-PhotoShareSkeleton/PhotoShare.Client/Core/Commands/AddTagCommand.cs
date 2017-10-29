namespace PhotoShare.Client.Core.Commands
{
    using Attributes;
    using Data;
    using Data.Interfaces;
    using Models;
    using System.Data.Entity;
    public class AddTagCommand : Command
    {
        public AddTagCommand(string[] data) : base(data)
        {
        }

        //AddTag <tag>
        public override string Execute()
        {
            string tag = TagUtilities.ValidateOrTransform(Data[1]);

            this.unit.Tags.Add(new Tag
            {
                Name = tag
            });

            return tag + " was added sucessfully to database";
        }
    }
}
