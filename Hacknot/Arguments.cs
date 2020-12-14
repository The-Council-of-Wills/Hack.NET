using System.Text;

class Arguments
{
    public static string[] SplitCommandLine(string line)
    {
        int count = line.Length;
        var state = State.Void;
        int entryCount = 0;
        for (int i = 0; i < count; i++)
        {
            char c = line[i];
            switch (state)
            {
                case State.Void:
                    if (c == '"') state = State.Quoted;
                    else if (c == '\\') state = State.EscapeNonQuoted;
                    else if (!char.IsWhiteSpace(c)) state = State.NonQuoted;

                    break;
                case State.NonQuoted:
                    if (c == '\\') state = State.EscapeNonQuoted;
                    else if (char.IsWhiteSpace(c))
                    {
                        state = State.Void;
                        entryCount++;
                    }

                    break;
                case State.Quoted:
                    if (c == '\\')
                        state = State.EscapeQuoted;
                    else if (c == '"')
                    {
                        state = State.Void;
                        entryCount++;
                    }

                    break;
                case State.EscapeNonQuoted:
                    state = State.NonQuoted;
                    break;
                case State.EscapeQuoted:
                    state = State.Quoted;
                    break;
            }
        }

        if (state != State.Void)
            entryCount++;

        var res = new string[entryCount];
        var sb = new StringBuilder();
        state = State.Void;
        entryCount = 0;
        for (int i = 0; i < count; i++)
        {
            char c = line[i];
            switch (state)
            {
                case State.Void:
                    if (c == '"')
                        state = State.Quoted;
                    else if (c == '\\')
                        state = State.EscapeNonQuoted;
                    else if (!char.IsWhiteSpace(c))
                    {
                        state = State.NonQuoted;
                        sb.Append(c);
                    }

                    break;
                case State.NonQuoted:
                    if (c == '\\')
                        state = State.EscapeNonQuoted;
                    else if (!char.IsWhiteSpace(c))
                        sb.Append(c);
                    else
                    {
                        state = State.Void;
                        res[entryCount] = sb.ToString();
                        entryCount++;
                        sb.Clear();
                    }

                    break;
                case State.Quoted:
                    if (c == '\\')
                        state = State.EscapeQuoted;
                    else if (c != '"')
                        sb.Append(c);
                    else
                    {
                        state = State.Void;
                        res[entryCount] = sb.ToString();
                        entryCount++;
                        sb.Clear();
                    }

                    break;
                case State.EscapeNonQuoted:
                    if (c != '"')
                        sb.Append('\\');
                    sb.Append(c);
                    state = State.NonQuoted;
                    break;
                case State.EscapeQuoted:
                    if (c != '"')
                        sb.Append('\\');
                    sb.Append(c);
                    state = State.Quoted;
                    break;
            }
        }

        if (state != State.Void)
            res[entryCount] = sb.ToString();
        return res;
    }

    private enum State : byte
    {
        Void,
        NonQuoted,
        Quoted,
        EscapeNonQuoted,
        EscapeQuoted
    }
}