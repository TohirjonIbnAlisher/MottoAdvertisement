namespace MottoAdver.Domain.Exceptions;

public class StrongPasswordVerifierValidation : Exception
{
	public StrongPasswordVerifierValidation(string message)
		: base(message)
	{
	}
}
