public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    public string StreetAddress
    {
        get => _streetAddress;
        set => _streetAddress = value;
    }

    public string City
    {
        get => _city;
        set => _city = value;
    }

    public string StateProvince
    {
        get => _stateProvince;
        set => _stateProvince = value;
    }

    public string Country
    {
        get => _country;
        set => _country = value;
    }

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    public bool IsInUSA()
    {
        return string.Equals(_country, "USA", StringComparison.OrdinalIgnoreCase);
    }

    public override string ToString()
    {
        return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
    }
}