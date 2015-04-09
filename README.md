# ChallongeCSharpDriver

## Requirements

.NET 4.5, an internet connection

## Basic set-up for the library

Include the DLLs in the "ChallongeCSharpDriver/Library" folder in your project, and start using the library !

Please note it is using .NET 4.5 async/await functionality. You should document yourself a minimum on this before trying to use this library

### Easy mode

1. Include 
	* using ChallongeCSharpDriver.Caller;
	* using ChallongeCSharpDriver.Main;
2. Create a new ChallongeConfig with your own configuration.
3. Pass the config to a new ChallongeAPICaller
4. Pass the Caller to a new Tournaments

You can now "navigate" through all the different available objects with convenient calls.

For example, 

> List\<StartedTournament\> tournamentList = await tournaments.getStartedTournaments();

should get you a list of all the started tournaments available from your API_KEY

Or you could just get one by calling 

> StartedTournament tournament = await tournaments.getTournament(ID);

Note that using Interfaces available directly in the Main package is strongly recommended for convenience.

### Hard mode

Use objects directly from the core.

Create queries from Core.Queries, and invoke the "call" method using the caller.

For example,

> List<MatchResult> matches = await new TournamentMatchesQuery(TOURNAMENTID) { matchState = MatchState.Open }.call(caller);

lists all Open matches in the specified tournament. It returns plain objects that can be modified in every ways.

### Insane mode (not suggested at all, better ask me to add it to the library)

Use the caller directly.

For example,

> TournamentQueryResult tournamentQueryResult = caller.CallAPI\<TournamentQueryResult\>("tournaments/ID", parameters)

should get the information and fill TournamentQueryResult, which is a container that can fulfill the API response

## Basic set-up for the example

Create a file named "challongeCSharpDriver.config" in your "My Documents" folder, and put your Challonge api key like this :

api_key=INSERT_YOUR_API_KEY_HERE

You can then mess with the simple Windows Forms there to try out some functions quickly.

## Want a new feature ?

Just suggest it to me. 

## Want to contribute ? 

That's even better !
