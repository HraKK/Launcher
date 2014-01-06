namespace Uddle.Controller.Exception
{
	class NotExistActionException : System.Exception
	{
        public NotExistActionException(string exception)
            : base(exception)
        {
        }
	}
}
