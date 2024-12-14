using System.Text.RegularExpressions;

namespace Inventify.Domain.ValueObjects
{
    public class Email
    {
        public Email(string value)
        {
            if (!IsValid(value))
            {
                throw new ArgumentException("Invalid email format", nameof(value));
            }

            Value = value;
        }

        public string Value { get; private set; }

        public static bool IsValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public override string ToString() => Value;
    }
}