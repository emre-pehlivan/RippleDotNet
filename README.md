# RippleDotNet
A C# NetStandard 2.0 client for of the [Ripple WebSocket APIs](https://ripple.com/build/rippled-apis/#websocket-api).

This library is written to the NetStandard2 specification, which means that it can run using .Net Core on Windows, Mac OS/X and Unix.  I'm only testing it on Windows however, so I'd appreciate any feedback on other platforms.

This library is in the early stages of development and is currently not very useful. Most of the implemented functionlity is in the Account area.  There is no support yet for transactions or actually moving XRP and issuances around.

## Example

```csharp
IRippleClient client = new RippleClient("wss://s1.ripple.com:443");
client.Connect();
RippleDotNet.Model.Accounts.AccountInfo accountInfo = await client.AccountInfo("rPGKpTsgSaQiwLpEekVj1t5sgYJiqf2HDC");
client.Disconnect();
```
You can see additional examples by looking at the unit test project.

Ripple contributions gratefully accepted at rPGKpTsgSaQiwLpEekVj1t5sgYJiqf2HDC (~ChrisW).
  
