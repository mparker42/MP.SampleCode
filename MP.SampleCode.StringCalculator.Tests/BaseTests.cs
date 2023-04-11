using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.SampleCode.StringCalculator.Tests
{
    public class BaseTests
    {
        public readonly MockRepository _mockRepository;

        public BaseTests()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _mockRepository.VerifyNoOtherCalls();
        }
    }
}
