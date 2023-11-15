﻿using static System.Net.Mime.MediaTypeNames;

namespace ef_core_service.BookServices;
public class DropdownTuple
{
    public string? Value { get; set; }
    public string? Text { get; set; }

    public override string ToString() {
        return $"{nameof(Value)}: {Value}, {nameof(Text)}: {Text}";
    }

}
