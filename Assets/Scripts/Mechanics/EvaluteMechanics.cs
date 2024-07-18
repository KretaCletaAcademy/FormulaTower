using System;
using System.Data;

internal static class EvaluteMechanics
{
    public static int Eval(string text)
    {
        return Convert.ToInt32(new DataTable().Compute(text, null));
    }
}
