using System;
using System.Text;
using NUnit.Framework;

namespace KataMinesweeper
{
    [TestFixture]
    public class FieldReaderTest
    {
        [Test]
        public void Empty()
        {
            var reader = new FieldReader("");
            Assert.That(reader.HasMoreFields(), Is.False);
        }

        [Test]
        public void One_2x2()
        {
            var sb = new StringBuilder();
            sb.AppendLine("2 2");
            sb.AppendLine("**");
            sb.AppendLine("**");
            var reader = new FieldReader(sb.ToString());
            var output = reader.ReadField();
            Assert.That(output.Content, Is.EqualTo("**" + Environment.NewLine + "**" + Environment.NewLine));
        }
        
        [Test]
        public void Two_2x2()
        {
            var sb = new StringBuilder();
            sb.AppendLine("2 2");
            sb.AppendLine("**");
            sb.AppendLine("**");
            sb.AppendLine("2 2");
            sb.AppendLine("**");
            sb.AppendLine("**");
            var reader = new FieldReader(sb.ToString());
            var output = reader.ReadField();
            Assert.That(output.Content, Is.EqualTo("**" + Environment.NewLine + "**" + Environment.NewLine));
            output = reader.ReadField();
            Assert.That(output.Content, Is.EqualTo("**" + Environment.NewLine + "**" + Environment.NewLine));
        }
    }
}