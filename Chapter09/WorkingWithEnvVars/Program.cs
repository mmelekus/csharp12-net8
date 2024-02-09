SectionTitle("Reading all environment varialbles for process");
IDictionary vars = GetEnvironmentVariables();
DictionaryToTable(vars);

SectionTitle("Reading all environment varialbes for machine");
IDictionary varsMaching = GetEnvironmentVariables(EnvironmentVariableTarget.Machine);
DictionaryToTable(varsMaching);

SectionTitle("Reading all environment variables for user");
IDictionary varsUser = GetEnvironmentVariables(EnvironmentVariableTarget.User);
DictionaryToTable(varsUser);

string myComputer = "My username = %USERNAME%. My CPU is %PROCESSOR_IDENTIFIER%.";
WriteLine(ExpandEnvironmentVariables(myComputer));

string password_key = "MY_PASSWORD";
SetEnvironmentVariable(password_key, "Pa$$w0rd");
string? password = GetEnvironmentVariable(password_key);
WriteLine($"{password_key}: {password}");