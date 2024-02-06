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
	| Player 2    | 0 | 3 | 90      | 94     | 100    |



@tag1
Scenario: Shoot a ship directly in front of you within range
	Given the following game state
	| Player Name | X | Y | Heading | Shield | Health |
	| Player 1    | 0 | 0 | 0       | 100    | 100    |
	| Player 2    | 0 | 3 | 90      | 100    | 100    |
	When Player 1 shoots the Basic Cannon
	Then I have the following game state
	| Player Name | X | Y | Shield | Health |
	| Player 1    | 0 | 0 | 100    | 100    |
	| Player 2    | 0 | 3 | 98     | 100    |

Scenario: shoot twice
	Given the following game state
	| Player Name | X | Y | Heading | Shield | Health |
	| Player 1    | 0 | 0 | 0       | 100    | 100    |
	| Player 2    | 0 | 3 | 90      | 100    | 100    |
	When Player 1 shoots the Basic Cannon
	Then I have the following game state
	| Player Name | X | Y | Heading | Shield | Health |
	| Player 1    | 0 | 0 | 0       | 100    | 100    |
	| Player 2    | 0 | 3 | 90      | 98     | 100    |
	When Player 1 shoots the Basic Cannon
	Then I have the following game state
	| Player Name | X | Y | Shield | Health |
	| Player 1    | 0 | 0 | 100    | 100    |
	| Player 2    | 0 | 3 | 96     | 100    |

Scenario: shoot thrice
	Given the following game state
	| Player Name | X | Y | Heading | Shield | Health |
	| Player 1    | 0 | 0 | 0       | 100    | 100    |
	| Player 2    | 0 | 3 | 90      | 100    | 100    |
	When Player 1 shoots the Basic Cannon
	Then I have the following game state
	| Player Name | X | Y | Shield | Health |
	| Player 1    | 0 | 0 | 100    | 100    |
	| Player 2    | 0 | 3 | 98     | 100    |
	When Player 1 shoots the Basic Cannon
	Then I have the following game state
	| Player Name | X | Y | Shield | Health |
	| Player 1    | 0 | 0 | 100    | 100    |
	| Player 2    | 0 | 3 | 96     | 100    |
	When Player 1 shoots the Basic Cannon
	Then I have the following game state
	| Player Name | X | Y | Shield | Health |
	| Player 1    | 0 | 0 | 100    | 100    |
	| Player 2    | 0 | 3 | 94     | 100    |

Scenario: shoot power fist
	Given the following game state
	| Player Name | X | Y | Heading | Shield | Health | Additional Weapons |
	| Player 1    | 0 | 0 | 0       | 100    | 100    | Power Fist         |
	| Player 2    | 0 | 3 | 90      | 100    | 100    |                    |
	And Player 1 shoots the Power Fist
	Then I have the following game state
	| Player Name | X | Y | Shield | Health |
	| Player 1    | 0 | 0 | 100    | 100    |
	| Player 2    | 0 | 3 | 67     | 100    |
	When Player 1 shoots the Power Fist
	When Player 1 shoots the Power Fist
	When Player 1 shoots the Power Fist
	When Player 1 shoots the Power Fist
	When Player 1 shoots the Power Fist
	When Player 1 shoots the Power Fist
	Then I have the following game state
	| Player Name | X | Y | Shield | Health |
	| Player 1    | 0 | 0 | 100    | 100    |
	| Player 2    | 0 | 3 | 0      | 12     |
