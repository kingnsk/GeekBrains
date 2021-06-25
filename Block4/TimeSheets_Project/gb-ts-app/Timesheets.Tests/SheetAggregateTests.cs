using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace Timesheets.Tests
{
    public class SheetAggregateTests
    {
        public static Guid EmployeeId1 = Guid.Parse("079365ab-b1ba-46be-a8a9-5de0977cefc8");

        [Fact]
        public void SheetAggregate_CreateRandomFromSheetRequest()
        {
            var builder = new SheetAggregateBuilder();
            var sheet = builder.CreateRandomSheet();

            sheet.Amount.Should().Be(8);
            sheet.ContractId.Should().Be(builder.SheetContractId);
            sheet.ServiceId.Should().Be(builder.SheetServiceId);
            sheet.EmployeeId.Should().Be(builder.SheetEmployeeId);
            sheet.Date.Should().BeExactly(TimeSpan.FromSeconds(DateTimeOffset.Now.ToUnixTimeSeconds()));

        }

        [Fact]
        public void SheetAggregate_WhenApproved_IsApprovedIsTrue()
        {
            //arrange
            var builder = new SheetAggregateBuilder();
            var sheet = builder.CreateRandomSheet();

            //act
            sheet.ApproveSheet();

            //assert
            sheet.IsApproved.Should().BeTrue();
            sheet.ApprovedDate.Should().BeExactly(TimeSpan.FromSeconds(DateTimeOffset.Now.ToUnixTimeSeconds()));
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void ShetAggregate_Changing_EmployeeId(Guid newEmployeeId)
        {
            //arrange
            var builder = new SheetAggregateBuilder();
            var sheet = builder.CreateRandomSheet();

            sheet.ChangeEmployee(newEmployeeId);

            sheet.EmployeeId.Should().Be(newEmployeeId);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { EmployeeId1 };
        }
    }
}
