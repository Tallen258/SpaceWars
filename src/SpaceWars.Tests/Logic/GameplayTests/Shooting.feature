Feature: Shooting

How ships can shoot each other

Background:
	Given the following weapons
	| Weapon Name  | Range(s) | Damage(s) |
	| Basic Cannon | 5        | 10        |
	| Super Cannon | 10,20    | 20,10     |


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
	| Player 2    | 0 | 3 | 90      | 90     | 100    |
	When Player 1 shoots the Basic Cannon
	Then I have the following game state
	| Player Name | X | Y | Heading | Shield | Health |
	| Player 1    | 0 | 0 | 0       | 100    | 100    |
	| Player 2    | 0 | 3 | 90      | 80     | 100    |
	When Player 1 shoots the Super Cannon
	Then I have the following game state
	| Player Name | X | Y | Heading | Shield | Health |
	| Player 1    | 0 | 0 | 0       | 100    | 100    |
	| Player 2    | 0 | 3 | 90      | 60     | 100    |
