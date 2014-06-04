using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ViewModelKata.Domain.Tests
{
    public class ViewModelTests
    {
        [Fact]
        public void Initialize_ViewModelClass()
        {
            var sut = new ViewModel();
        }

        [Fact]
        public void CallTo_ShowMessage()
        {
            var called = false;
            var sut = new ViewModel();

            sut.ShowMessage += () => called = true;

            sut.OnShowMessage();
            Assert.True(called);
        }
    }
}
