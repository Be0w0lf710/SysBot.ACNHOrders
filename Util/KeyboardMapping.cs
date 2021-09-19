using System.Collections.Generic;

namespace SysBot.ACNHOrders
{
    public static class KeyboardMapping
    {
        public enum Key
        {
            HidKeyboardKeyD1 = 30,
            HidKeyboardKeyD2 = 31,
            HidKeyboardKeyD3 = 32,
            HidKeyboardKeyD4 = 33,
            HidKeyboardKeyD5 = 34,
            HidKeyboardKeyD6 = 35,
            HidKeyboardKeyD7 = 36,
            HidKeyboardKeyD8 = 37,
            HidKeyboardKeyD9 = 38,
            HidKeyboardKeyD0 = 39
        }

        private static string GetEnumString(Key key)
        {
            var stringValue = ((int) key).ToString();
            return stringValue;
        }
        public static Dictionary<char, string> GetKeyMappingMap()
        {
            var keyMapping = new Dictionary<char, string>
            {
                {'1', $"key {GetEnumString(Key.HidKeyboardKeyD1)}"},
                {'2', $"key {GetEnumString(Key.HidKeyboardKeyD2)}"},
                {'3', $"key {GetEnumString(Key.HidKeyboardKeyD3)}"},
                {'4', $"key {GetEnumString(Key.HidKeyboardKeyD4)}"},
                {'5', $"key {GetEnumString(Key.HidKeyboardKeyD5)}"},
                {'6', $"key {GetEnumString(Key.HidKeyboardKeyD6)}"},
                {'7', $"key {GetEnumString(Key.HidKeyboardKeyD7)}"},
                {'8', $"key {GetEnumString(Key.HidKeyboardKeyD8)}"},
                {'9', $"key {GetEnumString(Key.HidKeyboardKeyD9)}"},
                {'0', $"key {GetEnumString(Key.HidKeyboardKeyD0)}"}
            };
            return keyMapping;
        }
    }
}