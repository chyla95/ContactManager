namespace api.Utilities.Accessors
{
    public class EnvironmentVariablesAccessor : IEnvironmentVariablesAccessor
    {
        public string GetVariable(string key)
        {
            string? value = Environment.GetEnvironmentVariable(key);
            if (string.IsNullOrEmpty(value)) throw new NullReferenceException($"Variable {key} not found!");

            return value;
        }
    }
}
