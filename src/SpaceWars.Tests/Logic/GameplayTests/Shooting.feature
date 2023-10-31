Feature: Shooting

How ships can shoot each other

Background:

Scenario: Shoot a ship directly in front of you within range three times
	Given the following game state
	| Player Name | X | Y | Heading | Shield | Health |
	| Player 1    | 0 | 0 | 0       | 100    | 100    |
	| Player 2    | 0 | 3 | 90      | 100    | 100    |
	When Player 1 shoots the Basic Cannon
	And Player 1 shoots the Basic Cannon
	And Player 1 shoots the Basic Cannon
	Then I have the following game state
	| Player Name | X | Y | Heading | Shield | Health |
	| Player 1    | 0 | 0 | 0       | 100    | 100    |
	| Player 2    | 0 | 3 | 90      | 0      | 50     |



@tag1
Scenario: Shoot a ship directly in front of you within range
	Given the following game state
	| Player Name | X | Y | Heading | Shield | Health |
	| Player 1    | 0 | 0 | 0       | 100    | 100    |
	| Player 2    | 0 | 3 | 90      | 100    | 100    |
	When Player 1 shoots the Basic Cannon
	Then I have the following game state
	| Player Name | X | Y | Heading | Shield | Health |
	| Player 1    | 0 | 0 | 0       | 100    | 100    |
	| Player 2    | 0 | 3 | 90      | 50     | 100    |

Scenario: shoot twice
	Given the following game state
	| Player Name | X | Y | Heading | Shield | Health |
	| Player 1    | 0 | 0 | 0       | 100    | 100    |
	| Player 2    | 0 | 3 | 90      | 100    | 100    |
	When Player 1 shoots the Basic Cannon
	Then I have the following game state
	| Player Name | X | Y | Heading | Shield | Health |
	| Player 1    | 0 | 0 | 0       | 100    | 100    |
	| Player 2    | 0 | 3 | 90      | 50     | 100    |
	When Player 1 shoots the Basic Cannon
	Then I have the following game state
	| Player Name | X | Y | Heading | Shield | Health |
	| Player 1    | 0 | 0 | 0       | 100    | 100    |
	| Player 2    | 0 | 3 | 90      | 0      | 100    |

Scenario: shoot thrice
	Given the following game state
	| Player Name | X | Y | Heading | Shield | Health |
	| Player 1    | 0 | 0 | 0       | 100    | 100    |
	| Player 2    | 0 | 3 | 90      | 100    | 100    |
	When Player 1 shoots the Basic Cannon
	Then I have the following game state
	| Player Name | X | Y | Heading | Shield | Health |
	| Player 1    | 0 | 0 | 0       | 100    | 100    |
	| Player 2    | 0 | 3 | 90      | 50     | 100    |
	When Player 1 shoots the Basic Cannon
	Then I have the following game state
	| Player Name | X | Y | Heading | Shield | Health |
	| Player 1    | 0 | 0 | 0       | 100    | 100    |
	| Player 2    | 0 | 3 | 90      | 0      | 100    |
	When Player 1 shoots the Basic Cannon
	Then I have the following game state
	| Player Name | X | Y | Heading | Shield | Health |
	| Player 1    | 0 | 0 | 0       | 100    | 100    |
	| Player 2    | 0 | 3 | 90      | 0      | 50     |
