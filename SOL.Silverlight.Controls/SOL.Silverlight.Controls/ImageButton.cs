using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;


namespace SOL.Silverlight.Controls
{
    [TemplatePart(Name = PART_CONTENT, Type = typeof(ContentPresenter))]
    [TemplatePart(Name = PART_IMAGE, Type = typeof(Image))]
    public class ImageButton : Button
    {
        #region Attributes

        private const string PART_CONTENT = "contentPresenter";
        private const string PART_IMAGE = "PartImage";

        private Image _image;

        #endregion

        #region Constructors

        public ImageButton()
        {
            this.DefaultStyleKey = typeof(ImageButton);
        }

        #endregion

        #region Properties

        [Category("Common")]
        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(null));


        [Category("Common")]
        public double ImageWidth
        {
            get { return (double)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }

        public static readonly DependencyProperty ImageWidthProperty =
            DependencyProperty.Register("ImageWidth", typeof(double), typeof(ImageButton), new PropertyMetadata(null));

        [Category("Common")]
        public double ImageHeight
        {
            get { return (double)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }

        public static readonly DependencyProperty ImageHeightProperty =
            DependencyProperty.Register("ImageHeight", typeof(double), typeof(ImageButton), new PropertyMetadata(null));

        #endregion

        #region Members

        public override void OnApplyTemplate()
        {
            // Apply template
            base.OnApplyTemplate();

            if (this.Content == null || (this.Content is string && String.IsNullOrEmpty((string)this.Content)))
            {
                ContentPresenter contentPresenter = GetTemplateChild(PART_CONTENT) as ContentPresenter;
                if (contentPresenter != null)
                    contentPresenter.Visibility = System.Windows.Visibility.Collapsed;
            }

            this._image = GetTemplateChild(PART_IMAGE) as Image;
            //if (this._image != null)
            //{
            //    this._image.Source = this.ImageSource;
            //}
        }

        #endregion
    }
}
