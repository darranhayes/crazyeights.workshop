module Game

open System
open Xunit
open Deck
open Game
open Swensen.Unquote

// Step 3:
// Implement => to make the test run
// We use List.fold with evolve, initialized and given events
// fold start from the initialState, and for each event, call
// evolve with the state and the event to compute a new state
// The fold returns current state. We pass it to decide with
// the command to get a list of the events
let (=>) events command = 
    events
    |> List.fold evolve initialState
    |> decide command
    

let (==) = (=)

let notImplemented() = failwith "No implemented"

// Step 4:
// Change the decide function to make this test pass

// we just have to return a GameStarted event every time in decide
[<Fact>]
let ``Game should start`` () =
    test 
        <@ []
           => StartGame { FirstCard = Three ^ Club ; Players = Players 4 }
           == [GameStarted { FirstCard = Three ^ Club; Players = Players 4 }] @>


// Step 5:
// Change the decide function to make this test pass

// we can do basic validation in the decide function
// notice that this exception should never actually happen
// since the game interface would prevent starting the game
// when there are less than 2 players
// we still enforce the check in case of a bug, or if a user
// with bad intention tries to trick the system
// we could also avoid validation in the decide function
// by validating the data in the Players structure's constructor
[<Fact>]
let ``Playing alone is not fun`` () =
    raises<TooFewPlayersException> 
        <@ []
            => StartGame { Players = Players 1; FirstCard = Four ^ Diamond }
        @>

// Step 6:
// What should you change to make this test pass ?

// we create a GameAlreadyStartedException
// but this time we need to remember that the game already started
// to take the decision
// we add a Started case to the State type
// now we can take a different decision in decide depending on the
// current state
// of course we have to also modify evolve to that state becomes
// Started after a GameStarted event
[<Fact>]
let ``Game should not be started twice``() =
    raises<GameAlreadyStartedException>
        <@ [ GameStarted { Players= Players 2; FirstCard = Six ^ Spade } ]
            => StartGame { Players = Players 3; FirstCard = Ace ^ Heart }
        @>


// Step 7:
// Make this two tests pass... doing the simplest thing that work
[<Fact>]
let ``Card with same value can be played``() =
    notImplemented()

[<Fact>]
let ``Card with same suit can be played``() =
    notImplemented()

// Step 8:
// Make this test pass
[<Fact>]
let ``Card can be played only once game is started``() =
    notImplemented()

// Step 9:
// What happens here ?!
[<Fact>]
let ``Card should be same suit or same value``() =
    notImplemented()
    // ...

// Step 10:
// What happens here ?!
[<Fact>]
let ``Player should play during her turn``() =
    notImplemented()


[<Fact>]
let ``After a table round, the dealer turn plays``() =
    notImplemented()

// Step 12:
// Look at the evolve function...
// It starts to contains logic.
// Try to remove the logic from the evolve function 
// to put it back in the decide function 


// Step 13:
// Seven skips next player turn
[<Fact>]
let ``Seven skips next player turn``() =
    notImplemented()


// Step 14:
// Jack flip direction
[<Fact>]
let ``Jack flip direction``() =
    notImplemented()


// Step 15:
// Make this test pass
[<Fact>]
let ``Player can interrupt``() =
    notImplemented()

// Step 16:
// Missing an interrupt is not concidered as playing at the wrong turn.
// So what happens here ?
[<Fact>]
let ``Player get no penalty when missing an interrupt``() =
    notImplemented()


