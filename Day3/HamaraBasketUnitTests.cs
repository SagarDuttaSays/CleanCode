using NUnit.Framework;
using System.Collections.Generic;

namespace hamaraBasket
{
    [TestFixture]
    public class HamaraBasketUnitTests
    {
        HamaraBasket app;
        IList<Item> items;
        int sellIn = 10;
        int quality = 10;

        [Test]
        public void ShouldReduceSellInValueByOneEOD()
        {
            //Arrange
            items = HamaraBasket.CreateHamaraBasketList("Apples", sellIn, quality);
            app = HamaraBasket.CreateHamaraBasket(items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.That(items[0].SellIn, Is.EqualTo(sellIn-1));
        }

        [Test]
        public void ShouldReduceQualityValueByOneEOD()
        {
            //Arrange
            items = HamaraBasket.CreateHamaraBasketList("Apples", sellIn, quality);
            app = HamaraBasket.CreateHamaraBasket(items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.That(items[0].Quality, Is.EqualTo(quality - 1));
        }

        [Test]
        public void ShouldReduceQualityValueByTwoAfterSellInHasPassed()
        {
            //Arrange
            items = HamaraBasket.CreateHamaraBasketList("Apples", 1, quality);
            app = HamaraBasket.CreateHamaraBasket(items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.That(items[0].SellIn, Is.EqualTo(0));
            Assert.That(items[0].Quality, Is.EqualTo(quality - 2));
        }

        [Test]
        public void ShouldNotLetQualityGetNegative()
        {
            //Arrange
            items = HamaraBasket.CreateHamaraBasketList("Apples", sellIn, -1);
            app = HamaraBasket.CreateHamaraBasket(items);

            //Act & Assert
            var ex = Assert.Throws<Exception>(() => app.UpdateQuality());

            //Assert the exception message
            Assert.That(ex.Message, Is.EqualTo("Quality cannot be negative."));
        }

        [Test]
        public void ShouldNotLetQualityGetMoreThan50()
        {
            //Arrange
            items = HamaraBasket.CreateHamaraBasketList("Apples", sellIn, 50);
            app = HamaraBasket.CreateHamaraBasket(items);

            //Act & Assert
            var ex = Assert.Throws<Exception>(() => app.UpdateQuality());

            //Assert the exception message
            Assert.That(ex.Message, Is.EqualTo("Quality cannot be more than 50."));
        }

        [TestCase("Indian Wine")]
        [TestCase("Movie Tickets")]
        public void ShouldIncreaseIndianWineQualityValueEOD(string ProductName)
        {
            //Arrange
            items = HamaraBasket.CreateHamaraBasketList(ProductName, sellIn, quality);
            app = HamaraBasket.CreateHamaraBasket(items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.That(items[0].Quality, Is.GreaterThan(quality));
        }

        [Test]
        public void ShouldNotDecreaseForestHoneyQualityValueEOD()
        {
            //Arrange
            items = HamaraBasket.CreateHamaraBasketList("Forest Honey", sellIn, quality);
            app = HamaraBasket.CreateHamaraBasket(items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.That(items[0].Quality, Is.EqualTo(quality));
        }
        [Test]
        public void ShouldIncreaseQualityBy2When10OrLessDaysAreLeft()
        {
            //Arrange
            items = HamaraBasket.CreateHamaraBasketList("Apples", 10, quality);
            app = HamaraBasket.CreateHamaraBasket(items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.That(items[0].Quality, Is.EqualTo(quality+2));
        }
        [Test]
        public void ShouldIncreaseQualityBy3When5OrLessDaysAreLeft()
        {
            //Arrange
            items = HamaraBasket.CreateHamaraBasketList("Apples", 5, quality);
            app = HamaraBasket.CreateHamaraBasket(items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.That(items[0].Quality, Is.EqualTo(quality + 3));
        }
        [Test]
        public void ShouldDecreaseQualityValueToZeroWhenZeroDaysAreLeft()
        {
            //Arrange
            items = HamaraBasket.CreateHamaraBasketList("Apples", 0, quality);
            app = HamaraBasket.CreateHamaraBasket(items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.That(items[0].Quality, Is.EqualTo(0));
        }
    }
}
