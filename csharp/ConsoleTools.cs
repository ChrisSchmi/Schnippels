using System;

string GetConsoleAppStartupPath()
{
  var applicationStartupPath = AppDomain.CurrentDomain.BaseDirectory;
  return applicationStartupPath;
}
