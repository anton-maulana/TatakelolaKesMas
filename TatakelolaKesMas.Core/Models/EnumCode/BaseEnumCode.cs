namespace TatakelolaKesMas.Core.Models.EnumCode;

public class BaseEnumCode
{
    protected BaseEnumCode(string code)
    {
        if (string.IsNullOrEmpty(code))
        {
            throw new ArgumentNullException(nameof(code));
        }

        Code = code;
    }
    public string Code { get; }

    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (obj is string)
        {
            return Code.Equals(obj);
        }

        if (obj is BaseEnumCode)
        {
            return Code.Equals(((BaseEnumCode)obj).Code);
        }

        return false;
    }

    public override int GetHashCode() => Code != null ? Code.GetHashCode() : 0;
    
}