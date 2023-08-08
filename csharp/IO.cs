using System.IO;
       
private byte[] GetBytes(Stream sourceStream)
{
	try
	{
		using (var memoryStream = new MemoryStream())
		{
			sourceStream.CopyTo(memoryStream);
			return memoryStream.ToArray();
		}
	}
	catch(Exception)
	{
		return null;
	}
}