namespace Uddle.Static.Exception
{
	class NotLoadedPackageException : System.Exception
	{
        public NotLoadedPackageException(string exception)
            : base(exception)
        { 
        }
	}
}
