using System;
using Shell32;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

internal class Translnkte
{
    static string ResolveLink(string lnk)
    {
        Shell s = new Shell();
        var filename = Path.GetFileName(lnk);
        var dirname = Path.GetDirectoryName(lnk);
        var folder = s.NameSpace(dirname);
        if (folder == null)
        {
            return lnk;
        }
        var item = folder.ParseName(filename);
        if (item == null)
        {
            return lnk;
        }
        var link = (Shell32.ShellLinkObject)item.GetLink;
        return link.Target.Path;
    }
    // I have no idea what this does
    // I think it has something to do with Winforms?
    [STAThread]
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            MessageBox.Show("translnk program [...args]", "Incorrect Usage", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
        }
        var ps = new Process();
        ps.StartInfo.FileName = args[0];
        var sb = new StringBuilder(0xff);
        for (int i = 1; i < args.Length; i++)
        {
            var arg = args[i];
            if (arg.EndsWith(".lnk"))
            {
                arg = ResolveLink(arg);
            }
            sb.Append('"');
            foreach (char c in arg)
            {
                if (c == '\\')
                {
                    sb.Append("\\\\");
                    continue;
                }
                if (c == '"')
                {
                    sb.Append("\\\"");
                    continue;
                }
                sb.Append(c);
            }
            sb.Append('"');
            // put spaces between arguments, not after
            if (i + 1 < args.Length)
            {
                sb.Append(' ');
            }
        }
        ps.StartInfo.Arguments = sb.ToString();
        ps.Start();
        ps.WaitForExit();
        Environment.Exit(ps.ExitCode);
    }
}
