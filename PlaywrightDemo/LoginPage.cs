using Microsoft.Playwright;

namespace PlaywrightDemo;

public class LoginPage
{
    private IPage _page;
    private readonly ILocator _linkLogin;
    private readonly ILocator _txtUsername;
    private readonly ILocator _txtPassword;
    private readonly ILocator _btnLogin;
    public  LoginPage(IPage page)
    {
        _page = page;
        _linkLogin = _page.GetByRole(AriaRole.Link, new() { NameString = "Login" });
        _txtUsername = _page.GetByLabel("UserName");
        _txtPassword = _page.GetByLabel("Password");
        _btnLogin = _page.GetByRole(AriaRole.Button, new() { NameString = "Log in" });
    }

    public async Task ClickLogin() => await _linkLogin.ClickAsync();

    public async Task Login(string username, string password)
    {
        await _txtUsername.FillAsync(username);
        await _txtPassword.FillAsync(password);
        await _btnLogin.ClickAsync();
    }
}