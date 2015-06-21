
namespace ChallongeCSharpDriverTest {
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Net.Http;
    using ChallongeCSharpDriver.Caller;
    using ChallongeCSharpDriver.Core.Queries;
    using Moq;
    using System.Threading.Tasks;
    using System.IO;
    using ChallongeCSharpDriver.Core.Results;
    [TestClass]
    public class TournamentQueryTest {
       /* private static readonly int ANY_TOURNAMENT_ID = 5310951;
        private static readonly string BASICJSON = "{\"tournament\":{\"id\":1580436,\"name\":\"test\"}}";

        TournamentQuery tournamentQuery = new TournamentQuery(ANY_TOURNAMENT_ID);
        Mock<ChallongeHTTPClientAPICaller> mockCaller = new Mock<ChallongeHTTPClientAPICaller>();

        [TestMethod]
        public void CallShouldCallAPI() {
            Task<TournamentResult> result = new Task<TournamentResult>();

            mockCaller.Setup(caller => caller.CallAPI<TournamentResult>("tournaments/" + ANY_TOURNAMENT_ID)).Returns(result);

            ChallongeHTTPClientAPICaller challongeCaller = mockCaller.Object;

            Task<TournamentResult> tournamentResult = tournamentQuery.call(challongeCaller);
        }*/
    }
}
