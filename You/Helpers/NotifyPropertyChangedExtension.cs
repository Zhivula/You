using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace You.Helpers
{
    public static class NotifyPropertyChangedExtension
    {
        public static void Mutateverbose<TField>(this INotifyPropertyChanged instance, ref TField field, TField newValue, Action<PropertyChangedEventArgs> ralse, [CallerMemberName] string propertyname = null)
        {
            if (EqualityComparer<TField>.Default.Equals(field, newValue)) return;
            field = newValue;
            ralse?.Invoke(new PropertyChangedEventArgs(propertyname));
        }
    }
}
