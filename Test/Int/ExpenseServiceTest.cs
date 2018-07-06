using EfData;
using Service;
using Xunit;
using FluentAssertions;
using FluentAssertions.Common;


namespace Int
{
    public class ExpenseServiceTest:IntegrationTestBase
    {
        [Fact]
        public void CanCreateUser()
        {
            using (var context = GivenPremodemContext())
            {
                var expenseSerice = new ExpenseService(context);
                var amt =  expenseSerice.GetExpensesPageAsync(0,1).Result;
                amt.Records.Should().BeEmpty();

//                var user = userSerice.GetUserByEmail(
//                    "test@globalmantics.com");
//                context.SaveChanges();
//
//                user.UserId.Should().NotBe(0);
//                user.Email.Should().Be("test@globalmantics.com");
            }
        }
    }
}