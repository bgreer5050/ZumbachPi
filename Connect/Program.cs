using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

namespace Connect
{
    class Program
    {
        static void Main(string[] args)
        {
            PowerShell ps = PowerShell.Create();
            Runspace runSpace = RunspaceFactory.CreateRunspace();
            runSpace.Open();

            ps.Runspace = runSpace;
            ps.AddCommand("Invoke-Expression");
            ps.AddArgument("net start WinRM");
            ps.Invoke();
            ps.AddCommand(@"Set-Item WSMan:\localhost\Client\TrustedHosts -Value 10.0.199.139");
            ps.Invoke();

            ps.AddArgument(@"Enter - PSSession - ComputerName 10.0.199.139 - Credential 10.0.199.139\Administrator");
            ps.Invoke();
            runSpace.Close();

        }
    }
}
