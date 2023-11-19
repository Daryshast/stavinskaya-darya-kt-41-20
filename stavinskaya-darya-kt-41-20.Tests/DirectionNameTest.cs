using stavinskaya_darya_kt_41_20.Models;

namespace stavinskaya_darya_kt_41_20.Tests
{
    public class DirectionNameTest
    {
        [Fact]
        public void DisciplineNameTest_Kt ()
        {
            // Arrange
            var testDirection = new Direction
            {
                DirectionId = 1,
                DirectionName = "Техническое",
            };
            // Act
            var result = testDirection.isValidDirectionName();
            // Assert
            Assert.True(result);

        }
    }
}