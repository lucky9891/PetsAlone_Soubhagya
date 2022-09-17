using PetsAlone.Core;
using System;
using System.Linq;
using Xunit;

namespace PetsAlone.Test
{
    public class PetsServiceTest
    {
        [Fact]
        public void InsertPetTest()
        {
            //Arrange  
            var factory = new ConnectionFactory();

            //Get the instance of BlogDBContext
            var context = factory.CreateContextForSQLite();

            var post = new My_Pet_Class
            {
                Id = 1,
                Name = "test",
                PetType = 2,
                MissingSince = DateTime.Now.Subtract(TimeSpan.FromDays(6))
            };

            //Act  
            var data = context.Pets.Add(post);
            //Assert 
            Assert.NotNull(data.Entity);
            Assert.Equal(post.Name, data.Entity?.Name);
        }
    }
}
