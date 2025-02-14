﻿using Internal.Windows.Calls;
using System;
using Windows.ApplicationModel.Calls;
using Windows.UI.Xaml.Data;

namespace Dialer.UI.Converters
{
    public sealed class CallHistoryEntryToCallStateTextString : IValueConverter
    {
        public static string Convert(PhoneCallHistoryEntry entry)
        {
            if (entry.IsIncoming)
            {
                if (entry.IsCallerIdBlocked)
                {
                    return "Blocked";
                }
                else
                {
                    return entry.IsMissed ? "Missed" : App.Current.ResourceLoader.GetString(nameof(CallState) + '_' + nameof(CallState.Incoming));
                }
            }
            else
            {
                return "Outgoing";
            }
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value switch
            {
                PhoneCallHistoryEntry entry => Convert(entry),
                _ => App.Current.ResourceLoader.GetString(nameof(CallState) + "_Unknown"),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
