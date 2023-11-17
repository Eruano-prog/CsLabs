using System.Collections;

namespace Itmo.ObjectOrientedProgramming.Lab4.Iterator;

// TODO Починить случай, когда в адрессе есть пробел
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
            while (cur_index < _string.Length && _string[cur_index] != ' ')
            {
                current += _string[cur_index];
                cur_index++;
            }

            return current;
        }
    }

    public bool MoveNext()
    {
        while (_index < _string.Length && _string[_index] != ' ')
        {
            _index++;
        }

        _index++;

        return _index < _string.Length;
    }

    public void Reset()
    {
        _index = 0;
    }
}