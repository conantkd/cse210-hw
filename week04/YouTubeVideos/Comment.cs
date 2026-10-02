class Comment
{
    private string _userName;
    private string _text;

    public string UserName { get { return _userName; } }
    public string Text { get { return _text; } }

    public Comment(string userName, string text)
    {
        _userName = userName;
        _text = text;
    }
}