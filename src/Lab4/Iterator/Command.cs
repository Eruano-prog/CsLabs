using System.Collections;

namespace Itmo.ObjectOrientedProgramming.Lab4.Iterator;

public class Command : IEnumerator
{
    private string _string;
    private int _index;

    public Command(string s)
    {
        _string = s;
        _index = 0;
    }

    public object Current
    {
        get
        {
            string current = string.Empty;
            int cur_index = _index;
            bool quotation = false;
            while (cur_index < _string.Length && (quotation || _string[cur_index] != ' '))
            {
                if (_string[cur_index] == '\'')
                {
                    quotation = !quotation;
                }
                else
                {
                    current += _string[cur_index];
                }

                cur_index++;
            }

            return current;
        }
    }

    public bool MoveNext()
    {
        bool quotation = false;
        while (_index < _string.Length && (quotation || _string[_index] != ' '))
        {
            if (_string[_index] == '\'')
            {
                quotation = !quotation;
            }

            _index++;
        }

        _index++;

        return _index < _string.Length;
    }

    public void Reset()
    {
        _index = 0;
    }

    public Command Clone()
    {
        return (Command)MemberwiseClone();
    }
}