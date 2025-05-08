namespace BookApp.Utils;

public class EmailChecker
{
    /// <summary>
    /// Validates the format of an email address.
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public bool IsValidEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return false;
        }

        if (!email.Contains("@") || !email.Contains("."))
        {
            return false;
        }

        string[] parts = email.Split('@');
        if (parts.Length != 2 || string.IsNullOrEmpty(parts[0]) || string.IsNullOrEmpty(parts[1]))
        {
            return false;
        }

        string[] domainParts = parts[1].Split('.');
        if (domainParts.Length < 2 || string.IsNullOrEmpty(domainParts[0]) || string.IsNullOrEmpty(domainParts[1]))
        {
            return false;
        }

        return true;
    }
}