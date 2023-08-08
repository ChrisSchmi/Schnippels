public int GetQuarterOfYear()
{
	var month = DateTime.Now.Month;
	
	if(month < 4)
	{
		return 1;
	}
	
	if(month > 3 && month < 7)
	{
		return 2;
	}
	
	if(month > 6 && month < 10)
	{
		return 3;
	}
	
	if(month > 9)
	{
		return 4;
	}
	
	return 0;
}