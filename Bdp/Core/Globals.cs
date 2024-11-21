namespace Bdp.Core
{
    public static class Globals
    {
        public struct Pages
        {
            public const string ManageFeedback = "/ManageFeedback";
        }

        public struct ValidationMessages
        {
            public const string CustomerNameRequired = "Customer name is required.";
            public const string CustomerNameMaxLength = "Customer name cannot exceed 100 characters.";
            public const string FeedbackRequired = "Feedback message is required.";
            public const string FeedbackMaxLength = "Feedback message cannot exceed 500 characters.";
            public const string DateSubmittedRequired = "Date submitted is required.";
            public const string InvalidDateFormat = "Invalid date format.";
        }
    }
}
