﻿namespace VisualPlus.Toolkit.Components
{
    #region Namespace

    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    using VisualPlus.Localization;
    using VisualPlus.Managers;
    using VisualPlus.Renders;
    using VisualPlus.Structure;

    #endregion

    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(VisualBadge), "VisualBadge.bmp")]
    [Description("The VisualPlus badge component enables controls to have a badge with text displayed.")]
    public class VisualBadge : Component
    {
        #region Variables

        private Color _background;
        private Action<Control> _clickEvent;
        private Control _control;
        private Label _label;
        private Shape _shape;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualBadge" /> class.</summary>
        /// <param name="control">The control to attach.</param>
        /// <param name="action">The action.</param>
        public VisualBadge(Control control, Action<Control> action) : this()
        {
            _clickEvent = action;
            _control = control;

            if (Enabled)
            {
                Attach();
            }

            ConstructVisualBadge(_label.Text, _label.Font, _label.ForeColor, _background, new Rectangle(_label.Location, _label.Size), new Shape());
        }

        /// <summary>Initializes a new instance of the <see cref="VisualBadge" /> class.</summary>
        /// <param name="control">The control to attach.</param>
        /// <param name="action">The action.</param>
        /// <param name="text">The text.</param>
        public VisualBadge(Control control, Action<Control> action, string text) : this()
        {
            _clickEvent = action;
            _control = control;

            if (Enabled)
            {
                Attach();
            }

            ConstructVisualBadge(text, _label.Font, _label.ForeColor, _background, new Rectangle(_label.Location, _label.Size), new Shape());
        }

        /// <summary>Initializes a new instance of the <see cref="VisualBadge" /> class.</summary>
        /// <param name="control">The control to attach.</param>
        /// <param name="action">The action.</param>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        public VisualBadge(Control control, Action<Control> action, string text, Font font) : this()
        {
            _clickEvent = action;
            _control = control;

            if (Enabled)
            {
                Attach();
            }

            ConstructVisualBadge(text, font, _label.ForeColor, _background, new Rectangle(_label.Location, _label.Size), new Shape());
        }

        /// <summary>Initializes a new instance of the <see cref="VisualBadge" /> class.</summary>
        /// <param name="control">The control to attach.</param>
        /// <param name="action">The action.</param>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="foreColor">The fore Color.</param>
        public VisualBadge(Control control, Action<Control> action, string text, Font font, Color foreColor) : this()
        {
            _clickEvent = action;
            _control = control;

            if (Enabled)
            {
                Attach();
            }

            ConstructVisualBadge(text, font, foreColor, _background, new Rectangle(_label.Location, _label.Size), new Shape());
        }

        /// <summary>Initializes a new instance of the <see cref="VisualBadge" /> class.</summary>
        /// <param name="control">The control to attach.</param>
        /// <param name="action">The action.</param>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="foreColor">The fore Color.</param>
        /// <param name="background">The background.</param>
        public VisualBadge(Control control, Action<Control> action, string text, Font font, Color foreColor, Color background) : this()
        {
            _clickEvent = action;
            _control = control;

            if (Enabled)
            {
                Attach();
            }

            ConstructVisualBadge(text, font, foreColor, background, new Rectangle(_label.Location, _label.Size), new Shape());
        }

        /// <summary>Initializes a new instance of the <see cref="VisualBadge" /> class.</summary>
        /// <param name="control">The control to attach.</param>
        /// <param name="action">The action.</param>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="foreColor">The fore Color.</param>
        /// <param name="background">The background.</param>
        /// <param name="rectangle">The rectangle.</param>
        public VisualBadge(Control control, Action<Control> action, string text, Font font, Color foreColor, Color background, Rectangle rectangle) : this()
        {
            _clickEvent = action;
            _control = control;

            if (Enabled)
            {
                Attach();
            }

            ConstructVisualBadge(text, font, foreColor, background, rectangle, new Shape());
        }

        /// <summary>Initializes a new instance of the <see cref="VisualBadge" /> class.</summary>
        /// <param name="control">The control to attach.</param>
        /// <param name="action">The action.</param>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="foreColor">The fore Color.</param>
        /// <param name="background">The background.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="shape">The shape.</param>
        public VisualBadge(Control control, Action<Control> action, string text, Font font, Color foreColor, Color background, Rectangle rectangle, Shape shape) : this()
        {
            _clickEvent = action;
            _control = control;

            if (Enabled)
            {
                Attach();
            }

            ConstructVisualBadge(text, font, foreColor, background, rectangle, shape);
        }

        /// <summary>Initializes a new instance of the <see cref="VisualBadge" /> class.</summary>
        /// <param name="container">The container.</param>
        public VisualBadge(IContainer container) : this()
        {
            container.Add(this);
        }

        /// <summary>Prevents a default instance of the <see cref="VisualBadge" /> class from being created.</summary>
        private VisualBadge()
        {
            StyleManager styleManager = new StyleManager(Settings.DefaultValue.DefaultStyle);

            _background = Color.FromArgb(120, 183, 230);
            _clickEvent = null;

            _label = new Label
                {
                    ForeColor = Color.White,
                    Text = @"0",
                    Font = styleManager.Theme.TextSetting.Font,
                    Location = new Point(0, 0),
                    BackColor = Color.Transparent,
                    Size = new Size(25, 20)
                };

            _label.Click += OnLabel_Click;
            _label.Paint += OnLabel_Paint;

            _shape = new Shape();
        }

        #endregion

        #region Properties

        [DefaultValue(typeof(Color), "Blue")]
        [Description(PropertyDescription.Color)]
        [Category(PropertyCategory.Appearance)]
        public Color Background
        {
            get
            {
                return _background;
            }

            set
            {
                _background = value;
                _label.Invalidate();
            }
        }

        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category(PropertyCategory.Behavior)]
        [Description("The control to attach this component.")]
        public Control Control
        {
            get
            {
                return _control;
            }

            set
            {
                _control = value;

                if (_control == null)
                {
                    return;
                }

                if (Enabled)
                {
                    Attach();
                }
                else
                {
                    Remove();
                }
            }
        }

        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.Toggle)]
        public bool Enabled
        {
            get
            {
                return _label.Visible;
            }

            set
            {
                _label.Visible = value;

                if (_control == null)
                {
                    return;
                }

                if (Enabled)
                {
                    Attach();
                }
                else
                {
                    Remove();
                }
            }
        }

        [Description(PropertyDescription.Font)]
        [Category(PropertyCategory.Appearance)]
        public Font Font
        {
            get
            {
                return _label.Font;
            }

            set
            {
                _label.Font = value;
                _label.Invalidate();
            }
        }

        [Description(PropertyDescription.Color)]
        [Category(PropertyCategory.Appearance)]
        public Color ForeColor
        {
            get
            {
                return _label.ForeColor;
            }

            set
            {
                _label.ForeColor = value;
                _label.Invalidate();
            }
        }

        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Color)]
        [Category(PropertyCategory.Appearance)]
        public Point Location
        {
            get
            {
                return _label.Location;
            }

            set
            {
                _label.Location = value;
                _label.Invalidate();
            }
        }

        [TypeConverter(typeof(ShapeConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category(PropertyCategory.Appearance)]
        public Shape Shape
        {
            get
            {
                return _shape;
            }

            set
            {
                _shape = value;
                _label.Invalidate();
            }
        }

        [Description(PropertyDescription.Size)]
        [Category(PropertyCategory.Appearance)]
        public Size Size
        {
            get
            {
                return _label.Size;
            }

            set
            {
                _label.Size = value;
                _label.Invalidate();
            }
        }

        [Description(PropertyDescription.Text)]
        [Category(PropertyCategory.Appearance)]
        public string Text
        {
            get
            {
                return _label.Text;
            }

            set
            {
                _label.Text = value;
                _label.Invalidate();
            }
        }

        #endregion

        #region Methods

        /// <summary>Attach the <see cref="VisualBadge" /> to the control.</summary>
        private void Attach()
        {
            _control.Controls.Add(_label);
        }

        /// <summary>Creates the <see cref="VisualBadge" />.</summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="foreColor">The fore Color.</param>
        /// <param name="background">The background.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="shape">The shape.</param>
        private void ConstructVisualBadge(string text, Font font, Color foreColor, Color background, Rectangle rectangle, Shape shape)
        {
            _background = background;

            _label.Text = text;
            _label.Font = font;
            _label.ForeColor = foreColor;
            _label.Size = rectangle.Size;
            _label.Location = rectangle.Location;

            _shape = shape;
        }

        /// <summary>On label click.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void OnLabel_Click(object sender, EventArgs e)
        {
            _clickEvent?.Invoke(_label);
        }

        /// <summary>On label paint.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void OnLabel_Paint(object sender, PaintEventArgs e)
        {
            Size _textSize = GraphicsManager.MeasureText(Text, Font, e.Graphics);
            VisualBadgeRenderer.DrawBadge(e.Graphics, new Rectangle(new Point(0, 0), new Size(_label.Width - 1, _label.Height - 1)), Background, Text, Font, ForeColor, Shape, new Point((_label.Width / 2) - (_textSize.Width / 2), (_label.Height / 2) - (_textSize.Height / 2)));
        }

        /// <summary>Remove the <see cref="VisualBadge" /> from the control.</summary>
        private void Remove()
        {
            if (_label != null)
            {
                _control.Controls.Remove(_label);
            }
        }

        /// <summary>Sets the click action for the <see cref="VisualBadge" />.</summary>
        /// <param name="action">The click action to set.</param>
        public void SetClickAction(Action<Control> action)
        {
            if (_label != null)
            {
                _clickEvent = action;
            }
        }

        #endregion
    }
}