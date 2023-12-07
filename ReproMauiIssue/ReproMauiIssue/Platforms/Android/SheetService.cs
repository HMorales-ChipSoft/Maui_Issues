using Android.Content;
using Android.OS;
using Android.Views;
using Google.Android.Material.BottomSheet;
using Microsoft.Maui.Platform;

namespace ReproMauiIssue.Platforms.Android
{
    internal class SheetService : ISheetService
    {
        public SheetService(Context context)
        {
            _context = context;
        }

        private Context _context;

        public void ShowPage(Page page)
        {
            AndroidX.Fragment.App.FragmentManager? fragmentManager = _context.GetFragmentManager();

            if (fragmentManager is not null && fragmentManager.FindFragmentByTag(nameof(SheetDialogFragment)) == null)
            {
                SheetDialogFragment sheetDialogFragment = new SheetDialogFragment(page, _context);
                sheetDialogFragment.Show(fragmentManager, nameof(SheetDialogFragment));
            }
        }

        public void Dismiss()
        {
            AndroidX.Fragment.App.FragmentManager? fragmentManager = _context.GetFragmentManager();

            if (fragmentManager is not null && fragmentManager.FindFragmentByTag(nameof(SheetDialogFragment)) is SheetDialogFragment sheetDialogFragment)
            {
                sheetDialogFragment.Dismiss();
            }
        }

        private class SheetDialogFragment : BottomSheetDialogFragment
        {
            public SheetDialogFragment(Page page, Context context)
            {
                _page = page;
                _context = context;
            }

            private Page _page;
            private Context _context;

            public override global::Android.Views.View? OnCreateView(LayoutInflater inflater, ViewGroup? container, Bundle? savedInstanceState)
            {
                return new SheetViewGroup(_page, _context);
            }
        }

        private class SheetViewGroup : ViewGroup
        {
            public SheetViewGroup(Page page, Context context)
                : base(context)
            {
                page.Parent = Application.Current?.MainPage;
                if (page.FindMauiContext() is MauiContext mauiContext)
                {                    
                    AddView(_platformView = page.ToPlatform(mauiContext));
                }
            }

            private global::Android.Views.View? _platformView;

            protected override void OnLayout(bool changed, int l, int t, int r, int b)
            {
                _platformView?.Layout(l, t, r, b);
            }

            protected override void Dispose(bool disposing)
            {
                _platformView?.RemoveFromParent();
                base.Dispose(disposing);
            }
        }
    }
}
