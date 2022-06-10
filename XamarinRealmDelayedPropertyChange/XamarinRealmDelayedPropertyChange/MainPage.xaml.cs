using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;
using Xamarin.Forms;

namespace XamarinRealmDelayedPropertyChange
{
    public partial class MainPage : ContentPage
    {

        public static readonly BindableProperty RealmObjProperty = BindableProperty.Create(nameof(RealmObj), typeof(MyRealmObject), typeof(MainPage));
        public MyRealmObject RealmObj
        {
            get => (MyRealmObject)GetValue(RealmObjProperty);
            set => SetValue(RealmObjProperty, value);
        }

        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(string), typeof(MainPage));
        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly BindableProperty TransientValueProperty = BindableProperty.Create(nameof(TransientValue), typeof(string), typeof(MainPage));
        public string TransientValue
        {
            get => (string)GetValue(TransientValueProperty);
            set => SetValue(TransientValueProperty, value);
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            SetBinding(ValueProperty, new Binding("RealmObj.Value", BindingMode.TwoWay));
            SetBinding(TransientValueProperty, new Binding("RealmObj.TransientValue", BindingMode.TwoWay));

            RealmObj = new MyRealmObject();

            var realm = Realm.GetInstance("foobar.realm");
            realm.Write(() =>
            {
                realm.Add(RealmObj);
            });
        }

        void ChangePersistentValue_Clicked(System.Object sender, System.EventArgs e)
        {
            Value = "1";
            //await Task.Yield();
            Value = "2";
        }

        void ChangeTransientValue_Clicked(System.Object sender, System.EventArgs e)
        {
            TransientValue = "1";
            TransientValue = "2";
        }
    }
}

