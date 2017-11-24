using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;

namespace VueJsAspNetCore
{
  /// <summary>
  /// The program.
  /// </summary>
  public static class Program
  {
    /// <summary>
    /// The main method.
    /// </summary>
    /// <param name="args">The arguments.</param>
    public static void Main(string[] args)
    {
      var arguments = GetArgumentsAsDictionary(args);

      IWebHost host;
      if (arguments.ContainsKey("useHttps") && arguments["useHttps"] == "true")
      {
        host = new WebHostBuilder()
            .UseKestrel(
                options =>
                {
                  options.UseHttps("localhost.pfx", "W!nvisi0n");
                })
            .UseUrls("http://*:5000", "https://*:44300")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>()
            .Build();
      }
      else
      {
        host = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>()
            .Build();
      }

      host.Run();
    }

    /// <summary>
    /// Gets the arguments as a dictionary.
    /// </summary>
    /// <param name="args">The arguments.</param>
    /// <returns>
    /// A <see cref="Dictionary{TKey,TValue}" /> of the arguments.
    /// </returns>
    private static Dictionary<string, string> GetArgumentsAsDictionary(IEnumerable<string> args)
    {
      return args.Select(a => a.Split('=')).ToDictionary(a => a[0].Trim('-'), a => a.Length > 1 ? a[1] : "true");
      ////return args.ToDictionary(a => a.Substring(2, a.IndexOf('=') - 2), a => a.Substring(a.IndexOf('='), a.Length - a.IndexOf('=') - 1));
    }
  }
}
