using NUnit.Framework;

namespace KataBankOCR.Test
{
    [TestFixture]
    public class CheckSumValidatorTest
    {
        [Test]
        public void Test_Valid()
        {
            var validator = new CheckSumValidator();
            Assert.IsTrue(validator.IsValid("457508000"));
        }
        
        [Test]
        public void Test_InValid()
        {
            var validator = new CheckSumValidator();
            Assert.IsFalse(validator.IsValid("664371495"));
        }
    }
}