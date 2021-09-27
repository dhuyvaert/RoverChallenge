using Xunit;
using VehicleCommander.Utility;

namespace VehicleCommander.Services.Tests
{
    public class ValidationTests
    {
        [Fact()]
        public void ValidateMovementCommands_Success()
        {
            var validated = Validation.ValidateMovementCommands("LRM");
            Assert.True(validated);
        }

        [Fact()]
        public void ValidateMovementCommands_Success_LowerCase()
        {
            var validated = Validation.ValidateMovementCommands("mlr");
            Assert.True(validated);
        }

        [Fact()]
        public void ValidateMovementCommands_Failure()
        {
            var validated = Validation.ValidateMovementCommands("WER");
            Assert.False(validated);
        }

        [Fact()]
        public void ValidateMovementCommands_Failure_LowerCase()
        {
            var validated = Validation.ValidateMovementCommands("yup");
            Assert.False(validated);
        }

        [Fact()]
        public void ValidateMovementCommands_Failure_PartialCorrect()
        {
            var validated = Validation.ValidateMovementCommands("yum");
            Assert.False(validated);
        }
    }
}