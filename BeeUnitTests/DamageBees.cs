using Bees.Data;
using Bees.Pages;
using Xunit;

namespace BeeUnitTests
{
    public class DamageBees
    {
        public enum BeeType
        {
            Queen,
            Worker,
            Drone
        }

        [Theory]
        [InlineData(BeeType.Worker, 10, false)]
        [InlineData(BeeType.Worker, 31, true)]
        [InlineData(BeeType.Queen, 10, false)]
        [InlineData(BeeType.Queen, 81, true)]
        [InlineData(BeeType.Drone, 10, false)]
        [InlineData(BeeType.Drone, 51, true)]
        public void Bee_dead_status_should_update_with_damage(BeeType type, int damage, bool dead)
        {
            var bee = new Bee
            {
                BeeType = (Bees.Data.BeeType)type,
                Health = 100,
                Name = "Test bee"
            };

            var beeService = new IndexBase();
            beeService.DamageBee(bee, damage);
            Assert.Equal(dead, bee.Dead);
        }

        [Fact]
        public void Health_should_not_go_down_if_bee_is_dead()
        {
            var bee = new Bee
            {
                BeeType = Bees.Data.BeeType.Drone,
                Health = 25,
                Name = "Test bee",
                Dead = true
            };

            var beeService = new IndexBase();
            beeService.DamageBee(bee, 150);
            Assert.Equal(25, bee.Health);
        }
    }
}
