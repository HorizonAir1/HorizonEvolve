using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Database;

namespace DatabaseTests
{
    public class PassengerTests
    {
        
            [Fact]
            public void cancel()
            {
                //Arrange

                //Act
                var b = Passenger.cancelFly(1, 1);


                //Assert
                Assert.True(b);

            }
            [Fact]
            public void modify()
            {
                //Arrange

                //Act
                var b = Passenger.modifyFly(1, 1, 25);

                //Assert
                Assert.True(b);

            }
        
    }
}
