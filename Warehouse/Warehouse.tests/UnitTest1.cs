using Warehouse.Domain.Entity;
using Warehouse.App.Concrete;
using Warehouse.App.Managers;
using Warehouse.App.Abstract;
using Moq;
using Xunit;
using FluentAssertions;

using System.ComponentModel;
using System.ComponentModel.Design;

namespace Warehouse.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arange
            Item item = new Item(1, "Apple", 2);
            var mock = new Mock<IService<Item>>();
            mock.Setup(s => s.GetItemById(1)).Returns(item);

            var manager = new ItemManager(new MenuActionService(), mock.Object);

            //Act
            var returnedItem = manager.GetItemById(item.Id);

            //Assert
            //Assert.Equal(item, returnedItem);
            returnedItem.Should().BeSameAs(item);
            returnedItem.Should().NotBeNull();
            returnedItem.Should().BeOfType(typeof(Item));

        }
    }
}