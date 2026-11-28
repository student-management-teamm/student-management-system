namespace StudentManagementWinForms
{
    public static class UserSession
    {
        public static long UserId { get; private set; }

        public static string Username { get; private set; } = string.Empty;

        public static string Role { get; private set; } = string.Empty;

        public static bool IsAuthenticated =>
            UserId > 0 &&
            !string.IsNullOrWhiteSpace(Username);

        public static void Start(long userId, string username, string role)
        {
            UserId = userId;
            Username = username;
            Role = role;
        }

        public static void End()
        {
            UserId = 0;
            Username = string.Empty;
            Role = string.Empty;
        }
    }
}   