namespace Uddle.Router.Exception
{
	class NotExistControllerException : System.Exception
	{
        public NotExistControllerException(string exception)
            : base(exception)
        {
        }
	}
}
