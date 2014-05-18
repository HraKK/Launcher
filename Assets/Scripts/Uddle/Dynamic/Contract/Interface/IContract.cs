namespace Uddle.Dynamic.Contract.Interface
{
	interface IContract
	{
        bool Start();
        bool Finish();
        bool Skip();

        string GetError();
	}
}
