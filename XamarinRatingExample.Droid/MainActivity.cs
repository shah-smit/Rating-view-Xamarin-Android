using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Java.Lang;

namespace XamarinRatingExample.Droid
{
    [Activity(Label = "XamarinRatingExample", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private ImageView oneStar;
        private ImageView twoStar;
        private ImageView threeStar;
        private ImageView fourStar;
        private ImageView fiveStar;
        private TextView ratingValue;
        private RatingBar ratingBar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.RatingView);

            oneStar = FindViewById<ImageView>(Resource.Id.oneStar);
            oneStar.Click += ratingStar_Click;
            twoStar = FindViewById<ImageView>(Resource.Id.twoStar);
            twoStar.Click += ratingStar_Click;
            threeStar = FindViewById<ImageView>(Resource.Id.threeStar);
            threeStar.Click += ratingStar_Click;
            fourStar = FindViewById<ImageView>(Resource.Id.fourStar);
            fourStar.Click += ratingStar_Click;
            fiveStar = FindViewById<ImageView>(Resource.Id.fiveStar);
            fiveStar.Click += ratingStar_Click;

            ratingValue = FindViewById<TextView>(Resource.Id.ratingValue);

            ratingBar = FindViewById<RatingBar>(Resource.Id.ratingbar);
            ratingBar.RatingBarChange += (sender, e) => {
                ratingValue.Text = "User rating " + ratingBar.Rating.ToString();
            };

        }

        void ratingStar_Click(object sender, EventArgs e)
        {
            ImageView imageView = sender as ImageView;
            updateRatingView(Integer.ParseInt(imageView.Tag.ToString()));
        }

        void updateRatingView(int tag)
        {
            ImageView[] stars = { oneStar, twoStar, threeStar, fourStar, fiveStar };

            for (int i = 0; i < stars.Length; i++)
            {
                if (i < tag)
                {
                    SetImageViewImage(stars[i], Resource.Drawable.star_filled);
                }
                else
                {
                    SetImageViewImage(stars[i], Resource.Drawable.star_empty);
                }
            }

            ratingValue.Text = "User rating: " + tag;
        }

        public static void SetImageViewImage(ImageView iv, int resourceId)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {

                iv.SetImageDrawable(Application.Context.GetDrawable(resourceId));
            }
            else
            {
                iv.SetImageResource(resourceId);
            }
        }
    }
}


