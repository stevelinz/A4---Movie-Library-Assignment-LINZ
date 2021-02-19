using System;
using Xunit;


//namespace MovieLibrary.Tests
namespace A4___Movie_Library_Assignment_LINZ

{
    public class UnitTest1
    {
        [Fact]
        public void movieCountNotZero()
        {
          ActionSelected actionSelected = new ActionSelected();
          int testValue = actionSelected.friendlySelect();
          bool result = true;
          if(testValue < 1 || testValue > 3){
             result = false;
          }
          Assert.True(result, "Selects remain the same ");

        }
    }
}
