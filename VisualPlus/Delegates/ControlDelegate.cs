﻿namespace VisualPlus.Delegates
{
    #region Namespace

    using System;

    using VisualPlus.EventArgs;
    using VisualPlus.Toolkit.Child;

    #endregion

    public delegate void ElementClickedEventHandler(EventArgs e);

    public delegate void ForeColorDisabledChangedEventHandler(ColorEventArgs e);

    public delegate void MouseStateChangedEventHandler(MouseStateEventArgs e);

    public delegate void TextRenderingChangedEventHandler(TextRenderingEventArgs e);

    public delegate void BackgroundChangedEventHandler(ColorEventArgs e);

    public delegate void ToggleChangedEventHandler(ToggleEventArgs e);

    public delegate void BackColorStateChangedEventHandler(ColorEventArgs e);

    public delegate void ValueChangedEventHandler(ValueChangedEventArgs e);

    public delegate void ListViewChangedEventHandler(object source, ListViewChangedEventArgs e);

    public delegate void VisualItemCheckedEventHandler(VisualListViewItem item);
}