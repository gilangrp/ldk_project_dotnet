namespace LDKProject.Exceptions;

[Serializable]
public class InvalidRoleException : Exception
    {
        public InvalidRoleException() : base() { }
        public InvalidRoleException(string message) : base(message) { }
        public InvalidRoleException(string message, Exception inner) : base(message, inner) { }
    }

