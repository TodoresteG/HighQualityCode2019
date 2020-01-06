namespace BoatRacingSimulator.Utility
{
    public static class Constants
    {
        public const string IncorrectModelLenghtMessage = "Model's name must be at least {0} symbols long.";

        public const string IncorrectPropertyValueMessage = "{0} must be a positive integer.";

        public const string IncorrectSailEfficiencyMessage = "Sail Effectiveness must be between [1...100].";

        public const string IncorrectEngineTypeMessage = "Incorrect engine type.";

        public const string DuplicateModelMessage = "An entry for the given model already exists.";

        public const string NonExistantModelMessage = "The specified model does not exist.";

        public const string RaceAlreadyExistsMessage = "The current race has already been set.";

        public const string NoSetRaceMessage = "There is currently no race set.";

        public const string InsufficientContestantsMessage = "Not enough contestants for the race.";

        public const string IncorrectBoatTypeMessage = "The specified boat does not meet the race constraints.";

        public const string EngineBoatCreatedMessage = "Engine model {0} with {1} HP and displacement {2} cm3 created successfully.";

        public const string RowBoatCreatedMessage = "Row boat with model {0} registered successfully.";

        public const string SailBoatCreatedMessage = "Sail boat with model {0} registered successfully.";

        public const string PowerBoatCreatedMessage = "Power boat with model {0} registered successfully.";

        public const string YachtCreatedMessage = "Yacht with model {0} registered successfully.";

        public const string SuccessfulOpenRaceMessage = "A new race with distance {0} meters, wind speed {1} m/s and ocean current speed {2} m/s has been set.";

        public const string BoatIsSignedSuccessful = "Boat with model {0} has signed up for the current Race.";

        public const string FirstPlaceMessage = "First place: {0} Model: {1} Time: {2}";

        public const string SecondPlaceMessage = "Second place: {0} Model: {1} Time: {2}";

        public const string ThirdPlaceMessage = "Third place: {0} Model: {1} Time: {2}";

        public const int MinBoatModelLength = 5;

        public const int MinBoatEngineModelLength = 3;
    }
}
