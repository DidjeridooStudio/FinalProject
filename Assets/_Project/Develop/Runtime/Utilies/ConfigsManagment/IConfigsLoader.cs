using System;
using System.Collections;
using System.Collections.Generic;

public interface IConfigsLoader
{
    IEnumerator LoadAsync(Action<Dictionary<Type, object>> onConfigsLoaded);
}
