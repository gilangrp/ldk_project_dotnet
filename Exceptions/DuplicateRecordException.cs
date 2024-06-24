namespace LDKProject.Exceptions;

[Serializable]
public class DuplicateRecordException : Exception
    {
        public DuplicateRecordException() : base() { }
        public DuplicateRecordException(string message) : base(message) { }
        public DuplicateRecordException(string message, Exception inner) : base(message, inner) { }
    }


